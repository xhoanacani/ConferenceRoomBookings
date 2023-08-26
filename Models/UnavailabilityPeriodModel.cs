namespace ConferenceRoomBookings.Models
{
	public class UnavailabilityPeriodModel
	{
		public int Id { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Reasons { get; set; } = null!;
		public int RoomId { get; set; }

		
	}
}
