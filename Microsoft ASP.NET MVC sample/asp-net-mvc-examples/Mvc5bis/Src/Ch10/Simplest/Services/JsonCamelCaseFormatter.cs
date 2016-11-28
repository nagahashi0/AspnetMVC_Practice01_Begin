// Originally from https://gist.github.com/rdingwall/2012642

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Simplest.Services
{
    public class JsonCamelCaseFormatter : MediaTypeFormatter
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public JsonCamelCaseFormatter()
        {
            _jsonSerializerSettings =
                new JsonSerializerSettings
                    {
                        ContractResolver =
                            new CamelCasePropertyNamesContractResolver()
                    };

            // Fill out the mediatype and encoding we support
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
        }

        public override bool CanReadType(Type type)
        {
            return true;
        }

        public override bool CanWriteType(Type type)
        {
            return true;
        }

        public override Task<object> ReadFromStreamAsync(Type type, Stream stream, HttpContent content, IFormatterLogger formatterLogger)
        {
            // Create a serializer
            var serializer = JsonSerializer.Create(_jsonSerializerSettings);

            // Create task reading the content
            return Task.Factory.StartNew(
                () =>
                    {
                        using (var streamReader = new StreamReader(stream))
                        using (var jsonTextReader = new JsonTextReader(streamReader))
                            return serializer.Deserialize(jsonTextReader, type);
                    });
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream stream, HttpContent content, TransportContext transportContext)
        {
            // Create a serializer
            var serializer = JsonSerializer.Create(_jsonSerializerSettings);

            // Create task writing the serialized content
            return Task.Factory.StartNew(
                () =>
                    {
                        using (var jsonTextWriter =
                            new JsonTextWriter(new StreamWriter(stream))
                                {
                                    Formatting = Formatting.Indented,
                                    CloseOutput = false
                                })
                        {
                            serializer.Serialize(jsonTextWriter, value);
                            jsonTextWriter.Flush();
                        }
                    });
        }
    }
}