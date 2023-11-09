using Entities;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> PostOrder(Order order);
    }
}