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
    public class CategoryRepository : ICategoryRepository
    {

        private readonly MyStoreDBContext _AdoNetContext;
        public CategoryRepository(MyStoreDBContext AdoNetContext)
        {
            _AdoNetContext = AdoNetContext;
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _AdoNetContext.Categories.ToListAsync();
        }
    }
}
