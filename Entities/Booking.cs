using System;
using System.Collections.Generic;

namespace ConferenceRoomBookings.Entities
{
    public partial class Booking
    {
        public Booking()
        {
            ReservationHolders = new HashSet<ReservationHolder>();
        }

        public int Id { get; set; }
        public Guid Code { get; set; }
        public int NumberOfPeople { get; set; }
        public bool IsConfirmed { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDelete { get; set; }

        public virtual ConferenceRoom Room { get; set; } = null!;
        public virtual ICollection<ReservationHolder> ReservationHolders { get; set; }
    }
}
