namespace SOLIDPrinciples.DependencyInversion.Conformance
{
    class OrderProcessor
    {
        private readonly IPaymentProcessor _paymentProcessor;

        public OrderProcessor(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }
        public void Purchase(Cart cart)
        {
            _paymentProcessor.ProcessPayment(cart);
        }
    }

    internal interface IPaymentProcessor
    {
        void ProcessPayment(Cart cart);
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

    public enum PaymentMethod { CreditCard }
}
