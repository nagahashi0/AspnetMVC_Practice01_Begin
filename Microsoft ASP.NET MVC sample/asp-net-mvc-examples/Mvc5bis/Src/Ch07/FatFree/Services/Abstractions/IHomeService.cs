using FatFree.ViewModels.Home;

namespace FatFree.Services.Abstractions
{
    public interface IHomeService
    {
        IndexViewModel GetIndexViewModel();
    }
}