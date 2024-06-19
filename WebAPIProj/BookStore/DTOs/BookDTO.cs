using System.ComponentModel.DataAnnotations;
using EntityLib;

namespace BookStore.DTOs
{
    public class BookDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public List<string> Authors { get; set; }
        [Required]
        public int Price { get; set; }
        [Required] 
        public string? Description { get; set; }
        [Required]
        public string? Publisher { get; set; }

        public static implicit operator Book(BookDTO bdto){
            Book book = new Book();
            book.Title = bdto.Title;
            book.Authors = bdto.Authors;
            book.Price = bdto.Price;
            book.Description = bdto.Description;
            book.Publisher = bdto.Publisher;
            return book;
        }

    }
}