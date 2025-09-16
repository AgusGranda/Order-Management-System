using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using OrderService.Services;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) 
        {
            _orderService = orderService;
        }



        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            try
            {
                var result = await _orderService.CreateOrder(order);

                if (result.Success)
                    return Ok(result.Data);

                return BadRequest(result.Message);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
