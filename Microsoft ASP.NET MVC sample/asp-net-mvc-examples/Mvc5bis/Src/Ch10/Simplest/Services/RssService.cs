using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Simplest.Services
{
    public class RssService
    {
        public static IList<SyndicationItem> GetItems(String xml)
        {
            var textReader = new StringReader(xml);
            var xmlReader = XmlReader.Create(textReader);
            var feed = SyndicationFeed.Load(xmlReader);
            return feed == null ? null : new List<SyndicationItem>(feed.Items);
        }
    }
}