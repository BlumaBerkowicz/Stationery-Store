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
        private readonly AdoNetContext _AdoNetContext;
        public OrderRepository(AdoNetContext AdoNetContext)
        {
            _AdoNetContext = AdoNetContext;
        }
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _AdoNetContext.Orders.ToListAsync();
        }

        public async Task<Order> PostOrder(Order order)
        {
            _AdoNetContext.AddAsync(order);
            _AdoNetContext.SaveChangesAsync();
          
            return order;
        }
    }
}
