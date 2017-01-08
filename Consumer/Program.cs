using MassTransit;
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

                    cfg.ForConcreteType<DeposantConsumer>();
                    cfg.ForConcreteType<GebruikerConsumer>();

                    cfg.AddRegistry<EventStoreRegistry>();
                });

                c.UseStructureMap(container);

                c.Service<SampleService>(s =>
                {
                    s.ConstructUsingStructureMap();

                    s.WhenStarted((service, control) => service.Start());
                    s.WhenStopped((service, control) => service.Stop());
                });
            });
        }
    }
}
