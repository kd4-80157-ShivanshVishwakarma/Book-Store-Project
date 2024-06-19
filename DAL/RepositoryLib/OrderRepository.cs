using System.Collections.Generic;
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

        public async Task<List<Order>> GetAllAsync()
        {
            List<Order> orderList =  await _orders.Find(_=>true).ToListAsync();
            return orderList;
        }

        public async Task<string> UpdateByDateAsync(DateTime date, bool status)
        {
            try
            {
                string msg = "Successful";
                var filteredOrder = Builders<Order>.Filter.Eq(o=> o.OrderDate,date);
                var updatedOrder = Builders<Order>.Update.Set(o=> o.Status,status);

                var res =await _orders.UpdateManyAsync(filteredOrder,updatedOrder);
                bool flag = res.MatchedCount>0 || res.ModifiedCount>0;
                if(flag){
                    return msg;
                }
                return "Not "+msg;
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }
    }
}