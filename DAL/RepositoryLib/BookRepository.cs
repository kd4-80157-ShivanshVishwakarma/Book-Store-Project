using EntityLib;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace RepositoryLib
{
    public class BookRepository : IBookRepository
    {
        private IMongoCollection<Book> _books;
        public BookRepository(IMongoClient client,IOptions<MongoDBSettings> settings)
        {
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _books = database.GetCollection<Book>("Book");
        }
        
        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _books.Find(_=> true).ToListAsync();
        }

        public async Task<string> AddBookAsync(Book book)
        {
            try
            {
                await _books.InsertOneAsync(book);
                return "Successful";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Task<Book> GetByIsbnAsync(string isbn)
        {
            return _books.Find(bk => bk.Isbn == isbn).FirstOrDefaultAsync();
        }

        public Task<List<Book>> GetByAuthorAsync(string authr)
        {
            return _books.Find(b=> b.Authors.Any(a=> a.Equals(authr))).ToListAsync();
        }

        public async Task<bool> UpdateByIsbnAsync(string isbn, Book book)
        {
            try
            {
                var buk = Builders<Book>.Filter.Eq(bk=> bk.Isbn,isbn);
                var updateBook = Builders<Book>.Update
                .Set(bk=> bk.Title,book.Title)
                .Set(bk=> bk.Authors,book.Authors)
                .Set(bk=> bk.Price,book.Price)
                .Set(bk=> bk.Description,book.Description)
                .Set(bk=> bk.Publisher,book.Publisher);

                var res =await _books.UpdateOneAsync(buk, updateBook);
                return res.ModifiedCount>0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}