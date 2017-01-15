using MassTransit;

namespace Consumer
{
    public class CommandConsumerService
    {
        private readonly IBusControl _bus;

        public CommandConsumerService(IBusControl bus)
        {
            _bus = bus;
        }

        public bool Start()
        {
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
