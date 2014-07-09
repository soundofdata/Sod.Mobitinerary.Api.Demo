using System;
using System.Collections.Generic;
using Sod.Mobitinerary.Api.Demo.BookingsApi;
using Sod.Mobitinerary.Api.Demo.BookingsApi.Model;

namespace Sod.Mobitinerary.Api.Demo
{
    /// <summary>
    /// This is a test application that sends create, update and delete booking requests to the mobitinerary api.
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            Client client = new BookingApiClientBuilder()
                .WithBaseUrl("http://api.mobitinerary.com/")
                .WithApiKey("PLEASE PROVIDE YOUR API KEY HERE")
                .Build();

            Booking booking = CreateBooking();
            Guid id = client.Create(booking);
            client.Update(id, booking);
            client.Delete(id);
        }

        private static Booking CreateBooking()
        {
            var booking = new Booking
            {
                Travellers = new List<Booking.Traveller>
                {
                    new Booking.Traveller
                    {
                        Id = "T1",
                        DateOfBirth = "1867-01-01",
                        Gender = "male",
                        CountryCode = "NL",
                        PreferredLanguageCode = "en",
                        Communication = new Booking.Communication
                        {
                            Email = new Booking.Email {Value = "some@email.com", Culture = "en-US"},
                            Sms = new Booking.Sms {Value = "+31657543067", Culture = "en-US"}
                        }
                    }
                },
                Flights = new List<Booking.Flight>
                {
                    new Booking.Flight
                    {
                        Id = "F1",
                        AirlineIataCode = "KL",
                        FlightNumber = "1025",
                        DepartureAirportIataCode = "AMS",
                        DepartureAirportCityName = "Amsterdam",
                        DepartureDateTime = "2015-01-25T12:00",
                        ArrivalAirportIataCode = "LHR",
                        ArrivalAirportCityName = "London",
                        ArrivalDateTime = "2015-01-25T17:00"
                    }
                },
                Hotels = new List<Booking.Hotel>
                {
                    new Booking.Hotel
                    {
                        CheckInDateTime = "2015-01-26T12:00+00:00",
                        CheckOutDateTime = "2015-02-01T12:00+00:00",
                        Contact = new Booking.Contact {Mail = "dummy@email.com", PhoneNumber = "+32 2 548 42 11"},
                        Location =
                            new Booking.Location
                            {
                                Country = "Belgium",
                                City = "Brussels",
                                AddressLine1 = "Carrefour de l'Europe 3",
                                PostalCode = "1000"
                            },
                        Name = "Le Meridien Brussels",
                        Stars = 5,
                        Website = "http://LeMeridienBrussels.be",
                        Description = "This is Le Meridien Brussels hotel description",
                        Reference = "12345EDF"
                    }
                },
                CarRentals = new List<Booking.CarRental>(),
                EnableAlerts = false,
                EnableFlightStatus = false,
                Etickets = new List<Booking.Eticket>(),
                Reference = "SOME_REFERENCE"
            };
            return booking;
        }
    }
}