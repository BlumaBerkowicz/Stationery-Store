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
        private readonly AdoNetContext _adoNetContext;
        public ProductRepository(AdoNetContext adoNetContext)
        {
            _adoNetContext = adoNetContext;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _adoNetContext.Products.ToListAsync();
        }
    }
}
