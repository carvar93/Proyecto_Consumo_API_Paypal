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
    public class TarjetaApi
    {
        #region METODOS PRIVADOS
        private HttpClient cliente = new HttpClient();

        /// <summary>
        /// Inivializa los datos para las peticiones del cliente
        /// </summary>
        private void InicializadorTarjeta()
        {
            cliente.BaseAddress = new Uri("https://localhost:82");
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
        }
        #endregion

        #region METODOS PUBLICOS

       
        public async Task<List<TarjetaDAL>> ListarTarjeta()
        {
            InicializadorTarjeta();
            string url = "https://localhost:82/api/Tarjetas/ListarTarjetas";
            List<TarjetaDAL> lstTarjetas = new List<TarjetaDAL>();

            try
            {
                HttpResponseMessage respuesta = await cliente.GetAsync(url);
                if (respuesta.IsSuccessStatusCode)
                {
                    var jsonString = await respuesta.Content.ReadAsStringAsync();
                    lstTarjetas = JsonConvert.DeserializeObject<List<TarjetaDAL>>(jsonString);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstTarjetas;
        }

     
        public async Task<bool> AgregarTarjeta(TarjetaDAL oTarjetaDAL)
        {
            InicializadorTarjeta();
            string url = "https://localhost:82/api/tarjeta/AgregarTarjeta";
            try
            {
                HttpResponseMessage respuesta = await cliente.PostAsJsonAsync(url, oTarjetaDAL);
                return respuesta.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        public async Task<bool> ModificarTarjeta(TarjetaDAL oTarjetaDAL)
        {
            InicializadorTarjeta();
            string url = "https://localhost:82/api/tarjeta/ActualizarTarjeta";
            try
            {
                HttpResponseMessage respuesta = await cliente.PostAsJsonAsync(url, oTarjetaDAL);
                return respuesta.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public async Task<bool> EliminarTarjeta(TarjetaDAL oTarjetaDAL)
        {
            InicializadorTarjeta();
            string url = "https://localhost:82/api/Tarjetas/EliminarTarjetas";
            try
            {
                HttpResponseMessage respuesta = await cliente.PostAsJsonAsync(url, oTarjetaDAL);
                return respuesta.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<TarjetaDAL> FiltrarTarjeta(TarjetaDAL oTarjetaDAL)
        {
            InicializadorTarjeta();
            string url = "https://localhost:82/api/tarjeta/FiltrarTarjeta";
            TarjetaDAL Tarjeta = new TarjetaDAL();
            try
            {
                HttpResponseMessage respuesta = await cliente.PostAsJsonAsync(url, oTarjetaDAL);
                if (respuesta.IsSuccessStatusCode)
                {
                    var jsonString = await respuesta.Content.ReadAsStringAsync();
                    Tarjeta = JsonConvert.DeserializeObject<TarjetaDAL>(jsonString);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Tarjeta;
        }
        #endregion
    }
}
