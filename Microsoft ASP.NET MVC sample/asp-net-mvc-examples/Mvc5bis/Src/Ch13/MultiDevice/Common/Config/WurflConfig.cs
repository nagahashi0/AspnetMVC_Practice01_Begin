using WURFL;
using WURFL.Aspnet.Extensions.Config;
using WURFL.Config;

namespace MultiView2.Common.Config
{
    public class WurflConfig
    {
        public static void Initialize()
        {
            WURFLManagerBuilder.Build(new ApplicationConfigurer());
        }
    }
}