using System;
using System.Net.Http.Formatting;

namespace RpcStyle.API.Formatters
{
    public class ExtendedXmlFormatter : XmlMediaTypeFormatter
    {
        public ExtendedXmlFormatter()
        {
            MediaTypeMappings.Add(new QueryStringMapping("xml", "true", "application/xml"));
            MediaTypeMappings.Add(new UriPathExtensionMapping("xml", "application/xml"));
        }

    }
}