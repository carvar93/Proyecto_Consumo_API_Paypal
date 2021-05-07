using BLL.Catalogos;
using DAL.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI.Models.ViewModels;

namespace UI.Controllers
{
    public class SignupController : Controller
    {
        public ActionResult agregarUsuario()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> agregarUsuario(usuarioViewModel oModel)
        {
            if (!ModelState.IsValid)
            {
                return View(oModel);
            }
            UsuarioBLL oUsuarioBll = new UsuarioBLL();
            UsuarioDAL oUsuarioDal = new UsuarioDAL();

            oUsuarioDal._Nombre = oModel._Nombre;
            oUsuarioDal._Apellido = oModel._Apellido;
            oUsuarioDal._Cedula = oModel._Cedula;
            oUsuarioDal._Telefono = oModel._Telefono;
            oUsuarioDal._Correo = oModel._Correo;
            oUsuarioDal._User = oModel._User;
            oUsuarioDal._Pass = oModel._Pass;
            oUsuarioDal._Estado = true;

            try
            {
                await oUsuarioBll.AgregarUsuario(oUsuarioDal);
                Session["usuario"] = oUsuarioDal;
                Session["nombre"] = oUsuarioDal._User;
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}