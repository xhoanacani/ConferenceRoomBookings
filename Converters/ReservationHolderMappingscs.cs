using ConferenceRoomBookings.Entities;
using ConferenceRoomBookings.Models;

namespace ConferenceRoomBookings.Converters;

public static class ReservationHolderMappingscs
{
    public static ReservationHolderModel ToViewModel(this ReservationHolder model)
    {
        return new ReservationHolderModel
        {
            Id = model.Id,
           BookingId = model.BookingId,
           IdCardNumber = model.IdCardNumber,
           Notes = model.Notes,
           Name = model.Name,
           SurName = model.SurName,
           PhoneNumber = model.PhoneNumber,
           Email = model.Email,
            
        };
    }

    public static ReservationHolder ToEntity(this ReservationHolderModel model)
    {
        return new ReservationHolder
        {
            IdCardNumber = model.IdCardNumber,
            Notes = model.Notes,
            Name = model.Name,
            SurName = model.SurName,
            PhoneNumber = model.PhoneNumber,
            Email = model.Email,
            BookingId = model.BookingId,
        };
    }
}
