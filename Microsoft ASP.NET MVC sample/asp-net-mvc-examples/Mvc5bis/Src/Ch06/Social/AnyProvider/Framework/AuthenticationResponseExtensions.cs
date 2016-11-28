using System;
using System.Web;
using System.Web.Security;
using DotNetOpenAuth.OpenId.RelyingParty;

namespace AnyProvider.Framework
{
    public static class AuthenticationResponseExtensions
    {
        public static HttpCookie CreateAuthCookie(this IAuthenticationResponse response, Boolean persistent = true, UserNameAdapterDelegate fnAdapter = null)
        {
            var userName = response.ClaimedIdentifier;
            var userDisplayName = response.FriendlyIdentifierForDisplay;
            if (fnAdapter != null)
                userDisplayName = fnAdapter(userDisplayName);

            return CreateAuthCookie(userName, userDisplayName, persistent);
        }

        private static HttpCookie CreateAuthCookie(String username, String userDisplayName, Boolean persistent)
        {
            // Let ASP.NET create a regular auth cookie  
            var cookie = FormsAuthentication.GetAuthCookie(username, persistent);

            // Modify the cookie to add a friendly name 
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            var newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, userDisplayName);
            cookie.Value = FormsAuthentication.Encrypt(newTicket);

            return cookie;
        }
    }
}