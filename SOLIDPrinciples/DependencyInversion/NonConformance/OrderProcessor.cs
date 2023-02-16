namespace SOLIDPrinciples.DependencyInversion.NonConformance
{
    class OrderProcessor
    {
        public void Purchase(Cart cart)
        {
            var creditCardProcessor = new CreditCardProcessor();
            creditCardProcessor.ProcessPayment(cart);
        }
    }

    class CreditCardProcessor
    {
        public void ProcessPayment(Cart cart)
        {
            // charge the customer's credit card
        }
    }

    class Cart
    {
        public Product[] Products { get; set; }
        
        public PaymentMethod PaymentMethod { get; set; }
    }

    class Product
    {
        public string ProductId { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }

    enum PaymentMethod { CreditCard }
}
