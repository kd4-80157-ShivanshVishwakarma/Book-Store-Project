using BookStore.Models;
using EntityLib;
using RepositoryLib;

namespace BookStore.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        public OrderService(IOrderRepository ordersRepository,ICustomerRepository customerRepository)
        {
            _orderRepository = ordersRepository;
            _customerRepository = customerRepository;
        }

        public async Task<MessageResponse> Add(Order order)
        {
            MessageResponse msgr = new MessageResponse();
            Customer cust =await _customerRepository.GetByIdAsync(order.CustomerId);
            // Null checking here
            if(cust==null){
                msgr.Status = false;
                msgr.Message = "Customer does not exist.";
                return msgr;
            }
            string msg = await _orderRepository.AddOrderAsync(order);
            if (!msg.Equals("Successful"))
            {
                msgr.Status = false;
                msgr.Message = msg;
                return msgr;
            }
            msgr.Status = true;
            msgr.Message = "Order inserted successfully";
            return msgr;
        }
    }
}