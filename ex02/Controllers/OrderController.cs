using AutoMapper;
using Dto;
using Repository;
using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;

namespace ex02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;

        }


        // GET api/<RegisterAndLogin>/5
        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            return await _orderService.GetAllOrders();
            
        }

        // POST api/<RegisterAndLogin>
        [HttpPost]
        public async Task<ActionResult<OrderDto>> Post([FromBody] OrderDto orderDto)
        {
            try
            {
                Order new_order = _mapper.Map<OrderDto, Order>(orderDto);
                Order order = await _orderService.PostOrder(new_order);
                OrderDto orderDto1 = _mapper.Map<Order, OrderDto>(order);
                return orderDto1;
            }
            catch (Exception e)
            { throw (e); }


        }
    }
}

