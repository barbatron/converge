using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTools.Generators
{

    public class DummyUser : DummyItemBase
    {
        public int Number { get; set; }
        public DummyCashier Cashier { get; set; }    // Where the user is currently serving
        public bool IsActive { get { return Cashier != null; } }
        public bool IsIdle { get { return Cashier == null; } }

        public override string ToString()
        {
            string ret = "User #" + Number;

            if (Cashier != null) ret += " (c#" + Cashier.Number + ")";
           
            return ret;
        }

    }
}
