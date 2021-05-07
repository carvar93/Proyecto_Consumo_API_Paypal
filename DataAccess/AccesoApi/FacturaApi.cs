using DAL.Catalogos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AccesoApi
{
    public class FacturaApi
    {
        #region METODOS PRIVADOS
        private HttpClient cliente = new HttpClient();

        /// <summary>
        /// Inivializa los datos para las peticiones del cliente
        /// </summary>
        private void InicializazdorCliente()
        {
            cliente.BaseAddress = new Uri("https://localhost:82");
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
        }
        #endregion

        #region METODOS PUBLICOS
        public async Task<List<FacturaDAL>> FiltrarFacturas(FacturaDAL oFacturaDAL)
        {
            InicializazdorCliente();
            string url = "https://localhost:82/api/Factura/FiltrarFactura";
            List<FacturaDAL> lstPaises = new List<FacturaDAL>();

            try
            {
                HttpResponseMessage respuesta = await cliente.PostAsJsonAsync(url, oFacturaDAL);
                if (respuesta.IsSuccessStatusCode)
                {
                    var jsonString = await respuesta.Content.ReadAsStringAsync();
                    lstPaises = JsonConvert.DeserializeObject<List<FacturaDAL>>(jsonString);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstPaises;
        }


        //transaccion

        //verificar si hay una transaccion en proceso 
        public async Task<List<int>> ListarTransaccion()
        {
            InicializazdorCliente();
            string url = "https://localhost:82/api/compra/ConsultarTransaccion";
            List<int> listaTransaccion = new List<int>();

            try
            {
                HttpResponseMessage respuesta = await cliente.GetAsync(url);
                if (respuesta.IsSuccessStatusCode)
                {
                    var jsonString = await respuesta.Content.ReadAsStringAsync();
                    listaTransaccion = JsonConvert.DeserializeObject<List<int>>(jsonString);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listaTransaccion;
        }


        //limpiar la transaccion
        public async Task<bool> LimpiarTransaccion(FacturaDAL factura )
        {
            InicializazdorCliente();
            string url = "https://localhost:82/api/compra/LimpiarTransaccion";
            try
            {
                HttpResponseMessage respuesta = await cliente.PostAsJsonAsync(url, factura);
                return respuesta.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




        //cosultar usuarios
        public async Task<List<UsuarioDAL>> ListarUsuarios()
        {
            InicializazdorCliente();
            string url = "https://localhost:82/api/usuarios/ListarUsuarios";
            List<UsuarioDAL> listaTransaccion = new List<UsuarioDAL>();

            try
            {
                HttpResponseMessage respuesta = await cliente.GetAsync(url);
                if (respuesta.IsSuccessStatusCode)
                {
                    var jsonString = await respuesta.Content.ReadAsStringAsync();
                    listaTransaccion = JsonConvert.DeserializeObject<List<UsuarioDAL>>(jsonString);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listaTransaccion;
        }


        public async Task<bool> AgregarFactura(FacturaDAL oFacturaDAL)
        {
            InicializazdorCliente();
            string url = "https://localhost:82/api/factura/AgregarFactura";
            try
            {
                HttpResponseMessage respuesta = await cliente.PostAsJsonAsync(url, oFacturaDAL);
                return respuesta.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }





        #endregion
    }
}
