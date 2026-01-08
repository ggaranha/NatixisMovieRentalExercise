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
            /*
             * Add customer record to Customer table
             */
            _movieRentalDb.Customers.Add(customer);
            _movieRentalDb.SaveChanges();
            return customer;
        }

        public Customer? GetCustomerByCustomerName(string customerName)
        {
            /*
             * Get customer from Customer table by customer name
             */
            return _movieRentalDb.Customers.FirstOrDefault(c => c.CustomerName == customerName);
        }
    }
}