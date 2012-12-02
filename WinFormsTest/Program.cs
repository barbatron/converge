using Converge;
using Converge.Model;
using Converge.Sagas;
using MassTransit;
using MassTransit.Saga;
using StructureMap;
using System;
using System.Threading;
using System.Windows.Forms;
using Topshelf;

namespace WinFormsTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //IContainer c = BootstrapContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            NodeContext nc = null;

            NodeRecord rec = new NodeRecord();
            string host = "localhost";
            bool tryConnect = false;

            var connectForm = new ConnectForm();

            connectForm.FormClosing += (s, ea) =>
            {
                try
                {
                    rec.NodeId = connectForm.NodeId;
                    rec.OrgNodeId = -1;
                    rec.QueueBaseName = connectForm.AppName;
                    rec.QueueTransportSettings = TransportSettings.UseRabbitMq(connectForm.Host);
                    

                    host = connectForm.Host;
                    tryConnect = true;
                }
                catch (Exception ex)
                {
                    ea.Cancel = true;
                    MessageBox.Show(connectForm, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            Application.Run(connectForm);


            if (connectForm.DialogResult != DialogResult.Cancel && tryConnect)
            {
                connectForm = null;

                var bus = ServiceBusFactory.New(sbc =>
                {
                    sbc.ReceiveFrom(rec.QueueUri);
                    sbc.UseControlBus();

                    rec.QueueTransportSettings.ApplyGlobalConfig(sbc);

                });

                // We got a node context, yay.
                // Launch a service which takes care of traffix, and provide some
                // means for the ClientForm to xommunixate with that service:
                var clientForm = new ClientForm(rec, bus);
                //LaunchMessageService(nc, svc =>
                //{
                Application.Run(clientForm);
                nc.Dispose();
                //});
            }
        }

        //private static void LaunchMessageService(NodeContext nc, Action<NodeService<EventSubmissionSaga>> benefactor)
        //{
        //    HostFactory.Run(c =>
        //    {
        //        c.SetServiceName("ConvergeTestClient");
        //        c.SetDisplayName("Converge Test Client");
        //        c.SetDescription("An instance of a Converge test client.");

        //        c.RunAsLocalSystem();
        //        //c.DependsOnMsmq();

        //        c.Service<NodeService<NodeInstallationSaga>>(s =>
        //        {
        //            s.WhenStarted(o =>
        //            {
        //                o.Start();
        //            });

        //            s.WhenStopped(o => o.Stop());

        //        });

        //    });
        //}


        static IContainer BootstrapContainer()
        {
            var container = new Container(x =>
            {
                x.AddType(typeof(ConnectForm));
                x.AddType(typeof(ClientForm));
            });

            //container.Configure(cfg =>
            //{
            //    cfg.For<ISagaRepository<EventSubmissionSaga>>()
            //        .Singleton()
            //        .Use<InMemorySagaRepository<EventSubmissionSaga>>();

            //    cfg.For<NodeService<EventSubmissionSaga>>()
            //        .Singleton()
            //        .Use<NodeService<EventSubmissionSaga>>();
            //});

            return container;
        }
    }
}
