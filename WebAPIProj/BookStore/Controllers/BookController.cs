using BookStore.Models;
using BookStore.Services;
using EntityLib;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService _service;
        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("/books/getall")]
        public async Task<List<Book>> GetAll(){
            return await _service.GetAllBooks();
        }

        [HttpGet]
        [Route("/book/getbyisbn/{isbn}")]
        public async Task<Book> GetBookByIsbn(string isbn){
            return await _service.GetByIsbn(isbn);
        }

        [HttpGet]
        [Route("/book/getbyauthor/{author}")]
        public async Task<List<Book>> GetBooksByAuthor(string author){
            return await _service.GetByAuthor(author);
        }

        [HttpPost]
        [Route("/book/add")]
        public async Task<IActionResult> AddBook(Book book){
            MessageResponse msgr = await _service.Add(book);
            return Ok(msgr);
        }

        [HttpPut]
        [Route("/book/updatebyisbn/{isbn}")]
        public async Task<IActionResult> UpdateBookByIsbn(string isbn, Book book){
            MessageResponse msg = await _service.UpdateByIsbn(isbn, book);
            return Ok(msg);
        }

    }
}