using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly MyStoreDbContext _MyStoreDbContext;
        public RatingRepository(MyStoreDbContext MyStoreDbContext)
        {
            _MyStoreDbContext = MyStoreDbContext;
        }
        public async Task Post(Rating rating)
        {
            await _MyStoreDbContext.Ratings.AddAsync(rating);
            await _MyStoreDbContext.SaveChangesAsync();
        }
    }
}
