
using Converge.Messages;
using Converge.Model;
using Magnum;
using MassTransit;
using System;
using System.IO;
using System.Threading;
namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TransportSettings ts = TransportSettings.UseRabbitMq("localhost");
                int saltNumber = new Random().Next(1000, 10000);
                string appName = string.Format("cclient_{0}", saltNumber);

                var bus = ServiceBusFactory.New(sbc =>
                {
                    sbc.ReceiveFrom(ts.GetQueueUri(appName));
                    sbc.UseControlBus();

                    ts.ApplyGlobalConfig(sbc);

                });

                bus.PublishRequest(new NodeSetupRequest
                {
                    NodeId = appName,
                    CorrelationId = CombGuid.Generate(),
                    NqApplicationId = 1000,
                    NqInstanceNumber = 0,
                    NqApplicationVersionInfo = "1.0.0.0"
                }, x =>
                {
                    x.HandleTimeout(TimeSpan.FromSeconds(10d), () =>
                    {
                        Console.WriteLine("Node setup request timed out - please ensure server connectivity and try again.");
                        throw new TimeoutException();
                    });
                    x.HandleFault(fault =>
                    {
                        Console.WriteLine("Node setup request total error.");
                        throw new IOException();

                    });
                    x.Handle<NodeSetupResponse>(msg =>
                    {
                        Console.WriteLine("Got NodeSetupResponse: " + msg.ToString());
                        x.SetTimeout(TimeSpan.FromSeconds(30));

                    });
                });

                using (var ms = new MessageSubscriber(bus))
                {
                    ms.Subscribe();
                    Console.WriteLine("Waiting for messages. Press Escape to exit.");

                    while (Console.ReadKey().Key != ConsoleKey.Escape)
                    {
                        Thread.Sleep(10);
                    }
                }

                bus.Dispose();
            }
            catch (TimeoutException)
            { }
            catch (IOException) { }
        }
    }
}
