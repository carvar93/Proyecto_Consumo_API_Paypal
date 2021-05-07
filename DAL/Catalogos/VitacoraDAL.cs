using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Catalogos
{
    public class VitacoraDAL
    {
        public string Id { get; set; }
        [Display(Name = "Acción reealizada")]
        public string Accion { get; set; }
        public DateTime Fecha { get; set; }
        [Display(Name = "Observaciónes")]
        public string Observacion { get; set; }
    }
}
