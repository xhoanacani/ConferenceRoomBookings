using ConferenceRoomBookings.Entities;
using ConferenceRoomBookings.Models;

namespace ConferenceRoomBookings.Converters;

public static class BookingMappings
{
    public static BookingModel ToViewModel(this Booking model)
    {
        return new BookingModel
        {
            Id = model.Id,
            NumberOfPeople = model.NumberOfPeople,
            IsConfirmed = model.IsConfirmed,
            IsDelete=model.IsDelete,
            Code = model.Code,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            RoomCode = model.Room?.CodeRoom
        };
    }

    public static Booking ToEntity(this BookingModel model)
    {
        return new Booking
        {
            NumberOfPeople = model.NumberOfPeople,
            IsConfirmed = model.IsConfirmed,
            IsDelete = model.IsDelete,
            Code = model.Code,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            RoomId=model.RoomId
        };
    }
}
