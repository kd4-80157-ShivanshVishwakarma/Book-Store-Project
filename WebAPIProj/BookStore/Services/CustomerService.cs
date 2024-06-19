using EntityLib;
using RepositoryLib;

namespace BookStore.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> GetById(string id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }
    }
}