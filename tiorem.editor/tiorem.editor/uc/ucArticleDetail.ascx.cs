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
    public partial class ucArticleDetail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               
                
            }
        }

        public void LoadData(long articleId)
        {
            List<string> includes = new List<string>();
            includes.Add("CatalogueCategory");
            includes.Add("CatalogueSource");
            includes.Add("ArticleTag");
            includes.Add("User");
            Article article = new RepositoryBase<Article>().Get(p => p.Id == articleId, includes);
            List<Article> data = new List<Article>();
            data.Add(article);
            frmArticle.DataSource = data;
            frmArticle.DataBind();
        }
    }
}