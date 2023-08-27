using ConferenceRoomBookings.Context;
using ConferenceRoomBookings.Converters;
using ConferenceRoomBookings.Entities;
using ConferenceRoomBookings.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConferenceRoomBookings.Controllers;

public class UnavailabiltyPeriodController : Controller
{
    public readonly ConferenceRoomBookingsContext _context;

    public UnavailabiltyPeriodController(ConferenceRoomBookingsContext context)
    {
        _context = context;
    }

    // GET: ConferenceRoomController
    public async Task<IActionResult> Index()
    {
        var unavailabiityPeriod = await _context.UnavailabilityPeriods
            .Include(x => x.Room)
            .ToListAsync();

        var result = unavailabiityPeriod.ConvertAll(x => x.ToViewModel());

        return View(result);
    }

    // GET: ConferenceRoomController/Details/5
    [AllowAnonymous]
    public async Task<IActionResult> Details(int id)
    {
        var unavailabilityPeriod = await _context.UnavailabilityPeriods.FindAsync(id);

        if (unavailabilityPeriod == null)
        {
            return NotFound();
        }

        var result = unavailabilityPeriod.ToViewModel();

        return View(result);
    }

    // GET: ConferenceRoomController/Create
    public IActionResult Create()
    {
        var viewModel = new UnavailabilityPeriodModel
        {
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMinutes(30)
        };

        var rooms = _context.ConferenceRooms.ToList();
        ViewBag.ListRooms = new SelectList(rooms, "Id", "CodeRoom");

        return View(viewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(UnavailabilityPeriodModel request)
    {
        if (request == null)
        {
            var rooms = _context.ConferenceRooms.ToList();
            ViewBag.ListRooms = new SelectList(rooms, "Id", "CodeRoom");
            return View(request);
        }

        var unavailabilityPeriod = request.ToEntity();

        _ = _context.UnavailabilityPeriods.Add(unavailabilityPeriod);

        _ = _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    // GET: ConferenceRoomController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var unavailabilityPeriod = await _context.UnavailabilityPeriods.FindAsync(id);

        if (unavailabilityPeriod == null)
        {
            return NotFound();
        }

        var result = unavailabilityPeriod.ToViewModel();

        return View(result);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, UnavailabilityPeriodModel request)
    {
        if (id != request.Id)
        {
            return Problem("Info are not right!");
        }

        var unavailabilityPeriod = await _context.UnavailabilityPeriods.FindAsync(id);

        if (unavailabilityPeriod == null)
        {
            return RedirectToAction(nameof(Index));
        }

        _context.UnavailabilityPeriods.Remove(unavailabilityPeriod);

        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var unavailabilityPeriod = await _context.UnavailabilityPeriods.FindAsync(id);

        if (unavailabilityPeriod == null)
        {
            return NotFound();
        }

        var result = unavailabilityPeriod.ToViewModel();

        return View(result);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, UnavailabilityPeriodModel request)
    {
        if (id != request.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(request);
        }

        var unavailabilityPeriod = await _context.UnavailabilityPeriods.FindAsync(id);

        if (unavailabilityPeriod == null)
        {
            return NotFound();
        }

        unavailabilityPeriod.StartDate = request.StartDate;
        unavailabilityPeriod.EndDate = request.EndDate;
        unavailabilityPeriod.Reasons = request.Reasons;
        unavailabilityPeriod.RoomId = request.RoomId;

        _ = _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}



