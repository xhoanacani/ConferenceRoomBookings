using System;
using System.Collections.Generic;

namespace ConferenceRoomBookings.Entities
{
    public partial class UnavailabilityPeriod
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Reasons { get; set; }
        public int? RoomId { get; set; }

        public virtual ConferenceRoom? Room { get; set; }
    }
}
