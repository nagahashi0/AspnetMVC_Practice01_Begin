using System;
using MultiView2.ViewModels.Home;

namespace MultiView2.Services.Shared
{
    public interface IHomeOrchestrator
    {
        IndexViewModel GetModelForIndex();
        String GetAppStoreLink(String userAgent);
    }
}