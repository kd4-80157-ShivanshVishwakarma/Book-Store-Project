using System.Collections;
using BookStore.DTOs;
using BookStore.Models;
using EntityLib;
using RepositoryLib;

namespace BookStore.Services
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;            
        }
        public async Task<List<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAllBooksAsync();
        }

        public async Task<MessageResponse> Add(Book book)
        {
            string msg = await _bookRepository.AddBookAsync(book);
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

        public async Task<Book> GetByIsbn(string isbn)
        {
            Book bk = await _bookRepository.GetByIsbnAsync(isbn);
            return bk;
        }

        public async Task<List<Book>> GetByAuthor(string author)
        {
           return await _bookRepository.GetByAuthorAsync(author);
        }

        public async Task<MessageResponse> UpdateByIsbn(string isbn,BookDTO book)
        {
            Book book1 = book;
            MessageResponse msgr = new MessageResponse();
            string msg = await _bookRepository.UpdateByIsbnAsync(isbn, book1);
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