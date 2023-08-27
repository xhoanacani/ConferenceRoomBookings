using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using ConferenceRoomBookings.Context;
using ConferenceRoomBookings.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConferenceRoomBookings.Controllers
{
    public class ReservationHolderController : Controller
    {

        public ReservationHolderController(ConferenceRoomBookingsContext context)
        {
            _context = context;
        }

        public readonly ConferenceRoomBookingsContext _context;

        // GET: ConferenceRoomController
        public async Task<IActionResult> Index()
        {
            var result = await _context.ReservationHolders.ToListAsync();

            return View(result);
        }
        // GET: ConferenceRoomController/Details/5
        public async Task<ReservationHolder> Get(int id)
        {
            var reservationHolder = await _context.ReservationHolders.FindAsync(id);

            return reservationHolder;
        }

        // GET: ConferenceRoomController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationHolder request)
        {
            var reservationholderToCreate = new ReservationHolder
            {

                IdCardNumber = request.IdCardNumber,
                Name = request.Name,
                SurName = request.SurName,
                Email=request.Email,
                PhoneNumber = request.PhoneNumber,
                Notes = request.Notes  
            };
                _ = _context.ReservationHolders.Add(reservationholderToCreate); 
            _ = _context.SaveChanges(); 
            return RedirectToAction(nameof(Index));
         
            return View(request);
        }
        // GET: ConferenceRoomController/Delete/5
        public async void Delete(int id)
        {
            var reservationHolder = await _context.ReservationHolders.FindAsync(id);

            _context.ReservationHolders.Remove(reservationHolder);
        }
    }
}

