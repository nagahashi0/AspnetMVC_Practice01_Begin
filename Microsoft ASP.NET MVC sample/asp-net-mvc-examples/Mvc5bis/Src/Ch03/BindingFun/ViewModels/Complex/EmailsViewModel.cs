using System;
using System.Collections.Generic;

namespace BindingFun.ViewModels.Complex
{
    public class EmailsViewModel : ViewModelBase
    {
        public EmailsViewModel()
        {
            Emails = new List<String>();
            RegisteredEmails = new List<String>();
        }

        public IList<String> Emails { get; set; }
        public IList<String> RegisteredEmails { get; set; }
    }
}
