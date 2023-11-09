using Entities;
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


            public async Task<IEnumerable<Product>> GetAllProducts()
            {
                return await _ProductRepository.GetAllProducts();
            }
        }
    }

