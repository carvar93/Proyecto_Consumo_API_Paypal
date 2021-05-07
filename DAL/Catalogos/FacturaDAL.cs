using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Catalogos
{
    public class FacturaDAL
    {


        #region Atributos
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }

        [Display(Name = "ID Usuario")]
        public int Id_Usuario { get; set; }

        [Display(Name = "Producto")]
        public string Producto { get; set; }

        [Display(Name = "Total")]
        public decimal Total { get; set; }
        #endregion

        public FacturaDAL()
        {
           
            Fecha = DateTime.MinValue;
            this.Id_Usuario = 0;
         
            Producto = string.Empty;
            Total = 0;
        }
    }
}
