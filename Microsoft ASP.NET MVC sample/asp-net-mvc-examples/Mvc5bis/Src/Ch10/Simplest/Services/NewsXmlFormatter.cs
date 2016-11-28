using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Simplest.Models.Dto;

namespace Simplest.Services
{
    public class NewsXmlFormatter : MediaTypeFormatter
    {
        public NewsXmlFormatter()
        {
            SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/xml"));
            SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/xml"));
        }

        public override bool CanReadType(Type type)
        {
            return false;  
        }

        public override bool CanWriteType(Type type)
        {
            var result = (type == typeof(News) || type == typeof(IList<News>));
            return result;
        }

        public override Task WriteToStreamAsync(Type type, Object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            return Task.Factory.StartNew(
                () =>
                    {
                        var listOfNews = (IList<News>) value;
                        using (var writer = new StreamWriter(writeStream))
                        {
                            foreach (var n in listOfNews)
                            {
                                writer.WriteLine("<news>");
                                writer.WriteLine("<title>{0}</title>", n.Title);
                                writer.WriteLine("</news>");
                            }
                        }
                    });
        }
    }
}