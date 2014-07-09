using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Sod.Mobitinerary.Api.Demo.BookingsApi.Model
{
    /// <summary>
    ///     A booking response for request to create a booking with <see cref="Client" />
    /// </summary>
    [Serializable]
    [XmlRoot(Namespace = Namespaces.BookingV2)]
    public class CreateBookingResponse
    {
        /// <summary>
        ///     The booking ID of the newly created booking.
        /// </summary>
        [XmlElement(Order = 1)]
        [JsonProperty("bookingId")]
        public Guid BookingId { get; set; }
    }
}