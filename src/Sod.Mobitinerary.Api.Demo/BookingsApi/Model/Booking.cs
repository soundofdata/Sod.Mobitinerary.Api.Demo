using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Sod.Mobitinerary.Api.Demo.BookingsApi.Model
{
    /// <summary>
    ///     A booking model to be send to create or update a booking with <see cref="Client" />
    /// </summary>
    [Serializable]
    [XmlRoot(Namespace = Namespaces.BookingV2)]
    public class Booking
    {
        /// <summary>
        ///     Gets or sets additional travellers.
        /// </summary>
        [XmlArray]
        [JsonProperty("travellers")]
        public List<Traveller> Travellers { get; set; }

        /// <summary>
        ///     Gets or sets a collection of booked flights.
        /// </summary>
        [XmlArray]
        [JsonProperty("flights")]
        public List<Flight> Flights { get; set; }

        /// <summary>
        ///     Gets or sets a collections of booked hotels.
        /// </summary>
        [XmlArray]
        [JsonProperty("hotels")]
        public List<Hotel> Hotels { get; set; }

        [XmlArray]
        [JsonProperty("carRentals")]
        public List<CarRental> CarRentals { get; set; }

        /// <summary>
        ///     Gets or sets a collection of etickets.
        /// </summary>
        [XmlArray]
        [JsonProperty("etickets")]
        public List<Eticket> Etickets { get; set; }

        /// <summary>
        ///     Gets or sets the enabling of flight status.
        /// </summary>
        [XmlElement]
        [JsonProperty("enableFlightStatus")]
        public bool EnableFlightStatus { get; set; }

        /// <summary>
        ///     Gets or sets the enabling of alerts.
        /// </summary>
        [XmlElement]
        [JsonProperty("enableAlerts")]
        public bool EnableAlerts { get; set; }

        /// <summary>
        ///     Gets or sets the booking reference.
        /// </summary>
        [XmlElement(IsNullable = true)]
        [JsonProperty("reference")]
        public string Reference { get; set; }

        #region Nested Classes

        [XmlRoot(Namespace = Namespaces.BookingV2)]
        public class CarRental
        {
            [XmlElement]
            [JsonProperty("confirmationNumber")]
            public string ConfirmationNumber { get; set; }

            [XmlElement]
            [JsonProperty("pickUpDateTime")]
            public string PickUpDateTime { get; set; }

            [XmlElement]
            [JsonProperty("pickUpAirportCode")]
            public string PickUpAirportCode { get; set; }

            [XmlElement]
            [JsonProperty("dropOffDateTime")]
            public string DropOffDateTime { get; set; }

            [XmlElement]
            [JsonProperty("dropOffAirportCode")]
            public string DropOffAirportCode { get; set; }

            [XmlElement]
            [JsonProperty("carVendor")]
            public string CarVendor { get; set; }

            [XmlElement]
            [JsonProperty("carVendorCode")]
            public string CarVendorCode { get; set; }

            [XmlElement]
            [JsonProperty("carType")]
            public string CarType { get; set; }

            [XmlElement]
            [JsonProperty("description")]
            public string Description { get; set; }
        }

        /// <summary>
        ///     Represents the abstract base for all specific communication channels.
        ///     The specific channels are:
        ///     - Email
        ///     - PushNotification
        ///     - Email
        /// </summary>
        [Serializable]
        [KnownType(typeof(Email))]
        [KnownType(typeof(Sms))]
        [XmlRoot(Namespace = Namespaces.BookingV2)]
        public abstract class Channel
        {
            /// <summary>
            ///     Gets or sets the value of the channel.
            ///     Depending on the channel this can be a phone number, email address or device key.
            /// </summary>
            [XmlElement]
            [JsonProperty("value")]
            public string Value { get; set; }

            /// <summary>
            ///     Gets or sets the preferred culture of the channel.
            /// </summary>
            [XmlElement]
            [JsonProperty("culture")]
            public string Culture { get; set; }
        }

        /// <summary>
        ///     Represents the communication channels.
        /// </summary>
        [Serializable]
        [XmlRoot(Namespace = Namespaces.BookingV2)]
        public class Communication
        {
            /// <summary>
            ///     Gets or sets the email communication channel.
            /// </summary>
            [XmlElement]
            [JsonProperty("email")]
            public Email Email { get; set; }

            /// <summary>
            ///     Gets or sets the SMS communication channel.
            /// </summary>
            [XmlElement]
            [JsonProperty("sms")]
            public Sms Sms { get; set; }
        }

        [Serializable]
        [XmlRoot(Namespace = Namespaces.BookingV2)]
        public class Contact
        {
            [XmlElement]
            [JsonProperty("phoneNumber")]
            public string PhoneNumber { get; set; }

            [XmlElement]
            [JsonProperty("fax")]
            public string Fax { get; set; }

            [XmlElement]
            [JsonProperty("mail")]
            public string Mail { get; set; }
        }

        /// <summary>
        ///     Represents the email communication channel.
        /// </summary>
        [Serializable]
        [XmlRoot(Namespace = Namespaces.BookingV2)]
        public class Email :
            Channel
        {
        }

        [XmlRoot(Namespace = Namespaces.BookingV2)]
        public class Eticket
        {
            [XmlAttribute]
            [JsonProperty("travellerId")]
            public string TravellerId { get; set; }

            [XmlAttribute]
            [JsonProperty("flightId")]
            public string FlightId { get; set; }

            [XmlElement(Order = 1)]
            [JsonProperty("number")]
            public string Number { get; set; }
        }

        /// <summary>
        ///     Represents a booked flight.
        /// </summary>
        [Serializable]
        [XmlRoot(Namespace = Namespaces.BookingV2)]
        public class Flight
        {
            [XmlAttribute]
            [JsonProperty("id")]
            public string Id { get; set; }

            [XmlAttribute]
            [JsonProperty("isTicketed")]
            public string IsTicketed { get; set; }

            /// <summary>
            ///     Gets or sets the IATA code of the airline.
            /// </summary>
            [XmlElement]
            [JsonProperty("airlineIataCode")]
            public string AirlineIataCode { get; set; }

            /// <summary>
            ///     Gets or sets the ICAO code of the airline.
            /// </summary>
            [XmlElement]
            [JsonProperty("airlineIcaoCode")]
            public string AirlineIcaoCode { get; set; }

            /// <summary>
            ///     Gets or sets the flight number.
            /// </summary>
            [XmlElement]
            [JsonProperty("flightNumber")]
            public string FlightNumber { get; set; }

            /// <summary>
            ///     Gets or sets the IATA code of the departure airport.
            /// </summary>
            [XmlElement]
            [JsonProperty("departureAirportIataCode")]
            public string DepartureAirportIataCode { get; set; }

            /// <summary>
            ///     Gets or sets the ICAO code of the departure airport.
            /// </summary>
            [XmlElement]
            [JsonProperty("departureAirportIcaoCode")]
            public string DepartureAirportIcaoCode { get; set; }

            /// <summary>
            ///     Gets or sets the departure airport city name.
            /// </summary>
            [XmlElement]
            [JsonProperty("departureAirportCityName")]
            public string DepartureAirportCityName { get; set; }

            /// <summary>
            ///     Gets or sets the local departure date and time.
            /// </summary>
            [XmlElement]
            [JsonProperty("departureDateTime")]
            public string DepartureDateTime { get; set; }

            [XmlElement]
            [JsonProperty("departureGate")]
            public string DepartureGate { get; set; }

            [XmlElement]
            [JsonProperty("departureTerminal")]
            public string DepartureTerminal { get; set; }

            /// <summary>
            ///     Gets or sets the IATA code of the arrival airport.
            /// </summary>
            [XmlElement]
            [JsonProperty("arrivalAirportIataCode")]
            public string ArrivalAirportIataCode { get; set; }

            /// <summary>
            ///     Gets or sets the ICAO code of the arrival airport.
            /// </summary>
            [XmlElement]
            [JsonProperty("arrivalAirportIcaoCode")]
            public string ArrivalAirportIcaoCode { get; set; }

            /// <summary>
            ///     Gets or sets the arrival airport city name.
            /// </summary>
            [XmlElement]
            [JsonProperty("arrivalAirportCityName")]
            public string ArrivalAirportCityName { get; set; }

            /// <summary>
            ///     Gets or sets the local arrival date and time.
            /// </summary>
            [XmlElement]
            [JsonProperty("arrivalDateTime")]
            public string ArrivalDateTime { get; set; }

            [XmlElement]
            [JsonProperty("arrivalGate")]
            public string ArrivalGate { get; set; }

            [XmlElement]
            [JsonProperty("arrivalTerminal")]
            public string ArrivalTerminal { get; set; }
        }

        [Serializable]
        [XmlRoot(Namespace = Namespaces.BookingV2)]
        public class GeoLocation
        {
            [XmlElement]
            [JsonProperty("latitude")]
            public string Latitude { get; set; }

            [XmlElement]
            [JsonProperty("longitude")]
            public string Longitude { get; set; }
        }

        [Serializable]
        [XmlRoot(Namespace = Namespaces.BookingV2)]
        public class Hotel
        {
            [XmlElement]
            [JsonProperty("reference")]
            public string Reference { get; set; }

            [XmlElement]
            [JsonProperty("name")]
            public string Name { get; set; }

            [XmlElement]
            [JsonProperty("checkInDateTime")]
            public string CheckInDateTime { get; set; }

            [XmlElement]
            [JsonProperty("checkOutDateTime")]
            public string CheckOutDateTime { get; set; }

            [XmlElement]
            [JsonProperty("description")]
            public string Description { get; set; }

            [XmlElement]
            [JsonProperty("location")]
            public Location Location { get; set; }

            [XmlElement]
            [JsonProperty("stars")]
            public int? Stars { get; set; }

            [XmlElement]
            [JsonProperty("contact")]
            public Contact Contact { get; set; }

            [XmlElement]
            [JsonProperty("website")]
            public string Website { get; set; }

            [XmlArray]
            [JsonProperty("socialMediaLinks")]
            public List<SocialMedia> SocialMediaLinks { get; set; }
        }

        [Serializable]
        [XmlRoot(Namespace = Namespaces.BookingV2)]
        public class Location
        {
            [XmlElement]
            [JsonProperty("addressLine1")]
            public string AddressLine1 { get; set; }

            [XmlElement]
            [JsonProperty("addressLine2")]
            public string AddressLine2 { get; set; }

            [XmlElement]
            [JsonProperty("postalCode")]
            public string PostalCode { get; set; }

            [XmlElement]
            [JsonProperty("city")]
            public string City { get; set; }

            [XmlElement]
            [JsonProperty("country")]
            public string Country { get; set; }

            [XmlElement]
            [JsonProperty("geoLocation")]
            public GeoLocation GeoLocation { get; set; }
        }

        /// <summary>
        ///     Represent a person.
        /// </summary>
        [Serializable]
        [XmlRoot(Namespace = Namespaces.BookingV2)]
        public abstract class Person
        {
            /// <summary>
            ///     Gets or sets the data of birth of the person.
            /// </summary>
            [XmlElement(IsNullable = true)]
            [JsonProperty("dateOfBirth")]
            public string DateOfBirth { get; set; }

            /// <summary>
            ///     Gets or sets the gender of the person.
            /// </summary>
            [XmlElement(IsNullable = true)]
            [JsonProperty("gender")]
            public string Gender { get; set; }

            /// <summary>
            ///     Gets or sets the country code of the person.
            /// </summary>
            [XmlElement(IsNullable = true)]
            [JsonProperty("countryCode")]
            public string CountryCode { get; set; }

            /// <summary>
            ///     Gets or sets the preferred language code of the person.
            /// </summary>
            [XmlElement]
            [JsonProperty("preferredLanguageCode")]
            public string PreferredLanguageCode { get; set; }
        }

        /// <summary>
        ///     Represents the SMS channel
        /// </summary>
        [Serializable]
        [XmlRoot(Namespace = Namespaces.BookingV2)]
        public class Sms :
            Channel
        {
        }

        [Serializable]
        [XmlRoot(Namespace = Namespaces.BookingV2)]
        public class SocialMedia
        {
            [XmlElement]
            [JsonProperty("key")]
            public string Key { get; set; }

            [XmlElement]
            [JsonProperty("link")]
            public string Link { get; set; }
        }

        /// <summary>
        ///     Represent a user.
        /// </summary>
        [Serializable]
        [XmlRoot(Namespace = Namespaces.BookingV2)]
        public class Traveller : Person
        {
            [XmlAttribute]
            [JsonProperty("id")]
            public string Id { get; set; }

            /// <summary>
            ///     Gets or sets the communication channels of the traveller.
            /// </summary>
            [XmlElement]
            [JsonProperty("communication")]
            public Communication Communication { get; set; }
        }

        #endregion
    }
}
