using EntityLib;

namespace BookStore.Services
{
    public interface ICustomerService
    {
        Task<Customer> GetById(string id);
    }
}