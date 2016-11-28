using System;
using FatFree.Services.Home;

namespace FatFree.Backend
{
    public class ServiceLocator
    {
        public static Object GetService(string token)  
        {
            if (token == "home")
                return new HomeService();
            return null;
        }
    }
}