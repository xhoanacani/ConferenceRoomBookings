using ConferenceRoomBookings.Entities;
using ConferenceRoomBookings.Models;

namespace ConferenceRoomBookings.Converters;

public static class ConferenceRoomMappings
{
    public static ConferenceRoomModel ToViewModel(this ConferenceRoom model)
    {
        return new ConferenceRoomModel
        {
            Id = model.Id,
            CodeRoom = model.CodeRoom,
            MaximumCapacity = model.MaximumCapacity
        };
    }

    public static ConferenceRoom ToEntity(this ConferenceRoomModel model)
    {
        return new ConferenceRoom
        {
            CodeRoom = model.CodeRoom,
            MaximumCapacity = model.MaximumCapacity
        };
    }
}
