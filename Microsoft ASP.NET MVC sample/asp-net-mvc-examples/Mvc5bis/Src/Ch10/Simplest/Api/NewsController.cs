using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Simplest.Models.Dto;
using Simplest.Services;

namespace Simplest.Api
{
    public class NewsController : ApiController
    {
        public News Get(Int32 index)
        {
            var all = GetAll();
            if (index <=0)
                throw new ArgumentException("index");

            return all[index];
        }

        public IList<News> GetAll(int count=20)
        {
            var client = new WebClient();
            var rss = client.DownloadString("http://feeds2.feedburner.com/Tennis-AtpWorldTourHeadlineNews");
            var news = ParseRssInternal(rss, count);
            return news;
        }

        public HttpResponseMessage PostNews(News news) 
        {    
            // Do something here to store the news
            var newsId = SaveNewsInSomeWay(news);

            // Build an empty response: 201 is code for Created 
            var response = Request.CreateResponse<String>(HttpStatusCode.Created, "OK");    

            // Store location of new item
            var relativePath = String.Format("/api/news/{0}", newsId);    
            response.Headers.Location = new Uri(Request.RequestUri, relativePath);    
            return response;
        }

        //[AcceptVerbs("HEAD")]
        public HttpResponseMessage PutNews(Int32 id, News news)
        {
            if (id <= 0)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            // Do something here to update the news: consider returning 200/204
            var response = Request.CreateResponse<String>(HttpStatusCode.OK, "OK");
            return response;
        }

        public HttpResponseMessage DeleteNews(Int32 id)
        {
            if (id <= 0)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            // Do something here to delete the news  

            return new HttpResponseMessage(HttpStatusCode.NoContent);   // 204
        }

        //[AcceptVerbs("HEAD")]
        public HttpResponseMessage HeadNews(int id)
        {
            var message = new HttpResponseMessage(HttpStatusCode.OK);
            message.Headers.Add("NewsId", id.ToString());
            return message;
        }


        #region Private
        private static IList<News> ParseRssInternal(String rss, int count)
        {
            var items = RssService.GetItems(rss);
            return
                (from si in items
                 select new News
                 {
                     Content = si.Title.Text,
                     Title = si.Title.Text,
                     Published = si.PublishDate.Date
                 }).Take(count).ToList();
        }
        
        private static int SaveNewsInSomeWay(News news)
        {
            return 123;
        }
        #endregion
    }
}