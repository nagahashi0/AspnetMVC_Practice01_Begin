using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Practice01_Begin.Models
{
    
    public class TemplateHelperViewModel
    {
        public string Text1 { get; set; }

        [DisplayName("テキスト2")]
        public string Text2 { get; set; }

        [Display(Name = "テキスト3",ShortName ="テキ3")]
        public string Text3 { get; set; }

    }

    public class DisplayForViewModel
    {

        public bool BoolValue { get; set; }

        public bool? NullableBoolValue { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailValue { get; set; }

        [DataType(DataType.Url)]
        public string UrluelValue { get; set; }

        [DataType(DataType.Html)]
        public string HtmlValue { get; set; }

        [DataType(DataType.CreditCard )]
        [DataType(DataType.Currency )]
        [DataType(DataType.Date )]
        [DataType(DataType.Duration )]
        [DataType(DataType.ImageUrl )]
        [DataType(DataType.MultilineText )]
        [DataType(DataType.Password )]
        [DataType(DataType.PhoneNumber )]
        [DataType(DataType.PostalCode )]
        [DataType(DataType.Text )]
        [DataType(DataType.Time )]
        [DataType(DataType.Upload )]
        [DataType(DataType.Url)]
    }
}