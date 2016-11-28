using System;
using System.Collections.Generic;
using FatFree.Backend.DAL;
using FatFree.Backend.Model;
using FatFree.Services.Home;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


// See Ch07.FatFree example for classes being tested.

namespace SampleApp.Tests.Repository
{
    [TestClass]
    public class DateRepositoryTests
    {
        [TestMethod]
        public void Test_If_Dates_Are_Processed()
        {
            var inputDate = new DateTime(2012, 2, 8);

            var fakeRepository = new Mock<IDateRepository>();
            fakeRepository.Setup(d => d.GetFeaturedDates()).Returns(new List<MementoDate> 
                                                            {
                                                                new MementoDate {Date = inputDate}
                                                            });
            var service = new HomeService(fakeRepository.Object);
            var model = service.GetIndexViewModel();

            var expectedResult = (Int32) (DateTime.Now - inputDate).TotalDays;
            Assert.AreEqual(model.FeaturedDates[0].DaysToGo, expectedResult);
        }
    }
}
