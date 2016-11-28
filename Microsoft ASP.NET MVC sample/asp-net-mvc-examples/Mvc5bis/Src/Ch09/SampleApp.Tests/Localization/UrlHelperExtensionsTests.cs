using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using BookSamples.Components.Localization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleApp.Tests.Localization
{
    [TestClass]
    public class UrlHelperExtensionsTests
    {
        [TestMethod]
        public void Test_If_Url_Extensions_Work()
        {
            // Data
            var url = "sample.css";
            var expectedUrl = "sample.it.css";

            // Set culture to IT
            const String culture = "it-IT";
            var cultureInfo = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            // Act & Assert
            var localizedUrl = UrlExtensions.GetLocalizedUrl(url);
            Assert.AreEqual(localizedUrl, expectedUrl);
        }
    }
}
