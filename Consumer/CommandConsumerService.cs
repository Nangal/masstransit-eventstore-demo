using System;
using MassTransit;
using MassTransit.Pipeline;
using StructureMap;

namespace Consumer
{
    public class CommandConsumerService
    {
        private IBusControl _bus;

        public CommandConsumerService(IBusControl bus)
        {
            _bus = bus;
        }

        public bool Start()
        {
            //var container = new Container(cfg =>
            //{
            //    cfg.Scan(scan =>
            //    {
            //        scan.TheCallingAssembly();
            //        scan.WithDefaultConventions();
            //    });

            //    cfg.ForConcreteType<DeposantConsumer>();
            //    cfg.ForConcreteType<GebruikerConsumer>();
            //});

            //_bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            //{
            //    var host = cfg.Host(new Uri("rabbitmq://localhost"), h =>
            //    {
            //        h.Username("guest");
            //        h.Password("guest");
            //    });



            //    cfg.ReceiveEndpoint(host, "deposant", e => { e.LoadFrom(container); });
            //    cfg.ReceiveEndpoint(host, "gebruiker", e => { e.LoadFrom(container); });
            //});

            

            _bus.Start();

            return true;
        }

        public bool Stop()
        {
            _bus.Stop();

            return true;
        }      
    }
}
