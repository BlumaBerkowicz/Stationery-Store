using Entities;

namespace Services
{
    public interface IRatingService
    {
        Task Post(Rating rating);
    }
}