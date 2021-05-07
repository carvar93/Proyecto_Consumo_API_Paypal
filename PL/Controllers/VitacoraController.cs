using BLL.Catalogos;
using DAL.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class VitacoraController : Controller
    {
        // GET: Vitacora
        public async Task<ActionResult> ListarVitacora()
        {
            List<VitacoraDAL> lstVitacora = new List<VitacoraDAL>();
            VitacoraBLL oBLL = new VitacoraBLL();
            try
            {
                lstVitacora = await oBLL.ListarViacora();
            }
            catch (Exception ex)
            {
                ViewBag.error = "Error al cargar la vitacora: "+ ex.Message;
            }
            return View(lstVitacora);
        }
    }
}