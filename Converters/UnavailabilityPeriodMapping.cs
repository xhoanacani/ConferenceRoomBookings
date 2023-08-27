
using ConferenceRoomBookings.Entities;
using ConferenceRoomBookings.Models;

namespace ConferenceRoomBookings.Converters;

public static class UnavailabilityPeriodMapping
{
    public static UnavailabilityPeriodModel ToViewModel(this UnavailabilityPeriod model)
    {
        return new UnavailabilityPeriodModel
        {
            Id = model.Id,
            EndDate = model.EndDate,
            StartDate = model.StartDate,
            RoomCode = model.Room?.CodeRoom
        };
    }

    public static UnavailabilityPeriod ToEntity(this UnavailabilityPeriodModel model)
    {
        return new UnavailabilityPeriod
        {
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            Reasons = model.Reasons,
            RoomId = model.RoomId
        };
    }
}
