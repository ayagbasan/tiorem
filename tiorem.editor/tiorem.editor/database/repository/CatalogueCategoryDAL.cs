using tiorem.editor.database.repository.Base;
using tiorem.editor.database.repository.Interface;

namespace tiorem.editor.database.repository
{
    public class CatalogueCategoryDAL : RepositoryBase<CatalogueCategory>, ICatalogueCategoryDAL
    {
        private ICatalogueCategoryDAL context;
        
        public ApiResponse GetAllData(int id)
        {
            try
            {
                return null;

            }
            catch (System.Exception ex)
            {
                return new ApiResponse(aymkError.GetError, "aymk_api.database.account", ex);
            }
        }


    }
}
