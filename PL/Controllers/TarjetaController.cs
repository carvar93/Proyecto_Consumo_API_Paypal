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
    public class TarjetaController : Controller
    {
        // GET: Tarjeta
        public async Task<ActionResult> CrearModificar()
        {
            UsuarioDAL oUsuarioDal = new UsuarioDAL();
            TarjetaDAL oTarjetaDal = new TarjetaDAL();
            TarjetaBLL oTarjetaBll = new TarjetaBLL();


            try
            {
                oUsuarioDal = (UsuarioDAL)Session["usuario"];
                oTarjetaDal.id_usuario = oUsuarioDal._Id;
                var tarjeta = await oTarjetaBll.FiltrarTarjeta(oTarjetaDal);
                oTarjetaDal = tarjeta;
                if (oTarjetaDal.id_tarjeta >= 1)
                {
                    ViewBag.accion = "modificar";
                }
                else
                {
                    ViewBag.accion = "crear";
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = "No se pudo cargar la tarjeta: "+ex.Message;
            }

            return View(oTarjetaDal);
        }




        [HttpPost]
        public async Task<ActionResult> Crear(TarjetaDAL oTarjetaDal)
        {
            if (!ModelState.IsValid)
            {
                return View("CrearModificar",oTarjetaDal);
            }
            UsuarioDAL oUsuarioDal = new UsuarioDAL();
            TarjetaBLL oTarjetaBLL = new TarjetaBLL();

            try
            {
                oUsuarioDal = (UsuarioDAL)Session["usuario"];
                oTarjetaDal.id_usuario = oUsuarioDal._Id;
                await oTarjetaBLL.AgregarTarjeta(oTarjetaDal);
                ViewBag.mensaje = "¡Tarjeta guardada con éxito! ";
            }
            catch (Exception ex)
            {
                ViewBag.error = "No se pudo guardar la tarjeta: "+ex.Message;
            }

            return View("CrearModificar");
        }


        
        [HttpPost]
        public async Task<ActionResult> Modificar(TarjetaDAL oTarjetaDal)
        {
            if (!ModelState.IsValid)
            {
                return View("CrearModificar",oTarjetaDal);
            }
            TarjetaBLL oTarjetaBLL = new TarjetaBLL();

            try
            {
                await oTarjetaBLL.ModificarTarjeta(oTarjetaDal);
                ViewBag.mensaje = "¡Tarjeta actualizada con éxito! ";
            }
            catch (Exception ex)
            {
                ViewBag.error = "No se pudo guardar la tarjeta: " + ex.Message;
            }

            return View("CrearModificar");
        }
    }
}