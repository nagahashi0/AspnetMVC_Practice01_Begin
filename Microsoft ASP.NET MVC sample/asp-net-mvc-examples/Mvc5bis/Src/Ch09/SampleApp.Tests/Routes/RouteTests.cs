using System;
using System.Web;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SampleApp.Common;

namespace SampleApp.Tests.Routes
{
    [TestClass]
    public class RouteTests
    {
        [TestMethod]
        public void Test_If_Routes_Work()
        {
            // Arrange
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            RouteData routeData = null;
            
            // Act & Assert whether the right route was found
            var expectedRoute = "{controller}/{action}/{id}";
            routeData = GetRouteDataForUrl("~/product/id/5", routes);
            Assert.AreEqual(((Route)routeData.Route).Url, expectedRoute);
        }

        private static RouteData GetRouteDataForUrl(String url, RouteCollection routes)
        {
            var httpContextMock = new Mock<HttpContextBase>();
            httpContextMock.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns(url);
            var routeData = routes.GetRouteData(httpContextMock.Object);
            Assert.IsNotNull(routeData, "Should have found the route");
            return routeData;
        }

    }
}
