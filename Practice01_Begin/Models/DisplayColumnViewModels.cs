using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Practice01_Begin.Models
{
    public class DisplayColumnHedViewModel
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<DispalyColumnBodyViewModel> Bodys { get; set; }
    }

    [DisplayColumn("Name")]
    public class DispalyColumnBodyViewModel
    {
        public int ID { get; set;}
        public string Name { get; set; }

    }
}