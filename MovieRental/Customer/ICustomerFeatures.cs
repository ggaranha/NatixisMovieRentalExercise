namespace MovieRental.Customer;

public interface ICustomerFeatures
{
    Customer Save(Customer customer);
    Customer? GetCustomerByCustomerName(string customerName);
}