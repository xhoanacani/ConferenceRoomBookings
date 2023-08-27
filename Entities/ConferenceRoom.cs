using System;
using System.Collections.Generic;

namespace ConferenceRoomBookings.Entities
{
    public partial class ConferenceRoom
    {
        public ConferenceRoom()
        {
            Bookings = new HashSet<Booking>();
            UnavailabilityPeriods = new HashSet<UnavailabilityPeriod>();
        }

        public int Id { get; set; }
        public int CodeRoom { get; set; }
        public int MaximumCapacity { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<UnavailabilityPeriod> UnavailabilityPeriods { get; set; }
    }
}
