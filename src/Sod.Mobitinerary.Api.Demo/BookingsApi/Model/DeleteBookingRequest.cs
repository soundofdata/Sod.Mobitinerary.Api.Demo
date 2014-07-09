using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Sod.Mobitinerary.Api.Demo.BookingsApi.Model
{
    /// <summary>
    ///     A booking request to delete a booking with <see cref="Client" />
    /// </summary>
    [Serializable]
    [XmlRoot(Namespace = Namespaces.BookingV2)]
    public class DeleteBookingRequest
    {
        [XmlElement(Order = 1)]
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }
    }
}