using System;
using System.ServiceModel;

namespace HQF.Tutorial.WCF.Client.Web
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ClientBase<CalculatorService> client = null;
            try
            {
                client = new CalculatorServiceClient();
                var proxy = client as CalculatorServiceClient;

                Response.Write(string.Format("<br/> x + y = {2} when x = {0} and y = {1}", 1, 2, proxy.Add(1, 2)));
                Response.Write(string.Format("<br/> x - y = {2} when x = {0} and y = {1}", 1, 2, proxy.Subtract(1, 2)));
                Response.Write(string.Format("<br/> x * y = {2} when x = {0} and y = {1}", 1, 2, proxy.Multiply(1, 2)));
                Response.Write(string.Format("<br/> x / y = {2} when x = {0} and y = {1}", 1, 2, proxy.Divide(1, 2)));

                Response.Write("<br/> Ok.");
            }
            catch (CommunicationException e1)
            {
                if (client != null) client.Abort();
                Response.Write("Error.\n" + e1.Message);
            }
            catch (TimeoutException e2)
            {
                if (client != null) client.Abort();
                Response.Write("Error.\n" + e2.Message);
            }
            catch (Exception ex)
            {
                if (client != null) client.Abort();
                Response.Write("Error.\n" + ex.Message);
                Console.WriteLine("Error :\n {0}", ex.Message);
            }
            finally
            {
                var tempProxy = client as IDisposable;
                if (tempProxy != null)
                {
                    tempProxy.Dispose();
                }
            }
        }
    }
}