using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceRoomBookings.Context;
using ConferenceRoomBookings.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConferenceRoomBookings.Controllers
{
    public class BookingController : Controller
    {
        public readonly ConferenceRoomBookingsContext _context;

        // GET: ConferenceRoomController
        public async Task<List<Booking>> GetAll()
        {
            return await _context.Bookings.ToListAsync();
        }

        // GET: ConferenceRoomController/Details/5
        public async Task<Booking> Get(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);

            return booking;
        }

        // GET: ConferenceRoomController/Create
        public async void Create(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
        }

        // GET: ConferenceRoomController/Delete/5
        public async void Delete(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);

            _context.Bookings.Remove(booking);
        }
    }
}

