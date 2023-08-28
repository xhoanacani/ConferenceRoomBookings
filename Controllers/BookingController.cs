using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceRoomBookings.Context;
using ConferenceRoomBookings.Entities;
using ConferenceRoomBookings.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using ConferenceRoomBookings.Migrations;
using ConferenceRoomBookings.Converters;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConferenceRoomBookings.Controllers;

public class BookingController : Controller
{
    public readonly ConferenceRoomBookingsContext _context;
    public BookingController(ConferenceRoomBookingsContext context)
    {
        _context = context;
    }
    // GET: ConferenceRoomController
    public async Task<IActionResult> Index()
    {
        var booking = await _context.Bookings
            .Include(x => x.Room)
            .ToListAsync();
        var result = booking.ConvertAll(x => x.ToViewModel());

        return View(result);
    }
    // GET: ConferenceRoomController/Details/5
    [AllowAnonymous]
    public async Task<IActionResult> Get(int id)
    {
        var booking = await _context.Bookings.FindAsync(id);
        if (booking == null)
        {
            return NotFound();
        }
        var result = booking.ToViewModel();
        return View(result);
    }
    // GET: ConferenceRoomController/Create
    public ActionResult Create()
    {
        var viewModel = new BookingModel
        {
            NumberOfPeople = 0,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMinutes(60),
        };
        var rooms = _context.ConferenceRooms.ToList();
        ViewBag.ListRooms = new SelectList(rooms, "Id", "CodeRoom");

        return View(viewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(BookingModel request)
    {
        if (request == null)
        {
            var rooms = _context.ConferenceRooms.ToList();
            ViewBag.ListRooms = new SelectList(rooms,"Id","CodeRoom");
            return View(request);
        }
        var booking = request.ToEntity();
        _ = _context.Bookings.Add(booking);
        _ = _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    // GET: ConferenceRoomController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var booking = await _context.Bookings.FindAsync(id);
        if (booking == null)
        {
            return NotFound();
        }
        var result = booking.ToViewModel();
        return View(result);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, BookingModel request)
    {
        if (id != request.Id)
        {
            return Problem("Info are not right!");
        }
        var booking = await _context.Bookings.FindAsync(id);
        if (booking == null)
        {
            return RedirectToAction(nameof(Index));
        }
        _context.Bookings.Remove(booking);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Edit(int id)
    {
        var booking = await _context.Bookings.FindAsync(id);
        if (booking == null)
        {
            return NotFound();
        }
        var result = booking.ToViewModel();
        return View(result);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, BookingModel request)
    {
        if (id != request.Id)
        {
            return NotFound();
        }
        if (!ModelState.IsValid)
        {
            return View(request);
        }
        var booking = await _context.Bookings.FindAsync(id);
        if (booking == null)
        {
            return NotFound();
        }
        booking.NumberOfPeople = request.NumberOfPeople;
        booking.StartDate = request.StartDate;
        booking.EndDate = request.EndDate;
        booking.Code = request.Code;
        booking.IsConfirmed = request.IsConfirmed;
        booking.IsDelete = request.IsDelete;
        booking.RoomId = request.RoomId;
        _ = _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

}

