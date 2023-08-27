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

        public BookingController(ConferenceRoomBookingsContext context)
        {
            _context = context;
        }

        public readonly ConferenceRoomBookingsContext _context;

        // GET: ConferenceRoomController
        public async Task<IActionResult> Index()
        {
            var result = await _context.Bookings.ToListAsync();

            return View(result);
        }

        // GET: ConferenceRoomController/Details/5
        public async Task<Booking> Get(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);

            return booking;
        }

        // GET: ConferenceRoomController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Booking request)
        {
            var bookingToCreate = new Booking
            {
                Code = request.Code,
                NumberOfPeople  = request.NumberOfPeople,
                IsConfirmed = request.IsConfirmed,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                IsDelete = request.IsDelete,
                RoomId= request.Room.Id

            };
            _ = _context.Bookings.Add(bookingToCreate);
            _ = _context.SaveChanges();
            return RedirectToAction(nameof(Index));

            return View(request);
        }
        // GET: ConferenceRoomController/Delete/5
        public async void Delete(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);

            _context.Bookings.Remove(booking);
        }
    }
}

