using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Web.Mvc.Async;
using AsyncApp.Common;

namespace SampleApp.Tests.Helpers
{
    public class FakeNewsHumbleObject : INewsHumbleObject
    {
        public void GetFeedItems(String url, AsyncManager asyncManager)
        {
            // Place canned data inside the Parameters collection of AsyncManager
            var items = new List<SyndicationItem>
                        {
                            new SyndicationItem(
                                "News #1",
                                "This is the first news",
                                null),
                            new SyndicationItem(
                                "News #2",
                                "This is the second news",
                                null),
                            new SyndicationItem(
                                "News #3",
                                "This is the third news",
                                null)
                        };
            asyncManager.Parameters["feedItems"] = items;
            asyncManager.OutstandingOperations.Decrement();
        }

        public void Prepare(AsyncManager asyncManager)
        {
            // Same as production code
            asyncManager.OutstandingOperations.Increment();
        }
    }
}