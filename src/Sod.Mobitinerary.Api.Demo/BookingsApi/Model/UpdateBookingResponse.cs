using System;
using System.Xml.Serialization;

namespace Sod.Mobitinerary.Api.Demo.BookingsApi.Model
{
    /// <summary>
    ///     A booking response for request to update a booking with <see cref="Client" />
    /// </summary>
    [Serializable]
    [XmlRoot(Namespace = Namespaces.BookingV2)]
    public class UpdateBookingResponse
    {
    }
}