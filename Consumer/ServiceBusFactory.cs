using System;
using MassTransit;

namespace Consumer
{
    public class ServiceBusFactory
    {
        public static IBusControl Create(IApplicationSettings applicationSettings)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            });
        }
    }
}
