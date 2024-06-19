using EntityLib;

namespace RepositoryLib
{
    public interface IAuthorRepository
    {
        Task<string> AddAuthorAsync(Author author);
        Task<List<Author>> GetByIdAsync(string id);
        Task<string> UpdateByIdAsync(string id,Author author);
        Task<string> UpdateByNameAsync(string name,Address address);

    }
}