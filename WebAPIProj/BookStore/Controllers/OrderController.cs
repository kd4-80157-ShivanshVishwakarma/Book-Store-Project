using System.Text.Json;
using BookStore.Models;
using BookStore.Services;
using EntityLib;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    public class OrderController
    {
        private readonly IOrderService _service;
        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("/orders/add")]
        public async Task<string> AddOrder(Order order){
            MessageResponse res = await _service.Add(order);
            return JsonSerializer.Serialize(res);
        }
    }
}