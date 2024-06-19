using BookStore.DTOs;
using BookStore.Models;
using EntityLib;

namespace BookStore.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooks();
        Task<MessageResponse> Add(Book book);
        Task<Book> GetByIsbn(string isbn);
        Task<List<Book>> GetByAuthor(string author);
        Task<MessageResponse> UpdateByIsbn(string isbn,BookDTO book);
    }
}