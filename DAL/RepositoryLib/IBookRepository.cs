using EntityLib;

namespace RepositoryLib
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<string> AddBookAsync(Book book);
        Task<Book> GetByIsbnAsync(string isbn);
        Task<List<Book>> GetByAuthorAsync(string isbn);
        Task<bool> UpdateByIsbnAsync(string isbn,Book book);
    }
}