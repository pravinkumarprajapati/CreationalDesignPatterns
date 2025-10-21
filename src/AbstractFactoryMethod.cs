using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Abstraction.src
{
    public abstract class PaymentProcessor
    {
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public PaymentProcessor( decimal amount)
        {
            Amount = amount;
            TransactionId = Guid.NewGuid().ToString();
        }
        public void LogTransaction()
        {
            Console.WriteLine($"[LOG] Transaction ID: {TransactionId}, Amount: {Amount}");
        }
        public void ProcessPayment()
        {

            ValidationPayment();
            MakePayment();

            SendReceipt();
        }
        protected abstract decimal ValidationPayment();
        public abstract void MakePayment();
        public abstract void SendReceipt();


    }

    public class PayPalPaymentProcessor : PaymentProcessor
    {
        public PayPalPaymentProcessor(decimal amount) : base(amount)
        {
        }
        protected override decimal ValidationPayment()
        {
            Console.WriteLine("Validating PayPal payment...");
            return Amount;
        }
        public override void MakePayment()
        {
            Console.WriteLine($"Processing PayPal payment of {Amount}...");
        }
        public override void SendReceipt()
        {
            Console.WriteLine("Sending PayPal payment receipt...");
        }
    }

    public class StripePaymentProcessor : PaymentProcessor
    {
        public StripePaymentProcessor(decimal amount) : base(amount)
        {
        }
        protected override decimal ValidationPayment()
        {
            Console.WriteLine("Validating Stripe payment...");
            return Amount;
        }
        public override void MakePayment()
        {
            Console.WriteLine($"Processing Stripe payment of {Amount}...");
        }
        public override void SendReceipt()
        {
            Console.WriteLine("Sending Stripe payment receipt...");
        }
    }

    public class ClientPayment
    {
        public void Main()
        {
            PaymentProcessor paypalProcessor = new PayPalPaymentProcessor(100.00m);
            paypalProcessor.ProcessPayment();
            Console.WriteLine();
            PaymentProcessor stripeProcessor = new StripePaymentProcessor(200.00m);
            stripeProcessor.ProcessPayment();
        }
    }
}
