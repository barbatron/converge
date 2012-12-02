using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTools.Generators;

namespace TestTools.Helpers
{
    public class DummyOfficeTextPresenter
    {
        public int RowWidth = 80;

        private DummyOffice office;

        private int serviceTypeColWidth;
        private List<DummyServiceType> stl;
        private List<int> queueColStops;

        public DummyOfficeTextPresenter(DummyOffice office)
        {
            this.office = office;
        }



        StringBuilder sb = new StringBuilder();
        public override string ToString()
        {
            sb = new StringBuilder();
            serviceTypeColWidth = 15;

            sb.AppendLF("Branch \"{0}\": {1}", office.BranchId, office.IsOpen ? "Open" : "Closed");

            WriteIdleUsers(sb);

            stl = office.ServiceTypes.ToList();
            queueColStops = GetColumnIndents(stl.Select(st => string.Format("S-TYPE: #{0}   ", st.Number)), RowWidth).ToList();
            if (queueColStops.Count < stl.Count)
            {
                int fixedWidth = (RowWidth + 10) / stl.Count;
                int cc = 0;
                queueColStops = new List<int>();
                foreach (var st in stl)
                {
                    queueColStops.Add(cc);
                    cc += fixedWidth;
                }
            }

            sb.AppendLF();
            WriteQueueHeaders(sb);
            WriteActiveUsers(sb);
            WriteOpenCashiers(sb);
            WriteDesk(sb);
            WriteTickets(); 
            NewQueueRow(sb);

            return sb.ToString();
        }

        private void WriteQueueHeaders(StringBuilder sb)
        {
            InitRowBuilders(4);
            PerServiceType(qcc =>
            {
                // Header
                WriteQueueRow(string.Format("S-TYPE: #{0}", qcc.ServiceType.Number), qcc.Index, 0);
                WriteQueueRow(new string('=', qcc.ColWidth - 2), qcc.Index, 1);
                WriteQueueRow(string.Format("WC={0} AWT={1}s", 
                    qcc.ServiceType.Queue.Count,
                    Math.Round(qcc.ServiceType.Queue.AverageWaitingTime().TotalSeconds)), qcc.Index, 2);
                WriteQueueRow(" ", qcc.Index, 3);
                
            });
        }

        private void WriteIdleUsers(StringBuilder sb)
        {
            sb.AppendLF("USERS (IDLE):");

            // Idle users first
            var idleUsers = office.Users.Where(u => u.IsIdle).ToList();
            if (idleUsers.Count > 0)
            {
                foreach (var usrRow in Columnize(idleUsers.Select(u => u.ToString())))
                    sb.AppendLF(usrRow);
            }
            else sb.AppendLF("");
        }

        private void WriteActiveUsers(StringBuilder sb)
        {
            InitRowBuilders(1);
            PerServiceType(qcc =>
                {
                    var c = qcc.Cashier;
                    if (c != null)
                    {
                        // Any active user?
                        var u = c.CurrentUser;

                        if (u != null)
                        {
                            WriteQueueRow(string.Format(" User #{0}", u.Number), qcc.Index, 0);
                        }
                    }
                });
        }

        private void WriteOpenCashiers(StringBuilder sb)
        {
            InitRowBuilders(1);
            PerServiceType(qcc =>
            {
                var c = qcc.Cashier;
                if (c != null)
                {
                    WriteQueueRow(string.Format("[Cashier #{0}]", c.Number), qcc.Index, 0);
                    //WriteQueueRow(new string('-', qcc.ColWidth - 2), qcc.Index, 1);
                }
            });
        }

        private void WriteDesk(StringBuilder sb)
        {
            InitRowBuilders(3);
            PerServiceType(qcc =>
            {
                WriteQueueRow(new string('-', qcc.ColWidth - 2), qcc.Index, 0);
                WriteQueueRow(new string('-', qcc.ColWidth - 2), qcc.Index, 2);
                var c = qcc.Cashier;
                if (c != null)
                {   
                    var servedTicket = c.CurrentTicket;
                    if (servedTicket != null)
                    {
                        WriteQueueRow(string.Format("Srv={0} t={1}s",
                            servedTicket.Name,
                            Math.Round(servedTicket.ServeTime.TotalSeconds)), qcc.Index, 1);
                    }
                }
                else
                {
                    WriteQueueRow("(none servd)", qcc.Index, 1);
                }
            });
        }

        private void WriteTickets()
        {
            int maxWaiting = office.ServiceTypes.Max(st => st.Queue.Count);
            int rowsToShow = Math.Min(maxWaiting, 20);
            InitRowBuilders(rowsToShow + 2);
            PerServiceType(qcc =>
            {
                var tickets = qcc.ServiceType.Queue.ToList();

                for (int tr = 0; tr < rowsToShow; tr++)
                {
                    if (tr < tickets.Count)
                    {
                        var t = tickets[tr];
                        WriteQueueRow(t.Name, qcc.Index, tr);
                    }
                }
                if (tickets.Count > rowsToShow)
                    WriteQueueRow(string.Format("({0} more)", tickets.Count - rowsToShow), qcc.Index, rowsToShow + 1);

            });
        }


