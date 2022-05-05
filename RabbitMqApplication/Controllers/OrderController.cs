using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RabbitMqApplication.Models;

namespace RabbitMqApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;

        public OrderController(IBus bus, IConfiguration configuration)
        {
            _bus = bus;
            _configuration = configuration;
        }
        
        [HttpPost("send-order")]
        public async Task<IActionResult> CreateOrder()
        {
            Order order = new Order()
            {
                Id = 1,
                ProductName = "Computer"
            };
            
            Uri uri = new Uri("rabbitmq:localhost/order-queue");

            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(order);

            return Ok("Success");
        }
    }
}