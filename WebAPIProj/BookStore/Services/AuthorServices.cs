using BookStore.DTOs;
using BookStore.Models;
using EntityLib;
using RepositoryLib;

namespace BookStore.Services
{
    public class AuthorServices : IAuthorServices
    {
        private IAuthorRepository _authorRepository;
        public AuthorServices(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<MessageResponse> Add(Author author)
        {
            string msg = await _authorRepository.AddAuthorAsync(author);
            MessageResponse msgr = new MessageResponse();
            if(!msg.Equals("Successful")){
                msgr.Status = false;
                msgr.Message = msg;
                return msgr;
            }
            msgr.Status=true;
            msgr.Message = "Document added successfully";
            return msgr;
        }

        public async Task<Author> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<MessageResponse> UpdateByName(string name, Address address)
        {
            MessageResponse msgr = new MessageResponse();
            string msg =await _authorRepository.UpdateByNameAsync(name,address);
            if(!msg.Equals("Successful")){
                msgr.Status = false;
                msgr.Message = msg;
                return msgr;
            }
            msgr.Status=true;
            msgr.Message = "Address updated successfully";
            return msgr;
        }

        public async Task<MessageResponse> UpdateById(string id, AuthorDTO ath)
        {
            MessageResponse msgr = new MessageResponse();
            Author author = ath;
            string msg =await _authorRepository.UpdateByIdAsync(id, author);
            if(!msg.Equals("Successful")){
                msgr.Status = false;
                msgr.Message = msg;
                return msgr;
            }
            msgr.Status=true;
            msgr.Message = "Document updated successfully";
            return msgr;
        }
    }
}