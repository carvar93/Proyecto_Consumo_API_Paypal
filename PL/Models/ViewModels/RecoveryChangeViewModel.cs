using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models.ViewModels
{
    public class RecoveryChangeViewModel
    {
        public string Token { get; set; }
        [Required]
        [Display(Name ="Contraseña")]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [Display(Name ="Nueva contraseña")]
        public string ConPassword { get; set; }

    }
}