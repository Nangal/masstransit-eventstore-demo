using System;
using MassTransit;
using Web.Consumers;

namespace Web
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

                cfg.ReceiveEndpoint(host, "deposant", e => { e.Consumer<NotificationsConsumer>(); });
                cfg.ReceiveEndpoint(host, "gebruiker", e => { e.Consumer<NotificationsConsumer>(); });
            });

            BusControl.Start();
        }
    }
}