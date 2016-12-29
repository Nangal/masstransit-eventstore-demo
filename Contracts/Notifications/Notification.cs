using System;

namespace Contracts.Notifications
{
    public interface Notification
    {
        Guid Id { get; set; }
        string Title { get; set; }
        string Message { get; set; }
        string Type { get; set; }
    }
}