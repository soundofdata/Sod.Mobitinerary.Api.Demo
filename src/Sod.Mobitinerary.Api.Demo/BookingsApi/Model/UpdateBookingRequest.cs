using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Sod.Mobitinerary.Api.Demo.BookingsApi.Model
{
    /// <summary>
    ///     A booking request to update a booking with <see cref="Client" />
    /// </summary>
    [Serializable]
    [XmlRoot(Namespace = Namespaces.BookingV2)]
    public class UpdateBookingRequest
    {
        [XmlElement(Order = 1)]
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }

        /// <summary>
        ///     Gets or sets the booking.
        /// </summary>
        [XmlElement(Order = 2)]
        [JsonProperty("booking")]
        public Booking Booking { get; set; }
    }
}