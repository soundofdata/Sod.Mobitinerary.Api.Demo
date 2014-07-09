namespace Sod.Mobitinerary.Api.Demo.BookingsApi
{
    /// <summary>
    ///     A request serializer for <see cref="Client" />
    /// </summary>
    public interface ISerializeRequests
    {
        string Serialize<T>(T request);
    }
}