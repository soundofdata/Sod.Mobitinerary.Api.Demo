using System;

namespace Sod.Mobitinerary.Api.Demo.BookingsApi
{
    /// <summary>
    ///     An interface to delete bookings in the mobitinerary api.
    /// </summary>
    public interface IDeleteBookings
    {
        void Delete(Guid id);
    }
}