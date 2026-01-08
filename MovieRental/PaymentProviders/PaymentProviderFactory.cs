namespace MovieRental.PaymentProviders;

public class PaymentProviderFactory
{
    public static IPaymentProvider GetPaymentProvider(string paymentMethod)
    {
        /***
         * Get Payment Provider from paymentMethod string.
         * Throw an exception if string has an unknown payment method.
         */
        return paymentMethod switch
        {
            "MbWay" => new MbWayProvider(),
            "PayPal" => new PayPalProvider(),
            _ => throw new ArgumentException("Unknown payment method")
        };
    }
}