using EntityLib;

namespace RepositoryLib
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync( string id);
    }
}