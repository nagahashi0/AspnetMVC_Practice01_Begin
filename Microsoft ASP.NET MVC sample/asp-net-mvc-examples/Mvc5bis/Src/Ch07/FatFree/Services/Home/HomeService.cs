using System;
using System.Collections.Generic;
using FatFree.Backend.DAL;
using FatFree.Common;
using FatFree.Services.Abstractions;
using FatFree.ViewModels.Home;
using FatFree.ViewModels.Shared;

namespace FatFree.Services.Home
{
    public class HomeService : IHomeService
    {
        private readonly IDateRepository _repository;

        public HomeService() : this(new DateRepository())
        {
        }
        public HomeService(IDateRepository repository)
        {
            _repository = repository;
        }

        public IndexViewModel GetIndexViewModel()
        {
            // Get featured dates from backend
            var dates = _repository.GetFeaturedDates();

            // Adjust featured dates for the view
            //  i.e. calculate distance from now to specified dates
            var featuredDates = new List<FeaturedDate>();
            foreach(var mementoDate in dates)
            {
                var fd = new FeaturedDate
                                {
                                    Description = mementoDate.Description,
                                    Date = mementoDate.IsRelative
                                                ? DateTime.Now.Next(mementoDate.Date.Month, mementoDate.Date.Day)
                                                : mementoDate.Date
                                };
                fd.DaysToGo = (Int32)(DateTime.Now - fd.Date).TotalDays;
                featuredDates.Add(fd);
            }

            // Package data into the view model as the view engine expects
            var model = new IndexViewModel
                            {
                                Title = "Memento (BETA)",
                                MessageFormat = "Today is <span class='dateEmphasis'>{0}</span>",
                                Today = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                                FeaturedDates = featuredDates
                            };

            return model;
        }    
    }
}