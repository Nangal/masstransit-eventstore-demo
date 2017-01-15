using Consumer.Config;
using Consumer.Config.EventStoreHelloWorld;
using Domain;
using EventStorage;
using EventStore.ClientAPI;
using StructureMap;

namespace Consumer.Registries
{
    public class EventStoreRegistry : Registry
    {
        public EventStoreRegistry()
        {
            For<IApplicationSettings>().Use<ApplicationSettings>();
            For<IEventStoreConnection>().Use(c => GesConnection.Create()).Singleton();
            For<AggregateFactory>().Use<AggregateFactory>().Singleton();
            For<IRepository>()
                .Use(
                    c =>
                        new GesRepository(c.GetInstance<IEventStoreConnection>(), c.GetInstance<AggregateFactory>()))
                .Singleton();
        }
    }
}
