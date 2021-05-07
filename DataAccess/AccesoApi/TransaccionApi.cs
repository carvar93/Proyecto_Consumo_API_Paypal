using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Catalogos;
using System.Net.Http;

using Newtonsoft.Json;

namespace DataAccess.AccesoApi
{
   public class TransaccionApi
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




        public async Task<List<FacturaDAL>> ConsultarTransaccion()
        {
            InicializazdorCliente();
            string url = "https://localhost:82/api/Compra/ConsultarTransaccion";
            List<FacturaDAL> lsttransaccion = new List<FacturaDAL>();

            try
            {
                HttpResponseMessage respuesta = await cliente.GetAsync(url);
                if (respuesta.IsSuccessStatusCode)
                {
                    var jsonString = await respuesta.Content.ReadAsStringAsync();
                    lsttransaccion = JsonConvert.DeserializeObject<List<FacturaDAL>>(jsonString);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lsttransaccion;
        }


        /// <summary>
        /// Agrega una aeronave a la bd por medio de un apoi request
        /// </summary>
        /// <param name="oAeronaveDAL">Contiene el objeto con todos los datos que vamos a agregar</param>
        /// <returns>retorna true si hubo exito, false lo contrario</returns>
        public async Task<bool> AgregarTransaccion(FacturaDAL transaccion)
        {
            InicializazdorCliente();
            string url = "https://localhost:82/api/compra/AgregarTransaccion";
            try
            {
                HttpResponseMessage respuesta = await cliente.PostAsJsonAsync(url, transaccion);
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
