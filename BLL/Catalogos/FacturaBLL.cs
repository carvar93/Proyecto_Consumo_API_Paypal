using DAL.Catalogos;
using DataAccess.AccesoApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace BLL.Catalogos
{
    public class FacturaBLL
    {
        #region Metodos para conectar al Api

        public async Task<List<FacturaDAL>> FiltrarFactura(FacturaDAL oFacturaDAL)
        {
            var oFactura = new FacturaApi();

            return await oFactura.FiltrarFacturas(oFacturaDAL);
        }



        //transacciones

        public async Task<List<int>> ListarTransaccion()
        {
            var oTransaccion = new FacturaApi();

            return await oTransaccion.ListarTransaccion();
        }


        //limpiar transaccion
        public async Task LimpiarTransaccion(FacturaDAL factura)
        {
            var oTransaccion = new FacturaApi();

             await oTransaccion.LimpiarTransaccion(factura);
        }

        //consultar usuario para crear la factura

        public async Task<List<UsuarioDAL>> ListarUsuarios()
        {
            var oTransaccion = new FacturaApi();

            return await oTransaccion.ListarUsuarios();
        }

        //agregar factura

        public async Task<bool> AgregarFactura(FacturaDAL oFacturaDAL)
        {
            var oEstadoUsuarioAccess = new FacturaApi();

            return await oEstadoUsuarioAccess.AgregarFactura(oFacturaDAL);
        }

        //enviar Factura
        public void  EnviarFactura(UsuarioDAL u,decimal total )
        {

            string EmailDestino = "cavaal93@gmail.com";
            string EmailOrigen = "prograAvanzadaPayPal@gmail.com";
            string key = "CXAS85";
            //string url = "http://localhost:64514/PasswordRecovery/NuevaContraseña/?token=" + token;
            MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Key",
                "<p></p>" + "<a href='" + key + "'></a>"+u._Nombre+"factura digital"+total);

            oMailMessage.IsBodyHtml = true;

            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
            oSmtpClient.EnableSsl = true;
            oSmtpClient.UseDefaultCredentials = false;

            oSmtpClient.Port = 587;
            oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, key);

            oSmtpClient.Send(oMailMessage);


        }


        #endregion
    }
}
