using EntityLib;

namespace RepositoryLib
{
    public interface IOrderRepository
    {
        Task<string> AddOrderAsync(Order order);
    }
}