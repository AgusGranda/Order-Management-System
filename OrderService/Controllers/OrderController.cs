using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using OrderService.Services;
using OrderService.Tools;

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
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            try
            {
                var result = await _orderService.CreateOrder(order);

                if (result.Success)
                    return Ok(result.Data);

                else return BadRequest(result.Data);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
