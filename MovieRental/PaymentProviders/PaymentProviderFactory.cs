namespace MovieRental.PaymentProviders;

public class PaymentProviderFactory
{
    public static IPaymentProvider GetPaymentProvider(string paymentMethod)
    {
        return paymentMethod switch
        {
            "MbWay" => new MbWayProvider(),
            "PayPal" => new PayPalProvider(),
            _ => throw new ArgumentException("Unknown payment method")
        };
    }
}