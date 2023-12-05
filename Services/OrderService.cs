using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.Extensions.Logging;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger _logger;
        public OrderService(IOrderRepository orderRepository,IProductRepository productRepository,ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _orderRepository.GetAllOrders();
        }

        public async Task<Order> PostOrder(Order order)
        {
            int sum=0;
            Product product;
            foreach (OrderItem OrderItem in order.OrderItems)
            {
                product = await _productRepository.GetProductsById(OrderItem.ProductId);
                sum += (int)product.Price;
            }
            if(sum!= order.OrderSum)
            {
                _logger.LogError($"user {order.UserId}  tried perchasing with a difffrent price {order.OrderSum} instead of{sum}");
                _logger.LogInformation($"user {order.UserId}  tried perchasing with a difffrent price {order.OrderSum} instead of{sum}");
            }
            order.OrderSum = sum;
            order.OrderDate = DateTime.Now;
            return await _orderRepository.PostOrder(order);
        }

    }
}

