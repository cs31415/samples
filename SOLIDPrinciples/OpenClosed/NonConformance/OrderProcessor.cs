using System;

namespace SOLIDPrinciples.OpenClosed.NonConformance
{
    class OrderProcessor
    {
        public void Purchase(Cart cart)
        {
            switch (cart.PaymentMethod)
            {
                case PaymentMethod.CreditCard:
                    var creditCardProcessor = new CreditCardProcessor();
                    creditCardProcessor.ProcessPayment(cart);
                    break;
                case PaymentMethod.Paypal:
                    var venmoProcessor = new PaypalProcessor();
                    venmoProcessor.ProcessPayment(cart);
                    break;
            }
        }
    }

    class PaypalProcessor
    {
        public void ProcessPayment(Cart cart)
        {
            // charge via Paypal
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

    enum PaymentMethod { CreditCard, Paypal }
}
