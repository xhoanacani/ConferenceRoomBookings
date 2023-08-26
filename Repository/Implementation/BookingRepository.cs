using ConferenceRoomBookings.Context;
using ConferenceRoomBookings.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConferenceRoomBookings.Repository.Implementation
{
	public class BookingRepository
	{

		public readonly ConferenceRoomBookingsContext _context;

		public BookingRepository(ConferenceRoomBookingsContext context)
		{
			_context = context;
		}


		public async Task<Booking> Get(int id)
		{
			var bookings = await _context.Bookings.FindAsync(id);

			return bookings;
		}

		public async  Task<List<Booking>> GetAll()
		{
			var bookings = _context.Bookings.ToListAsync();

			return bookings.Result;
		}
	}
}
