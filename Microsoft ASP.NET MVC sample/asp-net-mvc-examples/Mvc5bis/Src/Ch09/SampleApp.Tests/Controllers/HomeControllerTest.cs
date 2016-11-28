using System;
using System.Collections.Specialized;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SampleApp.Controllers;
using SampleApp.Tests.Framework;
using SampleApp.Tests.Helpers;
using RequestContext = System.Web.Routing.RequestContext;

namespace SampleApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Welcome to ASP.NET MVC!", result.ViewBag.Message);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Output()
        {
            // Arrange
            var writer = new StringWriter();
            var contextBase = new Mock<HttpContextBase>();
            contextBase.Setup(c => c.Response).Returns(new FakeResponse(writer));
            var controller = new HomeController();
            controller.ControllerContext = new ControllerContext(
                          contextBase.Object, new RouteData(), controller);

            // Act
            var result = controller.Output() as ViewResult;
            if (result == null)
                Assert.Fail("Result is null");

            // Assert
            Assert.AreEqual("Hello", writer.ToString());
        }

        [TestMethod]
        public void Should_Write_To_Session_State()
        {
            // Arrange
            var contextBase = new Mock<HttpContextBase>();
            contextBase.Setup(c => c.Session).Returns(new FakeSession());
            var controller = new HomeController();
            controller.ControllerContext = new ControllerContext(
                              contextBase.Object, new RouteData(), controller);

            // Act
            var expectedResult = "green"; 
            controller.SetColor();

            // Assert
            var result = controller.HttpContext.Session["PreferredColor"];
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Should_Read_From_Session_State()
        {
            // Arrange
            var contextBase = new Mock<HttpContextBase>();
            contextBase.Setup(c => c.Session["PreferredColor"]).Returns("Blue");
            var controller = new HomeController();
            controller.ControllerContext = new ControllerContext(
                                                contextBase.Object, new RouteData(), controller);

            // Act
            var result = controller.GetColor() as ViewResult;
            if (result == null)
                Assert.Fail("Result is null");

            // Assert
            Assert.AreEqual(result.ViewData["Color"].ToString(), "Blue");
        }

        [TestMethod]
        public void Test_Method_With_Filters()
        {
            var actionName = "about";
            var controllerName = "home";

            // Mock controller context
            var httpContext = GetHttpContext();
            var routeData = GetRouteData(controllerName, actionName);
            var controller = new HomeController { ActionInvoker = new UnitTestActionInvoker() };
            var controllerContext = new ControllerContext(httpContext, routeData, controller);

            // It is known that About is decorated with [AddHeader(Name="Author", Value="Dino")]
            controller.ActionInvoker.InvokeAction(controllerContext, actionName);

            var expectedHeader = "Dino";
            Assert.AreEqual(controllerContext.HttpContext.Response.Headers["Author"], expectedHeader);
        }

        private static HttpContextBase GetHttpContext()
        {
            var response = new FakeResponse();
            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.Setup(c => c.Response).Returns(response);
            return mockHttpContext.Object;
        }

        private static RouteData GetRouteData(String controllerName, String actionName)
        {
            var routeData = new RouteData();
            routeData.Values["controller"] = controllerName;
            routeData.Values["action"] = actionName;
            return routeData;
        }
    }
}
