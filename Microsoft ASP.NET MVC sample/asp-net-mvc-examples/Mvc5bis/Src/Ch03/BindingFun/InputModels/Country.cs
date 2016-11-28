using System;

namespace BindingFun.InputModels
{
    public class Country  
    {
        public Country()
        {
            Details = new CountryInfo();
        }
        public String Name { get; set; }
        public CountryInfo Details { get; set; }
    }
}