using System;
using RestSharp;
using Sod.Mobitinerary.Api.Demo.BookingsApi;

namespace Sod.Mobitinerary.Api.Demo
{
    /// <summary>
    ///     A builder for the mobitinerary booking api client.
    /// </summary>
    public class BookingApiClientBuilder
    {
        private string _apiKey;
        private string _baseUrl;

        public Client Build()
        {
            if (string.IsNullOrEmpty(_baseUrl))
            {
                throw new InvalidOperationException("ApiUrl for the mobitinerary api is not defined.");
            }
            if (string.IsNullOrEmpty(_apiKey))
            {
                throw new InvalidOperationException("ApiKey for the mobitinerary api is not defined.");
            }

            ISerializeRequests serializer = new RequestSerializer();
            IRestClient client = new RestClient(_baseUrl);
            IProvideClientConfiguration configuration = new ClientConfiguration {ApiKey = _apiKey};
            return new Client(client, serializer, configuration);
        }

        public BookingApiClientBuilder WithBaseUrl(string url)
        {
            _baseUrl = url;
            return this;
        }

        public BookingApiClientBuilder WithApiKey(string key)
        {
            _apiKey = key;
            return this;
        }
    }
}