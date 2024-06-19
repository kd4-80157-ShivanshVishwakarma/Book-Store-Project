using System.Text.Json;
using BookStore.DTOs;
using BookStore.Models;
using BookStore.Services;
using EntityLib;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;

namespace BookStore.Controllers
{
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IAuthorServices _services;
        public AuthorController(IAuthorServices services)
        {
            _services = services;
        }

        [HttpPost]
        [Route("/author/add")]
        public async Task<string> AddAuthor(Author author){
           MessageResponse msg =await _services.Add(author);
           return JsonSerializer.Serialize(msg);
        }
        
        [HttpPut]
        [Route("/author/update/{id}")]
        public async Task<string> UpdateAuthorById(string id,AuthorDTO authorDTO){
            MessageResponse msg = await _services.UpdateById(id,authorDTO);
            return JsonSerializer.Serialize(msg);
        }

        [HttpPatch]
        [Route("/author/{name}/address")]
        public async Task<string> UpdateAddressByName(string name,Address address){
            MessageResponse msg = await _services.UpdateByName(name,address);
            return JsonSerializer.Serialize(msg);
        }

    }
}