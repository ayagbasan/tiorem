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
    public partial class main : System.Web.UI.MasterPage
    {

        public static User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            litMesaj.Text = "";
            if (!IsPostBack)
            {
                GetSORUMLU();
            }


        }



        public User GetSORUMLU()
        {
            try
            {
                user = BusinessBL.GetInstance().GetUser("admin");
                return user;
                
                    
            }
            catch (Exception ex)
            {
                litMesaj.Text = BusinessBL.GetInstance().GetHataMesaj(ex.InnerException.Message);
                return null;
            }
        }


    }
}