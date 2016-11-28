using System;
using System.Collections.Generic;
using FatFree.Backend.Model;

namespace FatFree.Backend.DAL
{
    public class DateRepository : IDateRepository
    {
        public IList<MementoDate> GetFeaturedDates()
        {
            var dates = new List<MementoDate>();
            var d1 = new MementoDate
                         {
                             Date = new DateTime(1, 12, 25),
                             IsRelative = true,
                             Description = "Christmas."
                         };
            dates.Add(d1);

            var d2 = new MementoDate
                         {
                             Date = new DateTime(2012, 7, 27),
                             IsRelative = false,
                             Description = "London Olympics kick-off."
                         };
            dates.Add(d2);

            var d3 = new MementoDate
                         {
                             Date = new DateTime(1989, 11, 9),
                             IsRelative = false,
                             Description = "Berlin Wall collapsed."
                         };
            dates.Add(d3);
            return dates;
        }
    }
}