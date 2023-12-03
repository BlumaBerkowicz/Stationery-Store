using Repository;

namespace Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> PostOrder(Order order);
    }
}