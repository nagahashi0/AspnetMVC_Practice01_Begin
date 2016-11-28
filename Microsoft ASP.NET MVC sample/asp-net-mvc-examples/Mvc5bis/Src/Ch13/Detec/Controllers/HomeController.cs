using System;
using System.Text;
using System.Web.Mvc;
using WURFL.Aspnet.Extensions.Request;

namespace Detec.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var r = WURFLRequestFactory.CreateRequest(System.Web.HttpContext.Current.Request);
            var deviceInfo = MyApp.WurflContainer.GetDeviceForRequest(r);
            //var tab = "Mozilla/5.0 (Linux; Android 4.0.3; GT-P3110 Build/IML74K) AppleWebKit/535.19 (KHTML, like Gecko) Chrome/18.0.1025.166  Safari/535.19";
            //var tv =
            //    "Mozilla/5.0 (SmartHub; SMART-TV; U; Linux/SmartTV) AppleWebKit/531.2+ (KHTML, like Gecko) WebBrowser/1.0 SmartTV Safari/531.2+";
            //var deviceInfo = MyApp.WurflContainer.GetDeviceForRequest(tv);

            // Full device name
            ViewBag.DeviceIdentity = String.Format("{0} {1}", deviceInfo.GetCapability("brand_name"), deviceInfo.GetCapability("marketing_name"));
            ViewBag.DeviceModel = deviceInfo.GetCapability("model_name");
            ViewBag.OperatingSystem = String.Format("{0} {1}", deviceInfo.GetCapability("device_os"), deviceInfo.GetCapability("device_os_version"));
            ViewBag.BrowserName =  String.Format("{0} {1}", deviceInfo.GetCapability("mobile_browser"), deviceInfo.GetCapability("mobile_browser_version"));
            ViewBag.IsDesktop = deviceInfo.GetCapability("ux_full_desktop");
            ViewBag.IsSmartTv = deviceInfo.GetCapability("is_smarttv");
            ViewBag.IsMobile = deviceInfo.GetCapability("is_wireless_device");
            ViewBag.IsTablet = deviceInfo.GetCapability("is_tablet");
            ViewBag.Resolution = String.Format("{0} x {1}", deviceInfo.GetCapability("resolution_width"), deviceInfo.GetCapability("resolution_height"));
            ViewBag.IsTouch = deviceInfo.GetCapability("pointing_method");
            ViewBag.CanHaveSim = deviceInfo.GetCapability("has_cellular_radio");
            ViewBag.IsPhone = deviceInfo.GetCapability("can_assign_phone_number");
            var builder = new StringBuilder();
            if (deviceInfo.GetCapability("streaming_mov") == "true")
                builder.Append("MOV, ");
            if (deviceInfo.GetCapability("streaming_wmv") != "none")
                builder.Append("WMV, ");
            if (deviceInfo.GetCapability("streaming_real_media") != "none")
                builder.Append("Real, ");
            if (deviceInfo.GetCapability("streaming_mp4") == "true")
                builder.Append("MP4, ");
            if (deviceInfo.GetCapability("streaming_flv") == "true")
                builder.Append("FLV, ");
            if (deviceInfo.GetCapability("streaming_3gpp") == "true")
                builder.Append("3gpp, "); 
            ViewBag.SupportedVideoStreaming = builder.ToString().Trim(' ', ',');
            ViewBag.NfcSupport = deviceInfo.GetCapability("nfc_support");
            ViewBag.Sms = deviceInfo.GetCapability("sms_enabled");
                
            return View();
        }
    }
}
