namespace ConferenceRoomBookings.Models
{
	public class BookingModel
	{
		public int Id { get; set; }
		public Guid Code { get; set; }
		public int NumberOfPeople { get; set; }
		public bool IsConfirmed { get; set; }
		public int RoomId { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public bool IsDelete { get; set; }
	}
}
