using EntityLib;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace RepositoryLib
{
    public class CustomerRepository: ICustomerRepository
    {
        private IMongoCollection<Customer> _customers;
        public CustomerRepository(IMongoClient client,IOptions<MongoDBSettings> options)
        {
            var database = client.GetDatabase(options.Value.DatabaseName);
            _customers = database.GetCollection<Customer>("Customer");
        }

        public async Task<Customer> GetByIdAsync(string id)
        {
            var customer = await _customers.Find(c => c.CustomerId.Equals(id)).FirstOrDefaultAsync();
            return customer;
        }
    }
}