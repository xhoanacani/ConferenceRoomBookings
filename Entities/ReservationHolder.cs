using System;
using System.Collections.Generic;

namespace ConferenceRoomBookings.Entities
{
    public partial class ReservationHolder
    {
        public int Id { get; set; }
        public string IdCardNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public string Notes { get; set; } = null!;
        public int BookingId { get; set; }

        public virtual Booking Booking { get; set; } = null!;
    }
}
