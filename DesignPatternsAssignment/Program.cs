using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public interface INotification
    {
        void Send(string message);
    }

    public class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Email Mssg: {message}");
        }
    }

    public class SMSNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"SMS Mssg: {message}");
        }
    }

    public class PushNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Push Notification Mssg: {message}");
        }
    }

    public class NotificationFactory
    {
        private static readonly Dictionary<string, Func<INotification>> _notifications = new Dictionary<string, Func<INotification>>()

    {
        { "email", () => new EmailNotification() },
        { "sms", () => new SMSNotification() },
        { "push", () => new PushNotification() }
    };

        public static INotification CreateNotification(string type)
        {
            if (_notifications.TryGetValue(type.ToLower(), out var notification))
            {
                return notification();
            }
            throw new ArgumentException("Invalid notification type");
        }
    }

    class Program
    {
        static void Main()
        {
            INotification notification = NotificationFactory.CreateNotification("email");
            notification.Send("This is a Email notification. ");

            notification = NotificationFactory.CreateNotification("sms");
            notification.Send("This is an SMS notification.");

            notification = NotificationFactory.CreateNotification("push");
            notification.Send("This is a push notification.");
        }
    }
}
