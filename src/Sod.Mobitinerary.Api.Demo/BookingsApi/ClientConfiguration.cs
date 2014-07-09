namespace Sod.Mobitinerary.Api.Demo.BookingsApi
{
    /// <summary>
    ///     An implementation for a configuration provider for <see cref="Client" />
    /// </summary>
    public class ClientConfiguration : IProvideClientConfiguration
    {
        public string ApiKey { get; set; }
    }
}