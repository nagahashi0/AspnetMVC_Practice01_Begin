using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAnnotations.ViewModels.Customer
{
    public class CustomerViewModel : ViewModelBase
    {
        [DisplayName("Company ID")]
        [ReadOnly(true)]
        public Int32 Id { get; set; }

        [DisplayName("Is Company")]
        public Boolean IsCompany { get; set; }

        [DisplayFormat(NullDisplayText = "(empty)")]
        [Required]
        public String Name { get; set; }

        [DataType(DataType.MultilineText)]
        public String Notes { get; set; }

        [UIHint("my_date_template")]
        public DateTime Foundation { get; set; }

        [DataType(DataType.Url)]
        public String Website { get; set; }

        [DisplayName("Reliable?")]
        public Boolean? Reliable { get; set; }

        public ContactInfo Contact { get; set; }
    }
}
