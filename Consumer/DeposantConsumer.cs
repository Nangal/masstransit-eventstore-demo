using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Commands;
using MassTransit;

namespace Consumer
{
    public class DeposantConsumer : IConsumer<CreateDeposant>
    {
        public Task Consume(ConsumeContext<CreateDeposant> context)
        {
            var command = context.Message;

            Console.WriteLine("Consuming CreateDeposantCommand: " + command.Id);
          
            return Task.FromResult(0);
        }
    }
}
