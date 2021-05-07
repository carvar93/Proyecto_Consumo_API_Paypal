using DAL.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Controllers;

namespace UI.Filters
{
    public class SessionFilter : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var usuario = (UsuarioDAL)HttpContext.Current.Session["usuario"];

            if (usuario == null)
            {
                if (filterContext.Controller is SigninController == false )
                {
                    if (filterContext.Controller is SignupController == false)
                    {
                        if (filterContext.Controller is PasswordRecoveryController == false)
                        {
                            filterContext.HttpContext.Response.Redirect("~/Signin/LoginView"); 
                        }
                    }
                }
            }

            base.OnResultExecuting(filterContext);
        }
    }
}