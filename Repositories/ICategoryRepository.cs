using Repository;

namespace Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
    }
}