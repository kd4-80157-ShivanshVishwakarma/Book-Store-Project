using System.Collections;
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

        public async Task<MessageResponse> UpdateByIsbn(string isbn,Book book)
        {
            MessageResponse msg = new MessageResponse();
            bool flag = await _bookRepository.UpdateByIsbnAsync(isbn, book);
            if(flag){
                msg.Status = true;
                msg.Message = "Document successfully updated";
                return msg;
            }
            msg.Status = false;
            msg.Message = "Document not updated";
            return msg;
        }
    }
}