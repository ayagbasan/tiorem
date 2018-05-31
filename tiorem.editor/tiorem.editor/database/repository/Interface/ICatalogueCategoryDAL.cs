using tiorem.editor.database.repository.Base;

namespace tiorem.editor.database.repository.Interface
{
    public interface ICatalogueCategoryDAL : IRepositoryBase<CatalogueCategory>
    {
        ApiResponse GetAllData(int id);
    }
}
