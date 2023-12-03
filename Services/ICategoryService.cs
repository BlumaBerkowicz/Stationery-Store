using Repository;
using Entities;


namespace Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
    }
}