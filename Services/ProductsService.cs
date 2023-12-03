using Repository;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{

    public class ProductService : IProductService
    {
        private readonly IProductRepository _ProductRepository;
        public ProductService(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }


        public async Task<IEnumerable<Product>> GetAllProducts(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            return await _ProductRepository.GetAllProducts(desc, minPrice, maxPrice, categoryIds);
        }
    }
}

