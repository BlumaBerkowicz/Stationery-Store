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

        private readonly MyStoreDbContext _MyStoreDbContext;
        public CategoryRepository(MyStoreDbContext MyStoreDbContext)
        {
            _MyStoreDbContext = MyStoreDbContext;
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _MyStoreDbContext.Categories.ToListAsync();
        }
    }
}
