using System;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.RelyingParty;

namespace AnyProvider.Framework
{
    public static class OpenIdRelyingPartyExtensions
    {
        public static Boolean IsValid(this OpenIdRelyingParty relyingParty, String url)
        {
            Identifier id;
            var result = Identifier.TryParse(url, out id);
            return result;
        }
    }
}