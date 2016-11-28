using System.Web.Mvc;
using DotNetOpenAuth.OpenId.RelyingParty;

namespace AnyProvider.Framework
{
    public class OpenIdController : Controller
    {
        protected static OpenIdRelyingParty RelyingParty = new OpenIdRelyingParty();

    }
}