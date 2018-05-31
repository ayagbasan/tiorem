using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tiorem.editor.database;
using tiorem.editor.database.repository.Base;

namespace tiorem.editor.uc
{
    public partial class ucArticleSummary : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    DateTime date = DateTime.Now.AddHours(-6);
            //    efArticleSummary.WhereParameters[0].DefaultValue = date.ToString();
            //}

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void gridArticleSummary_Init(object sender, EventArgs e)
        {
            BindGrid();
        }

        void LoadData()
        {
            DateTime date = DateTime.Now.AddHours(-6);
            var data = new RepositoryBase<VW_ARTICLE_SUMMARY>().GetList(p => p.InsertedAt > date).ToList();
            Session["Data"] = data;
            BindGrid();
        }

        void BindGrid()
        {
            if(Session["Data"]!=null)
            {
                gridArticleSummary.DataSource = Session["Data"];
                gridArticleSummary.DataBind();
            }
            else
            {

            }
        }
    }
}