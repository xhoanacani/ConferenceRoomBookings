using ConferenceRoomBookings.Context;
using ConferenceRoomBookings.Entities;
using ConferenceRoomBookings.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ConferenceRoomBookings.Controllers
{
	public class ConferenceRoomController : Controller
	{
		public readonly ConferenceRoomBookingsContext _context;

        public ConferenceRoomController(ConferenceRoomBookingsContext context)
        {
            _context = context;
        }

        // GET: ConferenceRoomController
        public async Task<IActionResult> Index()
		{
			var result=  await _context.ConferenceRooms.ToListAsync();

			return View(result);
		}

        // GET: ConferenceRoomController/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var conferenceRoom = await _context.ConferenceRooms.FindAsync(id); if (conferenceRoom == null)
            {
                return NotFound();
            }
            return View(conferenceRoom);
        }

        // GET: ConferenceRoomController/Create
        public ActionResult Create()
		{
			return View();
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodeRoom, MaximumCapacity")] ConferenceRoom request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            try
            {
                var conferenceRoom = _context.ConferenceRooms.First(cr => cr.CodeRoom == request.CodeRoom);
            }
            catch (Exception e)
            {
                var movieToCreate = new ConferenceRoom
                {
                    CodeRoom = request.CodeRoom,
                    MaximumCapacity = request.MaximumCapacity,
                }; _ = _context.ConferenceRooms.Add(movieToCreate); _ = _context.SaveChanges(); return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("CodeRoom", "A conference room with that code already exists");
            return View(request);
        }



        // GET: ConferenceRoomController/Delete/5

        public async Task<IActionResult> Delete(int id)
		{
			var conferenceRoom = await _context.ConferenceRooms.FindAsync(id);

			if(conferenceRoom == null)
			{
				return NotFound();
			}

			return View(conferenceRoom);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(int id, [Bind("Id")] ConferenceRoomModel request)
		{
			if(id != request.Id){
				return NotFound();
			}

			var conferenceRoom = await _context.ConferenceRooms.FindAsync(id);

			if(conferenceRoom == null)
			{
				return RedirectToAction(nameof(Index));
			}


			_context.ConferenceRooms.Remove(conferenceRoom);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var conferenceRoom = await _context.ConferenceRooms.FindAsync(id); if (conferenceRoom == null)
            {
                return NotFound();
            }
            return View(conferenceRoom);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodeRoom, MaximumCapacity")] ConferenceRoom request)
        {
            if (id != request.Id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var conferenceRoom = await _context.ConferenceRooms.FindAsync(id); if (conferenceRoom == null)
            {
                return NotFound();
            }        // Update movie
            conferenceRoom.MaximumCapacity = request.MaximumCapacity;
            conferenceRoom.CodeRoom = request.CodeRoom;
            _ = _context.SaveChanges(); return RedirectToAction(nameof(Index));
        }
    }
}
