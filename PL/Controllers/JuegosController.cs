using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Catalogos;
using System.Threading.Tasks;
using DAL.Catalogos;
namespace PL.Controllers

{
    public class JuegosController : Controller
    {
        // GET: Juegos
        public ActionResult Index()
        {
            return View();
        }




        public ActionResult MachinariumInfo()
        {
            return View();
        }

        public ActionResult ConfirmacionCompra()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> AgregarTransaccion() {
            bool estado = true;
            TransaccionBLL tr = new TransaccionBLL();
            FacturaDAL factura = new FacturaDAL();
            factura.Total = 16;
            //1 forma
          //  Response.Redirect("https://www.w3schools.com/tags/att_button_formtarget.asp");
            //segunda es por javascript
            await tr.AgregarTransaccion(factura);

            //System.Diagnostics.Process.Start("https://social.msdn.microsoft.com/Forums/es-ES/38ef9758-385f-4b2c-9e56-08b095e8d331/abrir-pagina-web-desde-aplicacion-de-escritorio?forum=vcses");



            //antes de redireccionar consultar si se hizo la compar o no 

            //estado=await tr.ConsultarTransaccion();
            //if(estado)
            //return RedirectToAction("OrdenConfirmada", "Juegos");
            //else

            //login
            return RedirectToAction("LoginView", "Signin");
           
        }


    }
}