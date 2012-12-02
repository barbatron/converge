using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestTools.Generators;
using TestTools.Helpers;

namespace NQ.TestTools.TCons
{
    class Program
    {
        static void Main(string[] args)
        {
            DummyOffice off = new DummyOffice("Branch-123", 5, 8, 5);
            off.MaximumServingTime = TimeSpan.FromSeconds(10d);

            
            off.Open();

            Console.WriteLine("(press any key to start draw.)");
            Console.ReadKey();

            while (true)
            {
                var r = new DummyOfficeTextPresenter(off) { RowWidth = 80 };
                Console.Clear();
                Console.WriteLine(r.ToString());
                Thread.Sleep(100);
                if (Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.Escape)
                    break;
            }

            off.Close();

        }
    }
}
