using System;
using System.Collections.Specialized;
using System.IO;
using System.Web;

namespace SampleApp.Tests.Helpers
{
    public class FakeResponse : HttpResponseBase
    {
        private readonly TextWriter _writer;
        private readonly NameValueCollection _headers;

        public FakeResponse() : this(new StringWriter())
        {
        }
        public FakeResponse(TextWriter writer)
        {
            _headers = new NameValueCollection();
            _writer = writer;
        }

        public override void AddHeader(String name, String value)
        {
            Headers.Add(name, value); 
        }

        public override NameValueCollection Headers
        {
            get
            {
                return _headers;
            }
        }

        public override void Write(String msg)
        {
            _writer.Write(msg);
        }
    }
}
