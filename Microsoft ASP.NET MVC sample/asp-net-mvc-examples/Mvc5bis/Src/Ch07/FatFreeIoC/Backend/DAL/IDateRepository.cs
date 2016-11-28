using System.Collections.Generic;
using FatFree.Backend.Model;

namespace FatFreeIoC.Backend.DAL
{
    public interface IDateRepository
    {
        IList<MementoDate> GetFeaturedDates();
    }
}