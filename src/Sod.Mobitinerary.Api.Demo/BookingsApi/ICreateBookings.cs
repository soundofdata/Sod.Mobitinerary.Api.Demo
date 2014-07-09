using System;
using Sod.Mobitinerary.Api.Demo.BookingsApi.Model;

namespace Sod.Mobitinerary.Api.Demo.BookingsApi
{
    /// <summary>
    ///     An interface to create bookings in the mobitinerary api.
    /// </summary>
    public interface ICreateBookings
    {
        Guid Create(Booking booking);
    }
}