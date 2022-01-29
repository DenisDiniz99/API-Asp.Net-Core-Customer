using Api_Customer_Business.Notifications;
using System.Collections.Generic;

namespace Api_Customer_Business.Contracts
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
