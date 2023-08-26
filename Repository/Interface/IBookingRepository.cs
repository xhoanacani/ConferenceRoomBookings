using ConferenceRoomBookings.Entities;

namespace ConferenceRoomBookings.Repository.Interface
{
	public interface IBookingRepository
	{
		Task<List<Booking>?> GetAll(string search, Guid code);

		Task<Booking?> Get(int id);

		Task<int> SaveChanges();

		Booking Add(Booking booking);

		void Delete(Booking booking);

		Task<List<string>> GetListOfCode();
	}
}
