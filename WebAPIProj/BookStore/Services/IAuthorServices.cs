using BookStore.DTOs;
using BookStore.Models;
using EntityLib;

namespace BookStore.Services
{
    public interface IAuthorServices
    {
        Task<MessageResponse> Add(Author author);
         Task<Author> GetById(string id);
        Task<MessageResponse> UpdateById(string id,AuthorDTO book);
        Task<MessageResponse> UpdateByName(string name,Address address);
    }
}