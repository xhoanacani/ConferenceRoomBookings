namespace ConferenceRoomBookings.Models
{
	public class ConferenceRoomModel
	{
		public int Id { get; set; }
		public Guid Code { get; set; }
		public int MaximumCapacity { get; set; }
	}
}
