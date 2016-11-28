using System;

namespace DataAnnotations.ViewModels.Customer
{
    //[DisplayColumn("FullName")]   // Takes precedence over ToString
    public class ContactInfo
    {
        public String FullName { get; set; }
        public String PhoneNumber { get; set; }
        public String Email { get; set; }
        public override string ToString()
        {
            return "This is what I am";
        }
    }
}
