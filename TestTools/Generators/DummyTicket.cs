using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTools.Generators
{

    public class DummyTicket : DummyItemBase
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DummyServiceType ServiceType { get; set; }

        public TimeSpan TaskDuration { get; set; }
        
        public DateTime? ServiceStart { get; set; }
        public DateTime? ServiceEnd { get; set; }

        // WaitTime - amount of time spent waiting (always available)
        public TimeSpan WaitTime { get {
            return ServiceStart.GetValueOrDefault(DateTime.Now) - Created;
        } }

        // ServeTime - amount of time spent 
        public TimeSpan ServeTime { get {
            if (ServiceStart.HasValue == false) return TimeSpan.Zero; // Not even started serv
            return ServiceEnd.GetValueOrDefault(DateTime.Now) - ServiceStart.Value;
        } }

        public bool IsServed { get { return ServiceEnd.HasValue; } }

        public DummyTicket() { Created = DateTime.Now; }

        public void StartService()
        {
            if (ServiceStart.HasValue == true) throw new InvalidOperationException("Service already started");
            ServiceStart = DateTime.Now;
        }
        public bool TryEndService()
        {
            if (ServiceEnd.HasValue) throw new InvalidOperationException("Already ended");
            if (ServiceStart.HasValue == false) return false; // not even started
            if (DateTime.Now < (ServiceStart.Value + TaskDuration)) return false; // not enough serve time
            EndService();
            return true;
        }
        public void EndService()
        {
            if (ServiceStart.HasValue == false) throw new InvalidOperationException("Service not started");
            ServiceEnd = DateTime.Now;
            ServiceType.TicketServed(this);
        }
        public override string ToString()
        {
            string status = ServiceStart.HasValue ? "in service" : "waiting";
            return string.Format("Ticket {0} (ST#{2}) ({1})", Name, status, ServiceType.Number);
        }
    }

}
