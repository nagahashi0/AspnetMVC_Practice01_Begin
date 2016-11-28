using System;
using System.Collections.Generic;
using System.Web;

namespace SampleApp.Tests.Helpers
{
    public class FakeSession : HttpSessionStateBase
    {
        private readonly Dictionary<String, Object> _sessionItems =
                                                  new Dictionary<String, Object>();

        public override void Add(String name, Object value)
        {
            _sessionItems.Add(name, value);
        }

        public override Object this[String name]
        {
            get 
            {
                return _sessionItems.ContainsKey(name) ? _sessionItems[name] : null;
            }
            set
            {
                _sessionItems[name] = value;
            }
        }
    }
}