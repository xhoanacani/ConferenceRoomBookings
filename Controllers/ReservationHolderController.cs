using ConferenceRoomBookings.Context;
using ConferenceRoomBookings.Converters;
using ConferenceRoomBookings.Entities;
using ConferenceRoomBookings.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConferenceRoomBookings.Controllers;

public class ReservationHolderController : Controller
{
    public readonly ConferenceRoomBookingsContext _context;

    public ReservationHolderController(ConferenceRoomBookingsContext context)
    {
        _context = context;
    }

    // GET: ConferenceRoomController
    public async Task<IActionResult> Index()
    {
        var reservationHolders = await _context.ReservationHolders.ToListAsync();
        var result = reservationHolders.ConvertAll(x => x.ToViewModel());
        // TODO: Map
        return View(result);
    }

    // GET: ConferenceRoomController/Details/5
    [AllowAnonymous]
    public async Task<IActionResult> Details(int id)
    {
        var reservationHolder = await _context.ReservationHolders.FindAsync(id);
        if(reservationHolder==null)
        {
            return NotFound();
        }
        var result = reservationHolder.ToViewModel();
        // TODO: Map
        return View(result);
    }

    // GET: ConferenceRoomController/Create
    public ActionResult Create()
    {
        var viewModel = new ReservationHolderModel();
        
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ReservationHolderModel request)

    {
        if(!ModelState.IsValid)
        {
            return View(request);
        }
        var existingReservationHolders = await _context.ReservationHolders.FirstOrDefaultAsync(x => x.IdCardNumber == request.IdCardNumber);
        if (existingReservationHolders != null)
        {
            ModelState.AddModelError("IdCardNumber", "A person with this IdCardNumber already exist ");
        return View(request);
        }
        var reservationHolders = request.ToEntity();
        _=_context.ReservationHolders.Add(reservationHolders);
        _=_context.SaveChanges();
        return RedirectToAction(nameof(Index));
        
    }
    // GET: ConferenceRoomController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var reservationHolder = await _context.ReservationHolders.FindAsync(id);

        if(reservationHolder==null)
        {
            return NotFound();
        }
        var result = reservationHolder.ToViewModel();
        return View(result);
        
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id,  ReservationHolderModel request)
    {
        if (id != request.Id)
        {
            return NotFound();
        }

        var reservationHolder = await _context.ReservationHolders.FindAsync(id);

        if (reservationHolder == null)
        {
            return RedirectToAction(nameof(Index));
        }

        _context.ReservationHolders.Remove(reservationHolder);

        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Edit(int id)
    {
        var reservationHolder = await _context.ReservationHolders.FindAsync(id);

        if (reservationHolder == null)
        {
            return NotFound();
        }

        var result = reservationHolder.ToViewModel();

        return View(result);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ReservationHolderModel request)
    {
        if (id != request.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(request);
        }

        var reservationHolder = await _context.ReservationHolders.FindAsync(id);

        if (reservationHolder == null)
        {
            return NotFound();
        }

        reservationHolder.IdCardNumber = request.IdCardNumber;
        reservationHolder.Name = request.Name;
        reservationHolder.SurName= request.SurName;
        reservationHolder.Email = request.Email;
        reservationHolder.PhoneNumber = request.PhoneNumber;
        reservationHolder.Notes = request.Notes;
        reservationHolder.BookingId = request.BookingId;

        _ = _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}


