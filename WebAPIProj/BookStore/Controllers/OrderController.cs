using System.Text.Json;
using BookStore.Models;
using BookStore.Services;
using EntityLib;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("/order/add")]
        public async Task<string> AddOrder(Order order){
            MessageResponse res = await _service.Add(order);
            return JsonSerializer.Serialize(res);
        }

        [HttpGet]
        [Route("/order/getall")]
        public async Task<IEnumerable<Order>> GetAllOrder(){
            return await _service.GetAll();
        }

        [HttpPatch]
        [Route("/order/{date}/update")]
        public async Task<IActionResult> UpdateOrderStatus(string date,bool status){
            DateTime orderDate;
            if (!DateTime.TryParse(date, out orderDate))
            {
                return BadRequest("Invalid date format");
            }

            MessageResponse updateResult = await _service.UpdateByDate(orderDate, status);
            return Ok(updateResult);

        }
    }
}