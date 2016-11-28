using FatFreeIoC.ViewModels.Home;

namespace FatFreeIoC.Services.Abstractions
{
    public interface IHomeService
    {
        IndexViewModel GetIndexViewModel();
    }
}