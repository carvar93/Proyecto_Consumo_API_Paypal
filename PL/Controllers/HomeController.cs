using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BLL.Catalogos;
using DAL.Catalogos;
using UI.Models.ViewModels;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {

            List<int> lt = new List<int>();
            FacturaBLL facturabll = new FacturaBLL();
            lt = await facturabll.ListarTransaccion();

            if (lt.Count() > 0)
            {
                return RedirectToAction("InformacionCompra", "Factura");
            }
            else
                return View();
           
        }
        public async Task<ActionResult> Registro()
        {
            List<int> lt = new List<int>();
            FacturaBLL facturabll = new FacturaBLL();
            lt = await facturabll.ListarTransaccion();

            if (lt.Count() > 0)
            {
                return RedirectToAction("InformacionCompra", "Factura");
            }
            else
                return View();
        }



    }
}