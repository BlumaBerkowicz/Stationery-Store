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
        private readonly MyStoreDBContext _AdoNetContext;
        public RatingRepository(MyStoreDBContext AdoNetContext)
        {
            _AdoNetContext = AdoNetContext;
        }
        public async Task Post(Rating rating)
        {
        }
    }
}
