using Repository;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AdoNetContext _adoNetContext;
        public ProductRepository(AdoNetContext adoNetContext)
        {
            _adoNetContext = adoNetContext;
        }
        public async Task<IEnumerable<Product>> GetAllProducts(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            var query = _adoNetContext.Products.Where(product =>
            (desc == null ? (true) : (product.Description.Contains(desc)))
            && ((minPrice == null) ? (true) : (product.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
            && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))))
                .OrderBy(product => product.Price);
            List<Product> products = await query.ToListAsync();
            return products;


        }
    }
}
