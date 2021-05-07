using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models.ViewModels
{
    public class usuarioViewModel
    {
        [Display(Name = "ID")]
        public int _Id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string _Nombre { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        public string _Apellido { get; set; }
        [Required]
        [Display(Name = "Cédula")]
        public int _Cedula { get; set; }
        [Required]
        [Display(Name = "Tel")]
        public string _Telefono { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string _Correo { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        public string _User { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        public string _Pass { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public bool _Estado { get; set; }
    }
}