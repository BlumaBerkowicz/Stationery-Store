using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ex02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        // GET api/<RegisterAndLogin>/5
        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            return await _orderService.GetAllOrders();
            //להחזיר מה סוג הפעולה מה הסטטוס
        }

        // POST api/<RegisterAndLogin>
        [HttpPost]
        public async Task<CreatedAtActionResult> Post([FromBody] Order order)
        {
            try
            {
                Order new_order = await _orderService.PostOrder(order);
                return CreatedAtAction(nameof(Get), new { id = order.OrderId }, order);
            }
            catch (Exception e)
            { throw (e); }


        }
    }
}

