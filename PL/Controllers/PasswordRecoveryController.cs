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
    public class PasswordRecoveryController : Controller
    {
        // GET: PasswordRecovery
        public ActionResult NuevaContraseña(string token)
        {
            RecoveryChangeViewModel oModel = new RecoveryChangeViewModel();
            oModel.Token = token;
            return View();
        }


        /// <summary>
        /// Metodo para cambiar contraseña cuando se recupera contraseña
        /// </summary>
        /// <param name="oModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> NuevaContraseña(RecoveryChangeViewModel oModel)
        {
            if (!ModelState.IsValid)
            {
                return View(oModel);
            }

            UsuarioDAL oDal = new UsuarioDAL();
            UsuarioBLL oBll = new UsuarioBLL();
            oDal._Pass = oModel.Password;
            oDal.tokenRecovery = oModel.Token;
            try
            {
                await oBll.CambiarContraseña(oDal);
                ViewBag.message = "Contraseña modificada exitosamente";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View();
        }


        public ActionResult RecuperarContraseña()
        {
            return View();
        }


        
        [HttpPost]
        public async Task<ActionResult> RecuperarContraseña(PasswordRecoveryViewModel oModel)
        {
            if (!ModelState.IsValid)
            {
                return View(oModel);
            }

            UsuarioDAL oDal = new UsuarioDAL();
            UsuarioBLL oBll = new UsuarioBLL();
            oDal._Correo = oModel.Email;
            Random aleatorio = new Random();
            oDal.tokenRecovery = aleatorio.Next(1,100000).ToString();
            try
            {
                await oBll.RecuperarContraseña(oDal);
                ViewBag.message = "El link de recuperación fue enviado al correo electrónico";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View();
        }
    }
}