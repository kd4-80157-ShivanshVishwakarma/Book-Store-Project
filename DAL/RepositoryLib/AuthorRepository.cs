using EntityLib;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace RepositoryLib
{
    public class AuthorRepository : IAuthorRepository
    {
        private IMongoCollection<Author> _authors;
        public AuthorRepository(IMongoClient client,IOptions<MongoDBSettings> options)
        {
            var database = client.GetDatabase(options.Value.DatabaseName);
            _authors = database.GetCollection<Author>("Author");
        }
        public async Task<string> AddAuthorAsync(Author author)
        {
            try
            {
                await _authors.InsertOneAsync(author);
                return "Successful";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Task<List<Author>> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateByIdAsync(string id, Author author)
        {
            try
            {
                string msg = "Successful";
                var athr = Builders<Author>.Filter.Eq(a => a.AuthorId,id);
                var updatedAuthr = Builders<Author>.Update
                .Set(a => a.AuthorName,author.AuthorName)
                .Set(a => a.AuthorAddress,author.AuthorAddress);

                var res =await _authors.UpdateOneAsync(athr, updatedAuthr);
                bool flag = res.MatchedCount>0 || res.ModifiedCount>0;
                if(flag){
                    return msg;
                }
                return "Not "+msg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> UpdateByNameAsync(string name, Address address)
        {
            try
            {
                string msg = "Successful";
                var filteredAuthor = Builders<Author>.Filter.Eq(a => a.AuthorName, name);
                var updatedAuthor = Builders<Author>.Update
                .Set(a=> a.AuthorAddress.Country,address.Country)
                .Set(a=> a.AuthorAddress.State,address.State)
                .Set(a => a.AuthorAddress.PostalCode,address.PostalCode);
                
                var res = await _authors.UpdateOneAsync(filteredAuthor,updatedAuthor);
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