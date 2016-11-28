namespace SampleApp.Services
{
    public class HomeService : IHomeService
    {
        public void GetIndexViewModel(dynamic viewBag)
        {
            viewBag.Message = "Welcome to ASP.NET MVC!";
        }
    }
}