using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tiorem.editor.database;
using tiorem.editor.database.repository.Base;

namespace tiorem.editor.business
{
    public class CacheBL
    {
        static CacheBL instance;
        public static CacheBL GetInstance()
        {
            return instance ?? (new CacheBL());
        }

        public void RefreshCahce()
        {
            try
            {
                LoadCategory();
            LoadTags();
            LoadSource();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void LoadCategory()
        {
            try
            {
                IRepositoryBase<CatalogueCategory> repo = new RepositoryBase<CatalogueCategory>();
                Global.catalogueCategories = repo.GetList(p => p.Active).OrderBy(p => p.CategoryName).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LoadTags()
        {
            try
            {
                IRepositoryBase<CatalogueTag> repo = new RepositoryBase<CatalogueTag>();
                Global.catalogueTags = repo.GetList(p => p.Active).OrderBy(p => p.TagName).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
        public void LoadSource()
        {
            try
            {
                IRepositoryBase<CatalogueSource> repo = new RepositoryBase<CatalogueSource>();
                Global.catalogueSources = repo.GetList(p => p.Active).OrderBy(p => p.Name).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
    }
}