using BookStore.Services;
using EntityLib;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    public class CustomerController
    {
        private readonly ICustomerService _service;
        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("/user/{id}/get")]
        public async Task<Customer> GetCustById(string id){
            return await _service.GetById(id);
        }
    }
}