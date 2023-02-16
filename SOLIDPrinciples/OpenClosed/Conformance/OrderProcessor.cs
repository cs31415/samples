using System;

namespace SOLIDPrinciples.OpenClosed.Conformance
{
    class OrderProcessor
    {
        private readonly IPaymentProcessorFactory _paymentProcessorFactory;

        public OrderProcessor(IPaymentProcessorFactory paymentProcessorFactory)
        {
            _paymentProcessorFactory = paymentProcessorFactory;
        }
        public void Purchase(Cart cart)
        {
            var paymentProcessor = _paymentProcessorFactory.GetPaymentProcessor(cart.PaymentMethod);
            paymentProcessor.ProcessPayment(cart);
        }
    }

    internal interface IPaymentProcessorFactory
    {
        IPaymentProcessor GetPaymentProcessor(PaymentMethod paymentMethod);
    }

    internal interface IPaymentProcessor
    {
        void ProcessPayment(Cart cart);
    }

    internal class PaypalProcessor : IPaymentProcessor
    {
        public void ProcessPayment(Cart cart)
        {
            // charge via Paypal
        }
    }

    internal class CreditCardProcessor : IPaymentProcessor
    {
        public void ProcessPayment(Cart cart)
        {
            // charge the customer's credit card
        }
    }

    internal class Cart
    {
        public Product[] Products { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }

    internal class Product
    {
        public string ProductId { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }

    public enum PaymentMethod { CreditCard, Paypal }
}
