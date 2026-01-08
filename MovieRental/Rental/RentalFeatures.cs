using Microsoft.EntityFrameworkCore;
using MovieRental.Data;
using MovieRental.PaymentProviders;

namespace MovieRental.Rental
{
	public class RentalFeatures : IRentalFeatures
	{
		private readonly MovieRentalDbContext _movieRentalDb;
		private double rentDayPrice = 1.00;
		
		public RentalFeatures(MovieRentalDbContext movieRentalDb)
		{
			_movieRentalDb = movieRentalDb;
		}

		public async Task<Rental>? Save(Rental rental)
		{
			bool wasPaymentSuccessful = await MakePayment(rental.PaymentMethod, rental.DaysRented * rentDayPrice);
			if(!wasPaymentSuccessful){
				return null;
			}
			await _movieRentalDb.Rentals.AddAsync(rental);
			await _movieRentalDb.SaveChangesAsync();
			return rental;
		}

		public IEnumerable<Rental> GetRentalsByCustomerName(string customerName)
		{
			return _movieRentalDb.Rentals.Where(rental => rental.CustomerName == customerName).ToList();
		}

		public async Task<bool> MakePayment(string paymentMethod, double price)
		{
			try
			{
				var paymentProvider = PaymentProviderFactory.GetPaymentProvider(paymentMethod);
				return await paymentProvider.Pay(price);
			}
			catch
			{
				return false;
			}
		}

	}
}
