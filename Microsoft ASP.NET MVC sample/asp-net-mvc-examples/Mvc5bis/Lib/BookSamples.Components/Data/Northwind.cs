using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using BookSamples.Components.Extensions;

namespace BookSamples.Components.Data
{
    public class NorthwindCustomers
    {
        public static IEnumerable<SimpleCustomer> GetAll()
        {
            const string url = "http://www.expoware.org/data/customer/all";
            var client = new WebClient {Encoding = Encoding.UTF8};
            return client.DownloadJson<IEnumerable<SimpleCustomer>>(url);
        }

        public static IEnumerable<SimpleCustomer> Select(String match)
        {
            var url = String.Format("http://www.expoware.org/data/customer/query?m={0}", match);
            var client = new WebClient {Encoding = Encoding.UTF8};
            return client.DownloadJson<IEnumerable<SimpleCustomer>>(url);
        }

        public static SimpleCustomer Get(String id)
        {
            var url = String.Format("http://www.expoware.org/data/customer/get/{0}", id);
            var client = new WebClient {Encoding = Encoding.UTF8};
            return client.DownloadJson<SimpleCustomer>(url);
        }
    }
}