using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Sod.Mobitinerary.Api.Demo.BookingsApi
{
    /// <summary>
    /// An implementation for a request serializer for <see cref="Client"/>
    /// </summary>
    public class RequestSerializer : ISerializeRequests
    {
        public string Serialize<T>(T request)
        {
            using (var stringWriter = new StringWriter())
            {
                var settings = new XmlWriterSettings
                {
                    Encoding = Encoding.UTF8,
                    OmitXmlDeclaration = true
                };
                using (var writer = XmlWriter.Create(stringWriter, settings))
                {
                    var xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(writer, request);
                }
                return stringWriter.ToString();
            }
        }
    }
}