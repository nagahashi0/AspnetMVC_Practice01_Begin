using System.Collections.Generic;
using FatFree.Backend.Model;

namespace FatFree.Backend.DAL
{
    public interface IDateRepository
    {
        IList<MementoDate> GetFeaturedDates();
    }
}