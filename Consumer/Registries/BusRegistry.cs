using System;
using Consumer.Config;
using MassTransit;
using StructureMap;
using StructureMap.Pipeline;

namespace Consumer.Registries
{
    public class BusRegistry : Registry
    {
        public BusRegistry()
        {
            For<IBusControl>(new SingletonLifecycle()).Use(context => ServiceBusFactory.Create(context, context.GetInstance<IApplicationSettings>()));
            Forward<IBusControl, IBus>();
        }
    }

    public class ServiceBusFactory
    {
        public static IBusControl Create(IContext context, IApplicationSettings applicationSettings)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint(host, "deposant", e => { e.LoadFrom(context); });
                cfg.ReceiveEndpoint(host, "gebruiker", e => { e.LoadFrom(context); });
            });
        }
    }
}
