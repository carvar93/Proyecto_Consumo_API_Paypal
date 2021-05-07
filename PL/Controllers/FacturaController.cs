using BLL.Catalogos;
using DAL.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI.Controllers;

namespace UI.Controllers
{
    public class FacturaController : Controller
    {
        // GET: Factura
        public async Task<ActionResult> FiltrarFactura()
        {
            UsuarioDAL oUsuarioDAL = new UsuarioDAL();
            FacturaDAL oFacturaDAL = new FacturaDAL();
            FacturaBLL oFacturaBLL = new FacturaBLL();
            List<FacturaDAL> lstFactura = new List<FacturaDAL>();
            oUsuarioDAL = (UsuarioDAL)Session["usuario"];
            ViewBag.usuario = oUsuarioDAL._User;
            oFacturaDAL.Id_Usuario = oUsuarioDAL._Id;

            try
            {
                lstFactura = await oFacturaBLL.FiltrarFactura(oFacturaDAL);
            }
            catch (Exception ex)
            {
                ViewBag.error = "No se pudo listar las facturas." + ex.Message;
            }

            return View(lstFactura);
        }



        public ActionResult InformacionCompra() {

            
            
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Pagar()
        {
            FacturaDAL factura = new FacturaDAL();
            UsuarioDAL usuario = new UsuarioDAL();
            UsuarioDAL usuarioSe = new UsuarioDAL();

            TarjetaDAL tarjeta = new TarjetaDAL();
            TarjetaDAL tarjeta2 = new TarjetaDAL();

            FacturaBLL facturabll = new FacturaBLL();
            TarjetaBLL tarjetabll = new TarjetaBLL();
           
            
            List<UsuarioDAL> listaUsuario = new List<UsuarioDAL>();
            List<int> listatransaccion = new List<int>();
            List<TarjetaDAL> listaTarjeta = new List<TarjetaDAL>();


            try
            {

           
            listaUsuario = await facturabll.ListarUsuarios();
            
            //armar la factura-
            object a= Session["usuario"];
            usuarioSe = (UsuarioDAL)a;
            foreach (var item in listaUsuario)
            {
                if (item._User == usuarioSe._User)
                {
                    usuario._Cedula = item._Cedula;
                    usuario._Correo = item._Correo;
                    usuario._Id = item._Id;
                }
            }

            //fecha
            factura.Fecha = DateTime.Now;
            //usuario
            factura.Id_Usuario = usuario._Id;
            //producto
            factura.Producto = "videoJuego ";
            
            //total
            listatransaccion=await facturabll.ListarTransaccion();
            foreach (var item in listatransaccion)
            {
                factura.Total = Int32.Parse(item.ToString());
            }
           //actualizar saldo tarjeta
            tarjeta.id_usuario = usuario._Id;
            tarjeta2 = await tarjetabll.FiltrarTarjeta(tarjeta);
            tarjeta2.Saldo = tarjeta2.Saldo - factura.Total;
          
            //agrego nuevo saldo de tarjeta

            await tarjetabll.ModificarTarjeta(tarjeta2);


            //agregar la factura
            await facturabll.AgregarFactura(factura);

                //enviar por correo la factura y key del juego
               // facturabll.EnviarFactura(usuario, factura.Total);

            }
            catch (Exception)
            {

                throw;
            }
           return RedirectToAction("OrdenCompletada", "Factura");
          
        }

        //abrir ventana de confirmacion
        public ActionResult OrdenCompletada()
        {
            
            return View();
        }


        [HttpPost]
        public async Task <ActionResult> RedirigirTienda()
        {

            FacturaDAL f = new FacturaDAL();
            //limpiar transaccion
            FacturaBLL facturabll = new FacturaBLL();
            await facturabll.LimpiarTransaccion(f);


            //REDERIGIR A LA PAGINA DE VIDEOJUEGOS
             return RedirectToAction("Registro","Home");
          
        }



    }
}