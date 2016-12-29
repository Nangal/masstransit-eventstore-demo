using System.Threading.Tasks;
using Contracts.Commands;
using Contracts.Notifications;
using MassTransit;

namespace Consumer
{
    public class DeposantConsumer : IConsumer<CreateDeposant>
    {
        public Task Consume(ConsumeContext<CreateDeposant> context)
        {
            var command = context.Message;

            context.Publish<DeposantCreatedNotification>(new
            {
                Title = "Deposant",
                Message = $"Deposant with ID {command.Id} created",
                Type = "success" 
            });
          
            return Task.FromResult(0);
        }
    }
}
