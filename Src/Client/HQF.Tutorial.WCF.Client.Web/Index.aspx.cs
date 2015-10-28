using HQF.Tutorial.WCF.Client.Web.Service;
using System;

namespace HQF.Tutorial.WCF.Client.Web
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBoxA.Text = "2";
                TextBoxB.Text = "3";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var client = new CalculatorServiceClient())
                {
                    int a = int.Parse(TextBoxA.Text);
                    int b = int.Parse(TextBoxB.Text);
                    var c = client.Add(a, b);
                    TextBoxC.Text = c.ToString();

                    Response.Write(string.Format("{0}+{1}={2}", a, b, c));
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
           
        }
    }
}