        #region Private helpers

        private IEnumerable<int> GetColumnIndents(IEnumerable<string> items, int maxRowWidth = -1)
        {
            if (maxRowWidth == -1) maxRowWidth = RowWidth;
            int itemMaxWidth = items.Max(s => s.Length);
            int minSpacing = 4;                             // Prevent items from touching each other
            int columnWidth = itemMaxWidth + minSpacing;
            columnWidth = Math.Max(columnWidth, 16);        // prevent too dense cols if items are short
            int cp = 0;
            int idx = 0;
            int itemCount = items.Count();
            while (cp < maxRowWidth && idx < itemCount)
            {
                // First item is "here"
                yield return cp;

                // Move to next
                idx++;
                cp += columnWidth;
            }
        }
        private IEnumerable<string> Columnize(IEnumerable<string> items, int maxRowWidth = -1)
        {
            if (maxRowWidth == -1) maxRowWidth = RowWidth;
            List<int> colStops = GetColumnIndents(items, maxRowWidth).ToList();

            var outputQueue = items.ToList();
            //int itemMaxWidth = outputQueue.Max(s => s.Length);
            //int columnWidth = Math.Max(itemMaxWidth + 3, 16);
            //int itemCount = outputQueue.Count;
            StringBuilder sb = new StringBuilder();
            int itemCursor = 0;
            int colPosCursor = 0;
            while (itemCursor < outputQueue.Count)
            {
                var item = outputQueue[itemCursor];
                sb.Append(item);

                colPosCursor++;
                if (colPosCursor == colStops.Count)
                {
                    // Time for row switch - no more col stops for this row
                    yield return sb.ToString();
                    sb.Clear();
                    colPosCursor = 0;
                }
                else
                {
                    // Item followed by another column - evaluate need for padding
                    int nextColStop = colStops[colPosCursor];
                    int alreadyWritten = sb.ToString().Length;
                    string padString = new string(' ', nextColStop - alreadyWritten);
                    sb.Append(padString);
                }
                // Ready for next item
                itemCursor++;
            }
            if (sb.Length > 0)
                yield return sb.ToString();
        }

        List<StringBuilder> rowBuilders = null;

        private int GetQueueColWidth(int colIndex)
        {
            if (colIndex >= queueColStops.Count - 1)
                return 30; // ??
            else
            {
                int startCol = queueColStops[colIndex];
                int endCol = queueColStops[colIndex + 1];
                return endCol - startCol;
            }
        }
        private void WriteQueueRow(string content, int queueColumnIndex, int rowNo)
        {
            var rb = rowBuilders[rowNo];

            int targetCol = queueColStops[queueColumnIndex];
            int colWidth = GetQueueColWidth(queueColumnIndex);

            string currRb = rb.ToString();

            if (content.Length < colWidth)
                content = content.PadRight(colWidth);
            else if (content.Length > colWidth)
                content = content.Substring(0, colWidth);
            
            string leftStr = currRb.Substring(0, targetCol);
            string rightStr = currRb.Substring(targetCol + colWidth);

            rb.Clear();
            rb.Append(leftStr + content.PadRight(colWidth) + rightStr);

        }

        private void InitRowBuilders(int rows)
        {
            if (rowBuilders != null && rowBuilders.Count > 0)
                NewQueueRow(sb);

            rowBuilders = new List<StringBuilder>();
            for (int r = 0; r < rows; r++)
            {
                rowBuilders.Add(new StringBuilder(new string(' ', RowWidth + 20)));
            }
        }


        private void NewQueueRow(StringBuilder dest)
        {
            while (rowBuilders.Count > 0)
            {
                dest.AppendLF(rowBuilders[0].ToString());
                rowBuilders.RemoveAt(0);
            }
        }
        private class QueueColumnContext
        {
            public int Index { get; set; }
            public int ColWidth { get; set; }

            public DummyUser User { get; set; }
            public DummyCashier Cashier { get; set; }
            public DummyServiceType ServiceType { get; set; }
        }
        private void PerServiceType(Action<QueueColumnContext> actionPerStWithIndex)
        {
            for (int sti = 0; sti < stl.Count; sti++)
            {
                var st = stl[sti];
                var qcc = new QueueColumnContext
                    {
                        Index = sti,
                        ServiceType = st,
                        ColWidth = GetQueueColWidth(sti)
                    };

                // Get any servicing cashier for this ST
                var serviceTypeCashier = office.Cashiers.Where(c => c.ServiceType == st)
                    .FirstOrDefault();

                qcc.Cashier = serviceTypeCashier;

                if (serviceTypeCashier != null)
                    qcc.User = serviceTypeCashier.CurrentUser;

                actionPerStWithIndex(qcc);
            }
        }
        #endregion

    }

}
