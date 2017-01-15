using Consumer.Registries;
using Domain.Deposant;
using Domain.Services.Deposant;
using StructureMap;
using Topshelf;
using Topshelf.StructureMap;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(c =>
            {
                var container = new Container(cfg =>
                {
                    cfg.Scan(scan =>
                    {
                        scan.TheCallingAssembly();
                        scan.WithDefaultConventions();
                    });

                    cfg.For<IDeposantService>().Use<DeposantService>();

                    cfg.ForConcreteType<DeposantConsumer>();
                    cfg.ForConcreteType<GebruikerConsumer>();

                    cfg.AddRegistry<BusRegistry>();
                    cfg.AddRegistry<EventStoreRegistry>();
                });

                c.UseStructureMap(container);

                c.Service<CommandConsumerService>(s =>
                {
                    s.ConstructUsingStructureMap();

                    s.WhenStarted((service, control) => service.Start());
                    s.WhenStopped((service, control) => service.Stop());
                });
            });
        }
    }
}
