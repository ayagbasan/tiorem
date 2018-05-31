using tiorem.editor.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using tiorem.editor.business;

namespace tiorem.editor
{
    public class Global : System.Web.HttpApplication
    {

        public static List<CatalogueCategory> catalogueCategories;
        public static List<CatalogueTag> catalogueTags;
        public static List<CatalogueSource> catalogueSources;


        protected void Application_Start(object sender, EventArgs e)
        {
            try
            {
                CacheBL.GetInstance().RefreshCahce();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {




        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            Application["Sayfa"] = Server.UrlEncode(Request.RawUrl);
            Application["TheException"] = ex; //store the error for later
            Server.ClearError(); //clear the error so we can continue onwards
            Response.Redirect("~/Error.aspx"); //direct user to error page
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}