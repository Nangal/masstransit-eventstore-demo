using System;
using MassTransit;

namespace Api
{
    public class ServiceBusConfig
    {
        public static IBusControl BusControl { get; set; }

        public static void Configure()
        {

            BusControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            });

            BusControl.Start();
        }
    }
}