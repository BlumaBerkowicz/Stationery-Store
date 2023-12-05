using Entities;

namespace Repository
{
    public interface IRatingRepository
    {
        Task Post(Rating rating);
    }
}

