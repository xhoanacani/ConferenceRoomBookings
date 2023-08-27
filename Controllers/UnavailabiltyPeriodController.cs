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
    public class UnavailabiltyPeriodController : Controller
    {
        public UnavailabiltyPeriodController(ConferenceRoomBookingsContext context)
        {
            _context = context;
        }

        public readonly ConferenceRoomBookingsContext _context;

        // GET: ConferenceRoomController
        public async Task<List<UnavailabilityPeriod>> GetAll()
        {
            return await _context.UnavailabilityPeriods.ToListAsync();
        }

        // GET: ConferenceRoomController/Details/5
        public async Task<UnavailabilityPeriod> Get(int id)
        {
            var unavailabilityPeriod = await _context.UnavailabilityPeriods.FindAsync(id);

            return unavailabilityPeriod;
        }

        // GET: ConferenceRoomController/Create
        public async void Create(UnavailabilityPeriod unavailabilityPeriod)
        {
            await _context.UnavailabilityPeriods.AddAsync(unavailabilityPeriod);
        }

        // GET: ConferenceRoomController/Delete/5
        public async void Delete(int id)
        {
            var unavailabilityPeriod = await _context.UnavailabilityPeriods.FindAsync(id);

            _context.UnavailabilityPeriods.Remove(unavailabilityPeriod);
        }
    }
}

