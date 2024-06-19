using BookStore.Models;
using EntityLib;

namespace BookStore.Services
{
    public interface IOrderService
    {
        Task<MessageResponse> Add(Order orders);
    }
}