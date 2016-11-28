using MqBasic.Resources;
using MqBasic.ViewModels.Home;

namespace MqBasic.Services.Home
{
    public class HomeService
    {
        public IndexViewModel GetModelForHome()
        {
            var model = new IndexViewModel
                            {
                                Title = "MQ fun",
                                Headline = Literals.HomeIndexHeadline,
                                MoreInfo = Literals.HomeIndexMoreInfo,
                                MoreInfoUrl = "http://asp.net/mvc",
                                MoreInfoTooltip = Literals.HomeIndexMoreInfoTooltip
                            };
            return model;
        }
    }
}