
using Converge.Messages;
using Converge.Model;
using Magnum;
using MassTransit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
//using WinFormsTest.Helpers;

namespace WinFormsTest
{
    public partial class ClientForm : Form,
        Consumes<CommandMessage>.For<Guid>,
        Consumes<PingMessage>.For<Guid>
    {
        private NodeRecord nodeRecord;
        private Guid _transactionId;
        private UnsubscribeAction _unsubscribeToken;
        private IServiceBus bus;

        public IServiceBus Bus { get { return bus; } }

        public ClientForm(NodeRecord rec, IServiceBus bus)
        {
            InitializeComponent();
            this.bus = bus;
            this.nodeRecord = rec;
        }

        public Guid CorrelationId
        {
            get { return _transactionId; }
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            treeViewTasks.ExpandAll();
            ClearResults();
            AddResult("Ready.");

            //_unsubscribeToken = Bus.SubscribeInstance(this);
        }

        /// <summary>
        /// Initiates a node installation saga by publishing a NodeAppConnect message. 
        /// Server is expected to reply with messages providing context and behavioral 
        /// specs.
        /// </summary>
        private void NegotiateConnect()
        {
            ClearResults();
            AddResult("CONNECT NEGOTIATION");

            AddResult("Registering instance subscription");
            if (_unsubscribeToken != null) _unsubscribeToken();
            _unsubscribeToken = Bus.SubscribeInstance(this);

            // Create ID used throughout the connect negotiation:
            _transactionId = CombGuid.Generate();
            AddResult("Negotiation ID created: " + _transactionId.ToString());

            //var message = nodeRecord.ToClientConnectMessage(_transactionId);
            //Bus.Publish(message, x => x.SetResponseAddress(Bus.Endpoint.Address.Uri));
            //AddResult("Message published.");
        }

        public void Consume(PingMessage message)
        {
            AddResult("Pingback from server: " + message.ToString());
            AddResult("CONNECTED.");

            this.UIThreadInvoke(() =>
            {
                if (checkBoxSignalExitEvent.Checked)
                {
                    // Spawn event message
                    var genEvent = new GenericEventMessage
                    {
                        CorrelationId = message.CorrelationId,
                        NodeId = message.NodeId,
                        DataFormatVersion = 123,
                        EventDataFormat = "",
                        EventData = "exit",
                        LocalNodeVista = ""
                    };

                    Bus.Publish(genEvent, x => x.SetResponseAddress(Bus.Endpoint.Address.Uri));

                    //Bus.Context().Respond(genEvent, x => x.SetResponseAddress(Bus.Endpoint.Address.Uri));

                }
            });
        }

        public void Consume(CommandMessage eventMessage)
        {
            ClearResults();
            
            MessageBox.Show("Command received: " + eventMessage.Command + "\n" +
                eventMessage.Parameters);
        }





        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (_unsubscribeToken != null)
            {
                _unsubscribeToken();
                _unsubscribeToken = null;
            }

            // This is done somewhere else (NodeContext.Dispose)
            //_bus.Dispose();
            //_bus = null;

            base.OnClosing(e);
        }


        private void buttonPubConnect_Click(object sender, EventArgs e)
        {
            buttonPubConnect.Enabled = false;
            try
            {
                NegotiateConnect();
            }
            finally { buttonPubConnect.Enabled = true; }
        }

        #region LabelBox log output

        private void AddResult(string report)
        {
            this.UIThreadInvoke(() =>
            {
                string currentText = labelResult.Text;
                StringReader sr = new StringReader(currentText);

                // Split by linefeeds and store existing lines in list
                List<string> lines = new List<string>();
                string l = sr.ReadLine();
                while (!string.IsNullOrEmpty(l)) 
                {
                    lines.Add(l);
                    l = sr.ReadLine();
                }
                // Append new line to set
                lines.Add(report);
                
                // EVal overflow
                int maxRows = (int)(labelResult.Size.Height / labelResult.Font.GetHeight());
                int startAt = lines.Count - maxRows;
                if (startAt < 0) startAt = 0;
 
                // Rebuild label text
                labelResult.SuspendLayout();
                StringBuilder scrolledText = new StringBuilder();
                for (int ln = startAt; ln < lines.Count; ln++)
                    scrolledText.AppendLine(lines[ln]);
                labelResult.Text = scrolledText.ToString();
                labelResult.ResumeLayout();

            });
        }
        
        private void ClearResults()
        {
            labelResult.Text = string.Empty;
        }
        #endregion

    }
}
