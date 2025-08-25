using OrderService.Data;
using OrderService.Models;

namespace OrderService.Repository
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
    public class OrderRepository:IOrderRepository
    {

        private OrderDbContext _dbContext;
        public OrderRepository(OrderDbContext dbcontext) 
        {
            _dbContext = dbcontext;
        }


        public void CreateOrder(Order order)
        {
             _dbContext.Add(order);

        }
    }
}
