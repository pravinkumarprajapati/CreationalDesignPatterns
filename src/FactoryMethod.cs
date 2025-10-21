using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.src
{
    public interface CreditCard
    {
        string GetCardType();
        int GetCreditLimit();
        int GetAnnualCharge();

    }

    public interface INotifier
    {
        void Send(string message);
    }

    public class EmailNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"Email sent with message: {message}");
        }
    }

    public class SMSNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"SMS sent with message: {message}");
        }
    }


    public class PushNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"Push notification sent with message: {message}");
        }
    }

    public abstract class NotificationFactory
    {
        public abstract INotifier CreateNotifier();
    }

    public class EmailNotificationFactory : NotificationFactory
    {
        public override INotifier CreateNotifier()
        {
            return new EmailNotifier();

        }
    }

    public class SMSNotificationFactory : NotificationFactory
    {
        public override INotifier CreateNotifier()
        {
            return new SMSNotifier();
        }
    }
    public class PushNotificationFactory : NotificationFactory
    {
        public override INotifier CreateNotifier()
        {
            return new PushNotifier();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            EmailNotificationFactory emailFactory = new EmailNotificationFactory();

            INotifier notifier = emailFactory.CreateNotifier();
            notifier.Send("Hello, this is a test notification!");
        }
    }
}
