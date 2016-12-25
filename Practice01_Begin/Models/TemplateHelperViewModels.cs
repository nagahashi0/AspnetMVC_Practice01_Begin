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

    public enum WeweathereType
    {
        [Display(Name = "晴れ")]
        sunny,
        [Display(Name = "曇")]
        cloudy,
        [Display(Name = "雨")]
        rainy
    }
   
    public class DisplayForViewModel
    {
        [Display(Name ="String型")]
        public string StringValue { get; set; }

        [Display(Name = "int型")]
        public int IntValue { get; set; }

        [Display(Name = "long型")]
        public long LongValue { get; set; }

        [Display(Name = "decimal型")]
        public decimal DecimalValue { get; set; }

        [Display(Name = "DateTime型")]
        public DateTime DateTimeValue { get; set; }

        [Display(Name = "bool型")]
        public bool BoolValue { get; set; }

        [Display(Name = "bool(Nullable)型")]
        public bool? NullableBoolValue { get; set; }

        [Display(Name = "enum型")]
        public WeweathereType EnumValue { get; set; }  
    }

    public class AttributeModel
    {
        [Display(Name = "int型(DataType.Text)")]
        [DataType(DataType.Text)]
        public int IntValue { get; set; }

        [Display(Name = "string型(DataType.Html)")]
        [DataType(DataType.Html)]
        public string HtmlValue { get; set; }

        [Display(Name = "string型(DataType.MultilineText)")]
        [DataType(DataType.MultilineText)]
        public string MultilineTextValue { get; set; }

        [Display(Name = "string型(DataType.EmailAddress)")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddressValue { get; set; }

        [Display(Name = "string型(DataType.Url)")]
        [DataType(DataType.Url)]
        public string UrlValue { get; set; }

        [Display(Name = "string型(DataType.Password)")]
        [DataType(DataType.Password )]
        public string PasswordValue { get; set; }

        [Display(Name = "string型(DataType.PhoneNumber)")]
        [DataType(DataType.PhoneNumber )]
        public string PhoneNumberValue { get; set; }

        [Display(Name = "string型(DataType.PostalCode)")]
        [DataType(DataType.PostalCode)]
        public string PostalCodeValue { get; set; }

        [Display(Name = "string型(DataType.CreditCard)")]
        [DataType(DataType.CreditCard)]
        public string CreditCardValue { get; set; }

        [Display(Name = "DateTime(DataType.DateTme)")]

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yy年MM月dd日}", ApplyFormatInEditMode = true)]
        public DateTime DateTimeValue { get; set; }

        [Display(Name = "DateTime(DataType.Date)")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日}", ApplyFormatInEditMode = true)]
        public DateTime DateValue { get; set; }

        [Display(Name = "DateTime(DataType.Time)")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime TimeValue { get; set; }

        [Display(Name = "Decimal(DataType.Currency)")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:#,##0.000}", ApplyFormatInEditMode = true)]
        public Decimal CurrencyValue { get; set; }

        [Display(Name = "Decimal(DataType.Duration)")]
        [DataType(DataType.Duration)]
        public Decimal  DurationValue { get; set; }
    }


    public class MyClass
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class HelperViewModel
    {
        [Display(Name = "クラス型")]
        public MyClass MyClassValue { get; set; }
        
        [Display(Name = "string型のList")]
        public List<string> StringList { get; set; }

        [Display(Name = "MyClass型のList")]
        public List<MyClass> MyClassList { get; set; }

    }
}