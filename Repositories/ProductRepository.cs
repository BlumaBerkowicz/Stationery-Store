using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AdoNetContext _DbContext;
        public ProductRepository(AdoNetContext dbContext)
        {
            _DbContext = dbContext;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _DbContext.Products.ToListAsync();
        }
    }
}
