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
    public class OrderRepository : IOrderRepository
    {
        private readonly MyStoreDbContext _MyStoreDbContext;
        public OrderRepository(MyStoreDbContext MyStoreDbContext)
        {
            _MyStoreDbContext = MyStoreDbContext;
        }
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _MyStoreDbContext.Orders.ToListAsync();
        }

        public async Task<Order> PostOrder(Order order)
        {
            await _MyStoreDbContext.Orders.AddAsync(order);
           await _MyStoreDbContext.SaveChangesAsync();
          
            return order;
        }
    }
}
