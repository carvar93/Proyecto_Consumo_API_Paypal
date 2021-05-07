using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Catalogos;
using BLL.Catalogos;
using System.Threading.Tasks;
using UI.Models.ViewModels;

namespace UI.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult ActualizarUsuario()
        {
            UsuarioDAL oUsuarioDal = new UsuarioDAL();
            oUsuarioDal = (UsuarioDAL)Session["usuario"];
            return View(oUsuarioDal);
        }
        [HttpPost]
        public async Task<ActionResult> ActualizarUsuario(UsuarioDAL oUsuarioDal)
        {
            if (!ModelState.IsValid)
            {
                return View(oUsuarioDal);
            }
            UsuarioBLL oBll = new UsuarioBLL();
            try
            {
                if (await oBll.ModificarUsuario(oUsuarioDal))
                {
                    Session["usuario"] = null;
                    Session["usuario"] = oUsuarioDal;
                    Session["nombre"] = oUsuarioDal._User;
                    ViewBag.message = "Usuario modificado exitósamente";
                }
                else
                {
                    ViewBag.error = "No se pudo modificar el usuario";
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = "Error: "+ex.Message;
            }
            return View();
        }



        public ActionResult CambiarContraseña()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CambiarContraseña(RecoveryChangeViewModel oModel)
        {
            if (!ModelState.IsValid)
            {
                return View(oModel);
            }
    
            UsuarioDAL oDal = new UsuarioDAL();
            oDal = (UsuarioDAL)Session["usuario"];


            UsuarioBLL oBll = new UsuarioBLL();
            oDal._Pass = oModel.Password;
            try
            {
                await oBll.CambiarContraseña(oDal);
                ViewBag.message = "Contraseña modificada exitosamente";
            }
            catch (Exception ex)
            {
                ViewBag.error = "Error: "+ex.Message;
            }
            return View();
        }
    }
}