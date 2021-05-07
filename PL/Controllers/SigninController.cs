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
    public class SigninController : Controller
    {
        public ActionResult LoginView()
        {
            return View();
        }


        public async Task<ActionResult> Login(string user, string pass)
        {
            List<UsuarioDAL> lstUsuario = new List<UsuarioDAL>();
            UsuarioBLL oUsuarioBll = new UsuarioBLL();
            UsuarioDAL oUsuarioDal = new UsuarioDAL();
            oUsuarioDal._User = user;
            oUsuarioDal._Pass = pass;
            try
            {
                lstUsuario = await oUsuarioBll.Login(oUsuarioDal);
                if (lstUsuario.Count > 0)
                {
                    Session["usuario"] = lstUsuario.First();
                    Session["nombre"] = lstUsuario.First()._User;
                    return Content("1");
                }
                else
                {
                    return Content("Usuario inválido");
                }
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error al iniciar sesión: " + ex.Message);
            }
        }

        public ActionResult Logout()
        {
            Session["usuario"] = null;
            Session["perfilUsuario"] = null;
            Session["nombre"] = null;
            return RedirectToAction("Login", "Signin");
        }
    }
}