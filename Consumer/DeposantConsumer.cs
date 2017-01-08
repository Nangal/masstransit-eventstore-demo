using System.Threading.Tasks;
using Contracts.Commands;
using Contracts.Notifications;
using Domain.Services.Deposant;
using MassTransit;

namespace Consumer
{
    public class DeposantConsumer : IConsumer<CreateDeposant>
    {
        private readonly IDeposantService _deposantService;

        public DeposantConsumer(IDeposantService deposantService)
        {
            _deposantService = deposantService;
        }

        public Task Consume(ConsumeContext<CreateDeposant> context)
        {
            var number = _deposantService.GenerateDeposantNummer();
            var command = new Domain.Contracts.Commands.CreateDeposant
            {
                DeposantNummer = number
            };
            
            var id =_deposantService.When(command);

            context.Publish<DeposantCreatedNotification>(new
            {
                Title = "Deposant",
                Message = $"Deposant with ID {id} and number {number} created",
                Type = "success"
            });

            return Task.FromResult(0);
        }
    }
}
