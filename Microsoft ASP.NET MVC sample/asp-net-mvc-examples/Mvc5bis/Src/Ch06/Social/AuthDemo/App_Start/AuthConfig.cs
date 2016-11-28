using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using AuthDemo.Models;

namespace AuthDemo
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            OAuthWebSecurity.RegisterTwitterClient(
                consumerKey: "45c6YShkzjXQgbeCbK3UiQ",
                consumerSecret: "pRcoXTnmtM3VoF5DXD3MEI6vhtXMkn7BJlQtUkdnU");

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "158029597675501",
                appSecret: "cba228f0294672f1e4472fdebd6df011");

            //OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
