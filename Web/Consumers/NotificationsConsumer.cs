using System.Threading.Tasks;
using Contracts.Notifications;
using MassTransit;
using Microsoft.AspNet.SignalR;
using Web.Hubs;

namespace Web.Consumers
{
    public class NotificationsConsumer : IConsumer<Notification>
    {
        private static readonly IHubContext HubContext = GlobalHost.ConnectionManager.GetHubContext<ApplicationHub>();

        public Task Consume(ConsumeContext<Notification> context)
        {
            var notification = context.Message;

            var type = notification.Type;
            var message = notification.Message;
            var title = notification.Title;

            HubContext.Clients.All.sendToast(type, message, title);

            return Task.FromResult(0);
        }
    }
}