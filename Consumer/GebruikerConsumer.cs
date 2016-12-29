using System;
using System.Threading.Tasks;
using Contracts.Commands;
using MassTransit;

namespace Consumer
{
    public class GebruikerConsumer : IConsumer<CreateGebruiker>
    {
        public Task Consume(ConsumeContext<CreateGebruiker> context)
        {
            var command = context.Message;

            Console.WriteLine("Consuming CreateGebruikerCommand: " + command.Id);

            return Task.FromResult(0);
        }
    }
}
