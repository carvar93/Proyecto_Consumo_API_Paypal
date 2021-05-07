using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Catalogos
{
    public class TarjetaDAL
    {
        #region Atributos
        public int id_tarjeta { get; set; }

        public int id_usuario {get; set;}

        [Display(Name = "Número Tarjeta")]
        public int Numero { get; set; }

        [Display(Name = "Código")]
        public int Cod { get; set; }

        [Display(Name = "Usuario")]
        public string Nombre_Usuario { get; set; }

        [Display(Name = " Fecha Vencimiento")]
        public DateTime Fecha_Vencimiento { get; set; }

        [Display(Name = "Saldo")]
        public decimal Saldo { get; set; }

        #endregion
    }
}
