using OrderService.Data;
using OrderService.Models;
using OrderService.Repository;
using OrderService.Tools;

namespace OrderService.Services
{

    public interface IOrderService
    {
        Task<OperationResult<Order>> CreateOrder(Order order); 
    }


    public class OrderServiceImp : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly OrderDbContext _dbContext;
        public OrderServiceImp( IOrderRepository orderRepository, OrderDbContext dbContext) 
        {
            _orderRepository = orderRepository;
            _dbContext = dbContext;
        }


        public async Task<OperationResult<Order>> CreateOrder(Order order)
        {
            try
            {
                if (order.Quantity <= 0)
                    return OperationResult<Order>.Fail("Quantity must be greater than 0");
                
                _orderRepository.CreateOrder(order);
                await _dbContext.SaveChangesAsync();
                return OperationResult<Order>.Ok(order);

            }
            catch (Exception)
            {

                throw;
            }



        }




    }
}
