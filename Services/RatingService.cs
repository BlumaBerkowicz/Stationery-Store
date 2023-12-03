using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{/// <summary>
/// /jjpo
/// </summary>
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }


        public async Task Post(Rating rating)
        {
            await _ratingRepository.Post(rating);
        }
    }
}
