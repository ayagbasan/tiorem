using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tiorem.editor.business;
using tiorem.editor.database;
using tiorem.editor.database.repository.Base;

namespace tiorem.editor
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void cp_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            string methodName = e.Parameter.Split(':')[0];
            string param = e.Parameter.Split(':')[1];

            if(methodName== "GetArticleDetails")
            {
                long articleId = Convert.ToInt64(param);
                ucArticleDetail.LoadData(articleId);
            }
        }
    }
}