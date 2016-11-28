using FillModel.Services;
using FillModel.ViewModels.Home;

namespace FillModel.Filters.Fillers
{
    public class CountryViewFiller : IViewModelFiller<IndexViewModel> 
    {
        public void Fill(IndexViewModel model)
        {
            model.Countries = CountryService.GetCountries();
        }
    }
}