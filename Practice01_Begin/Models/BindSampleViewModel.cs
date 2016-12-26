using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Practice01_Begin.Models
{
    public class BindSampleViewModel
    {
        [Display(Name = "string値")]
        public string StringValue { get; set; }

        [Display(Name = "int値")]
        public int? IntValue { get; set; }

        [Display(Name = "重要な値")]
        public string ImportantValue { get; set; }
    }
}