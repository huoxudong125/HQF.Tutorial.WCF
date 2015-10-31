using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Broadcasting.Service.Interface;

namespace Broadcasting.Client
{
    public partial class Form1 : Form
    {
        private IBroadcastorService _client;
        public Form1()
        {
            InitializeComponent();
        }
        private delegate void HandleBroadcastCallback(object sender, EventArgs e);

        public void HandleBroadcast(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new HandleBroadcastCallback(HandleBroadcast), sender, e);
            }
            else
            {
                try
                {
                    var eventData = (EventDataType)sender;
                    if (this.txt_OhterClientMessage.Text != "")
                        this.txt_OhterClientMessage.Text += "\r\n";
                    this.txt_OhterClientMessage.Text += string.Format("{0} (from {1})",
                        eventData.EventMessage, eventData.ClientName);
                }
                catch (Exception ex)
                {
                }
            }
        }

        private  void RegisterClient()
        {
            if ((this._client != null))
            {
                (this._client as IClientChannel).Abort();
                this._client = null;
            }

            BroadcastorCallback cb = new BroadcastorCallback();
            cb.SetHandler(this.HandleBroadcast);

            InstanceContext context =new InstanceContext(cb);

            var proxy=new DuplexChannelFactory<IBroadcastorService>(context,"NetTcpBinding_IBroadcastorService");
            this._client = proxy.CreateChannel();
                

            this._client.RegisterClient(this.txt_ClientName.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txt_ClientName.Text == "")
            {
                MessageBox.Show(this, "Client Name cannot be empty");
                return;
            }
            this.RegisterClient();
        }

        private void btn_SendEvent_Click(object sender, EventArgs e)
        {
            if (this._client == null)
            {
                MessageBox.Show(this, "Client is not registered");
                return;
            }

            if (this.txt_message.Text == "")
            {
                MessageBox.Show(this, "Cannot broadcast an empty message");
                return;
            }

            this._client.NotifyServer(
                new EventDataType()
                {
                    ClientName = this.txt_ClientName.Text,
                    EventMessage = this.txt_message.Text
                });
        }
    }
}
