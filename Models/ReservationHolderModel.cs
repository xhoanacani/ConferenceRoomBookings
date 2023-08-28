namespace ConferenceRoomBookings.Models
{
	public class ReservationHolderModel
	{
		public int Id { get; set; }
		public string IdCardNumber { get; set; } = null!;
		public string Name { get; set; } = null!;
		public string SurName { get; set; } = null!;
		public string Email { get; set; } = null!;
		public int PhoneNumber { get; set; }
		public string Notes { get; set; } = null!;
		public int BookingId { get; set; }
		public Guid? Code { get; set; }
	}
}
