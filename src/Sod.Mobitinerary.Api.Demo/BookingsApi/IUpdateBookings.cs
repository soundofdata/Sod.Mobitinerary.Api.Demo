using System;
using Sod.Mobitinerary.Api.Demo.BookingsApi.Model;

namespace Sod.Mobitinerary.Api.Demo.BookingsApi
{
    /// <summary>
    ///     An interface to update bookings in the mobitinerary api.
    /// </summary>
    public interface IUpdateBookings
    {
        void Update(Guid id, Booking booking);
    }
}