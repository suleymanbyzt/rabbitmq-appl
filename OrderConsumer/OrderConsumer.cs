using System.Threading.Tasks;
using MassTransit;
using OrderConsumer.Models;

namespace OrderConsumer
{
    public class OrderConsumer : IConsumer <Order>
    {
        public async Task Consume(ConsumeContext<Order> context)
        {
            Order order = context.Message;
        }
    }
}