using System.ComponentModel;

namespace ConferenceRoomBookings.Models
{
	public class ConferenceRoomModel
	{
		public int? Id { get; set; }

		[DisplayName("Conference Room")]
		public int CodeRoom { get; set; }

		[DisplayName("Max Capacity")]
		public int MaximumCapacity { get; set; }
	}
}
