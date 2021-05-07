using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Catalogos
{
    public class UsuarioDAL
    {
        #region Atributos
        [Display(Name = "ID")]
        public int _Id { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        public string _Nombre { get; set; }
        [Display(Name = "Apellido")]
        [Required]
        public string _Apellido { get; set; }
        [Display(Name = "Cédula")]
        [Required]
        public int _Cedula { get; set; }
        [Display(Name = "Teléfono")]
        [Required]
        public string _Telefono { get; set; }
        [Display(Name = "Correo")]
        [Required]
        public string _Correo { get; set; }
        [Display(Name = "Usuario")]
        [Required]
        public string _User { get; set; }
        [Display(Name = "Contraseña")]
        [Required]
        public string _Pass { get; set; }
        [Display(Name = "Estado")]
        [Required]
        public bool _Estado { get; set; }
        public string tokenRecovery { get; set; }
        #endregion

    }
}
