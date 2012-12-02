using Converge.Model;
using MassTransit;
using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace WinFormsTest
{
    public partial class ConnectForm : Form
    {
        private Func<ConnectForm, bool> validator;
        
        public string AppName { get { return textBoxAppName.Text; } }
        public string NodeId { get { return textBoxNodeGuid.Text; } }
        public string Host { get { return textBoxServerHost.Text; } }

        public ConnectForm()
        {
            InitializeComponent();
        }

        private void ConnectForm_Load(object sender, EventArgs e)
        {
            // Fetch last used settings
            //NewNodeId();
            textBoxNodeGuid.Text = "nodiz";
            textBoxAppName.Text = "rabbers";
            textBoxServerHost.Text = "localhost";
        }

        private void setRandomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewNodeId();
        }

        private void NewNodeId()
        {
            textBoxNodeGuid.Text = Guid.NewGuid().ToString();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Close();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void labelFormHeader_MouseDown(object sender, MouseEventArgs e)
        {
            //int dx = e.Location.X - this.Location.X;
            //int dy = e.Location.Y - this.Location.Y;

            //System.Func<System.Drawing.Point, System.Drawing.Point> mlocToFormLoc = ml => 
            //    new System.Drawing.Point 
            //        {
            //            X = ml.X + dx,
            //            Y = ml.Y + dy
            //        };
                
            //var currentPos = e.Location;
            //var moveEvents = Observable.FromEventPattern<MouseEventArgs>(this, "MouseMove");
            //moveEvents.SubscribeOn(Scheduler.CurrentThread).Subscribe(ep =>
            //    {
            //        this.Location = mlocToFormLoc(ep.EventArgs.Location);
            //    });
        }
    }
}
