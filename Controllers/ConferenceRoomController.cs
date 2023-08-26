using ConferenceRoomBookings.Context;
using ConferenceRoomBookings.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConferenceRoomBookings.Controllers
{
	public class ConferenceRoomController : Controller
	{
		public readonly ConferenceRoomBookingsContext _context;

		// GET: ConferenceRoomController
		public async Task<List<ConferenceRoom>> GetAll()
		{
			return await _context.ConferenceRooms.ToListAsync();
		}

		// GET: ConferenceRoomController/Details/5
		public async Task<ConferenceRoom> Get(int id)
		{
            var conferenceRoom = await _context.ConferenceRooms.FindAsync(id);

            return conferenceRoom;
        }

		// GET: ConferenceRoomController/Create
		public async void Create(ConferenceRoom conferenceRoom)
		{
			await _context.ConferenceRooms.AddAsync(conferenceRoom);
		}

		// GET: ConferenceRoomController/Delete/5
		public async void Delete(int id)
		{
			var conferenceRoom = await _context.ConferenceRooms.FindAsync(id);

			_context.ConferenceRooms.Remove(conferenceRoom);
		}
	}
}
