using tiorem.editor.business;
using tiorem.editor.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tiorem.editor
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 

            try
            {
                if (Application["TheException"] != null)
                {
                    Exception ex = (Exception)Application["TheException"];
                    mesaj1.Text = ex.InnerException != null ? ex.InnerException.Message + "<br/>" : "";
                    mesaj2.Text = ex.Message;
                  

                    string ip = GetUser_IP();
                    string bilgi =
                        @"Hata Sayfası: " + Application["Sayfa"] + "\r\n" +
                        "IP adresi: " + ip + "\r\n" +
                        "Kullanıcı Adı: " + HttpContext.Current.Request.LogonUserIdentity.Name + "\r\n" +
                        "Zaman: " + DateTime.Now.ToString("dd.MM.yyyy,dddd HH:mm");

                    HyperLink1.NavigateUrl = "mailto:ayagbasan@eximbank.gov.tr&cc=ecevik@eximbank.gov.tr&subject=Hata Mesajı | EXIMPANEL&body=" + bilgi + "\r\n\r\n\r\n" +
                        mesaj1.Text + "-----" + mesaj2.Text;

                    HyperLink2.NavigateUrl =Application["Sayfa"].ToString();

                    
                }
                else
                {
                    //Response.Redirect("pages/rapor/raporlar.aspx");
                }
            }
            catch (Exception ex)
            {
                mesaj1.Text = ex.Message.ToString();
                mesaj2.Text = ex.InnerException.ToString();
               
            }
        }

        string GetUser_IP()
        {
            string VisitorsIPAddr = string.Empty;
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
            {
                VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress;
            }
            return VisitorsIPAddr;
        }
    }
}