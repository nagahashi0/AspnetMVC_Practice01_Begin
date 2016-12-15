using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Practice01_Begin.Models
{
    public class HtmlHelperViewModels
    {
        public string LabelText { get; set; }
        public string TextBoxText { get; set; }
        public string TextAreaText { get; set; }
        public string PasswordText { get; set; }
        public string HiddenValue { get; set; }
        public string RadioValue { get; set; }
        public bool CheckBoxValueA { get; set; }
        public bool CheckBoxValueB { get; set; }
        public bool CheckBoxValueC { get; set; }
        public string DropDownValue { get; set; }
        public string[] ListBoxValues { get; set; }
        public WeekdayType EnumValue { get; set; }
    }

    public enum WeekdayType
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    };
}