using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTools.Generators
{
    public abstract class DummyItemBase
    {
        protected static Action<string> logFallback;

        public bool verbose { get; set; } // Widened toString constructs?

        public Action<string> LogString { get; set; }

        public string BranchId { get; set; }

        private char[] waitChar = new[] { '-', '/', '|', '\\' };
        private int tickNo = 0;
        protected string TickChar { get { return waitChar[(++tickNo) % waitChar.Length].ToString(); } }

        protected internal DummyItemBase()
            : this(logFallback)
        {
        }
        protected internal DummyItemBase(Action<string> logStrig)
        {
            LogString = logStrig;
        }

        protected void Log(string s, params object[] strParams)
        {
            var formattedS = string.Format(s, strParams);
            if (LogString != null) LogString(string.Format("{0}> {1}", BranchId, formattedS));
        }
    }
}
