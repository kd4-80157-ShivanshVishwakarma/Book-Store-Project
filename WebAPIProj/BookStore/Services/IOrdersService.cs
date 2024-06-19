using BookStore.Models;
using EntityLib;

namespace BookStore.Services
{
    public interface IOrderService
    {
        Task<MessageResponse> Add(Order orders);
        Task<MessageResponse> UpdateByDate(DateTime date,bool status);
        Task<List<Order>> GetAll();
    }
}