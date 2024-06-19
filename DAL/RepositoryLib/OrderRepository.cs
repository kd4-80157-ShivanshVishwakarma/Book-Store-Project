using EntityLib;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace RepositoryLib
{
    public class OrderRepository : IOrderRepository
    {
        private IMongoCollection<Order> _orders;
        public OrderRepository(IMongoClient client,IOptions<MongoDBSettings> options)
        {
            var database = client.GetDatabase(options.Value.DatabaseName);
            _orders = database.GetCollection<Order>("Order");
        }

        public async Task<string> AddOrderAsync(Order order)
        {
            try
            {
                await _orders.InsertOneAsync(order);
                return "Successful";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}