using System;
using System.Linq;
using System.Net;
using RestSharp;
using Sod.Mobitinerary.Api.Demo.BookingsApi.Model;

namespace Sod.Mobitinerary.Api.Demo.BookingsApi
{
    /// <summary>
    ///     A client for the mobitinerary booking api.
    ///     Using this class you can create, update and delete bookings in the mobitinerary product.
    /// </summary>
    public class Client : ICreateBookings, IUpdateBookings, IDeleteBookings
    {
        private readonly IRestClient _client;
        private readonly IProvideClientConfiguration _configuration;
        private readonly ISerializeRequests _serializer;

        public Client(IRestClient client, ISerializeRequests serializer, IProvideClientConfiguration configuration)
        {
            _client = client;
            _serializer = serializer;
            _configuration = configuration;
        }

        /// <summary>
        ///     Sends a request to create a booking to the mobitinerary api.
        /// </summary>
        /// <param name="booking">A booking definition to be sent.</param>
        /// <returns>A booking identifier generated for the created booking.</returns>
        public Guid Create(Booking booking)
        {
            string xml = _serializer.Serialize(
                new CreateBookingRequest
                {
                    ApiKey = _configuration.ApiKey,
                    Booking = booking
                });

            IRestRequest request = new RestRequest("2/booking", Method.POST);
            request.RequestFormat = DataFormat.Xml;
            request.AddParameter("text/xml", xml, ParameterType.RequestBody);

            return Execute<CreateBookingResponse>(request).BookingId;
        }

        /// <summary>
        ///     Sends a request to delete a booking to the mobitinerary api.
        /// </summary>
        /// <param name="id">A booking identifier generated when the booking was created throug the mobitinerary api.</param>
        public void Delete(Guid id)
        {
            string xml = _serializer.Serialize(
                new DeleteBookingRequest
                {
                    ApiKey = _configuration.ApiKey,
                });

            IRestRequest request = new RestRequest("2/booking/{id}", Method.DELETE);
            request.RequestFormat = DataFormat.Xml;
            request.AddParameter("id", id, ParameterType.UrlSegment);
            request.AddParameter("text/xml", xml, ParameterType.RequestBody);

            Execute<DeleteBookingResponse>(request);
        }

        /// <summary>
        ///     Sends a request to update a booking to the mobitinerary api.
        /// </summary>
        /// <param name="id">A booking identifier generated when the booking was created throug the mobitinerary api.</param>
        /// <param name="booking">A booking definition to be sent.</param>
        public void Update(Guid id, Booking booking)
        {
            string xml = _serializer.Serialize(
                new UpdateBookingRequest
                {
                    ApiKey = _configuration.ApiKey,
                    Booking = booking
                });

            IRestRequest request = new RestRequest("2/booking/{id}", Method.PUT);
            request.RequestFormat = DataFormat.Xml;
            request.AddParameter("id", id, ParameterType.UrlSegment);
            request.AddParameter("text/xml", xml, ParameterType.RequestBody);

            Execute<UpdateBookingResponse>(request);
        }

        private T Execute<T>(IRestRequest restRequest) where T : new()
        {
            IRestResponse<T> response = _client.Execute<T>(restRequest);
            if (response.StatusCode == HttpStatusCode.OK) return response.Data;

            object requestBody = response.Request.Parameters.First(x => x.Type == ParameterType.RequestBody).Value;
            string message = string.Format(@"Error in mobitinerary api request ({0}): {1}
{2}", response.ResponseUri, response.StatusCode, requestBody);
            throw new InvalidResponseException(message);
        }
    }
}