using MovieRental.Data;

namespace MovieRental.Customer
{
    public class CustomerFeatures : ICustomerFeatures
    {
        private readonly MovieRentalDbContext _movieRentalDb;
        public CustomerFeatures(MovieRentalDbContext movieRentalDb)
        {
            _movieRentalDb = movieRentalDb;
        }
		
        public Customer Save(Customer customer)
        {
            _movieRentalDb.Customers.Add(customer);
            _movieRentalDb.SaveChanges();
            return customer;
        }

        public Customer? GetCustomerByCustomerName(string customerName)
        {
            return _movieRentalDb.Customers.FirstOrDefault(c => c.CustomerName == customerName);
        }
    }
}