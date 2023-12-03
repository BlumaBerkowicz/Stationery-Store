using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly AdoNetContext _AdoNetContext;
        public RatingRepository(AdoNetContext AdoNetContext)
        {
            _AdoNetContext = AdoNetContext;
        }
        public async Task Post(Rating rating)
        {
            return;
        }
    }
}
