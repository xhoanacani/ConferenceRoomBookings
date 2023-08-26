using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceRoomBookings.Context;
using ConferenceRoomBookings.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConferenceRoomBookings.Controllers
{
    public class ReservationHolderController : Controller
    {
        public readonly ConferenceRoomBookingsContext _context;

        // GET: ConferenceRoomController
        public async Task<List<ReservationHolder>> GetAll()
        {
            return await _context.ReservationHolders.ToListAsync();
        }

        // GET: ConferenceRoomController/Details/5
        public async Task<ReservationHolder> Get(int id)
        {
            var reservationHolder = await _context.ReservationHolders.FindAsync(id);

            return reservationHolder;
        }

        // GET: ConferenceRoomController/Create
        public async void Create(ReservationHolder reservationHolder)
        {
            await _context.ReservationHolders.AddAsync(reservationHolder);
        }

        // GET: ConferenceRoomController/Delete/5
        public async void Delete(int id)
        {
            var reservationHolder = await _context.ReservationHolders.FindAsync(id);

            _context.ReservationHolders.Remove(reservationHolder);
        }
    }
}

