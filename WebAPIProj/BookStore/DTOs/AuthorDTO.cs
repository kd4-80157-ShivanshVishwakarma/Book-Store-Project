using System.ComponentModel.DataAnnotations;
using EntityLib;

namespace BookStore.DTOs
{
    public class AuthorDTO
    {
        [Required]
        public string AuthorName { get; set; }

        [Required]
        public Address AuthorAddress { get; set; }

        public static implicit operator Author(AuthorDTO author){
            Author athor = new Author();
            athor.AuthorName = author.AuthorName;
            athor.AuthorAddress = author.AuthorAddress;
            return athor;
        }
    }
}