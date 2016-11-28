using System;
using System.ComponentModel.DataAnnotations;

namespace AnyProvider.ViewModels.Auth
{
    public class LogOnViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public String UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public String Password { get; set; }

        [Display(Name = "Remember me?")]
        public Boolean RememberMe { get; set; }
    }
}
