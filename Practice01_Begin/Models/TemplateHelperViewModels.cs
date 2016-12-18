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
        [Display(Name = "int型(DataType.Text")]
        [DataType(DataType.Text)]
        public int IntValue { get; set; }

        [Display(Name = "string型(DataType.Html")]
        [DataType(DataType.Html)]
        public string StringValue { get; set; }

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