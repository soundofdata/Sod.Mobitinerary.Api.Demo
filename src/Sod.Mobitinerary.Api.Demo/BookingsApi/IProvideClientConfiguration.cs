namespace Sod.Mobitinerary.Api.Demo.BookingsApi
{
    /// <summary>
    ///     A configuration provider for <see cref="Client" />
    /// </summary>
    public interface IProvideClientConfiguration
    {
        string ApiKey { get; }
    }
}