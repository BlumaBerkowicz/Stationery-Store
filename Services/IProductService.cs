using Repository;

namespace Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}