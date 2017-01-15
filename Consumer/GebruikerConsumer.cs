using System.Threading.Tasks;
using Contracts.Commands;
using Contracts.Notifications;
using MassTransit;

namespace Consumer
{
    public class GebruikerConsumer : IConsumer<CreateGebruiker>
    {
        public Task Consume(ConsumeContext<CreateGebruiker> context)
        {
            var command = context.Message;

            context.Publish<GebruikerCreatedNotification>(new
            {
                Title = "Gebruiker",
                Message = $"Gebruiker with ID {command.Id} created",
                Type = "success"
            });

            return Task.FromResult(0);
        }
    }
}
