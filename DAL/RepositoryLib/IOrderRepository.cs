using EntityLib;

namespace RepositoryLib
{
    public interface IOrderRepository
    {
        Task<string> AddOrderAsync(Order order);
        Task<List<Order>> GetAllAsync();
        Task<string> UpdateByDateAsync(DateTime date,bool status);
    }
}