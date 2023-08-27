using ConferenceRoomBookings.Context;
using ConferenceRoomBookings.Converters;
using ConferenceRoomBookings.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var conferenceRooms = await _context.ConferenceRooms.ToListAsync();

            var result = conferenceRooms.ConvertAll(x => x.ToViewModel());

            return View(result);
        }

        // GET: ConferenceRoomController/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var conferenceRoom = await _context.ConferenceRooms.FindAsync(id);

            if (conferenceRoom == null)
            {
                return NotFound();
            }

            var result = conferenceRoom.ToViewModel();

            return View(result);
        }

        // GET: ConferenceRoomController/Create
        public ActionResult Create()
        {
            var viewModel = new ConferenceRoomModel
            {
                MaximumCapacity = 1
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConferenceRoomModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var existingConferenceRoom = await _context.ConferenceRooms.FirstOrDefaultAsync(cr => cr.CodeRoom == request.CodeRoom);

            if (existingConferenceRoom != null)
            {
                ModelState.AddModelError("Code Room", "A conference room with that code already exists");
                return View(request);
            }

            var conferenceRoom = request.ToEntity();

            _ = _context.ConferenceRooms.Add(conferenceRoom);
            _ = _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: ConferenceRoomController/Delete/5

        public async Task<IActionResult> Delete(int id)
        {
            var conferenceRoom = await _context.ConferenceRooms.FindAsync(id);

            if (conferenceRoom == null)
            {
                return NotFound();
            }

            var result = conferenceRoom.ToViewModel();

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, [Bind("Id")] ConferenceRoomModel request)
        {
            if (id != request.Id)
            {
                return NotFound();
            }

            var conferenceRoom = await _context.ConferenceRooms.FindAsync(id);

            if (conferenceRoom == null)
            {
                return RedirectToAction(nameof(Index));
            }

            _context.ConferenceRooms.Remove(conferenceRoom);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var conferenceRoom = await _context.ConferenceRooms.FindAsync(id);

            if (conferenceRoom == null)
            {
                return NotFound();
            }

            var result = conferenceRoom.ToViewModel();

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ConferenceRoomModel request)
        {
            if (id != request.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var conferenceRoom = await _context.ConferenceRooms.FindAsync(id);

            if (conferenceRoom == null)
            {
                return NotFound();
            }

            conferenceRoom.MaximumCapacity = request.MaximumCapacity;
            conferenceRoom.CodeRoom = request.CodeRoom;

            _ = _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
