using System;
using System.ServiceModel;
using System.Windows.Forms;

namespace HQF.Tutorial.WCF.Host.WinForm
{
    public partial class Form1 : Form
    {
        private bool _isRunning;
        private ServiceHost host;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!_isRunning)
            {
                host = new ServiceHost(typeof(HQF.Tutorial.WCF.Contract.CalculatorService));

                try
                {
                    host.Open();
                    textBox1.Text += string.Format("The Sever has started.") + Environment.NewLine;
                    _isRunning = true;
                    button1.Text = "Stop";
                }
                catch (Exception ex)
                {
                    textBox1.Text += string.Format("Error:{0}", ex.Message) + Environment.NewLine;
                }
            }
            else
            {
                try
                {
                    ((IDisposable)host).Dispose();
                    textBox1.Text += string.Format("The Sever has stopped.") + Environment.NewLine;
                    _isRunning = false;
                    button1.Text = "Start";
                }
                catch (CommunicationObjectFaultedException ex)
                {
                    // TODO: add code to log
                    textBox1.Text += string.Format("Error:{0}", ex.Message) + Environment.NewLine;
                }
            }
        }
    }
}