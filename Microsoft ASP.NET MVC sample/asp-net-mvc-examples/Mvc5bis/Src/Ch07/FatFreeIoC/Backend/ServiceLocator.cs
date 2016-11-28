using System;
using FatFreeIoC.Services.Home;

namespace FatFreeIoC.Backend
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