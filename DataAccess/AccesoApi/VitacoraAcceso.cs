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
    public class VitacoraAcceso
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
        public async Task<List<VitacoraDAL>> ListarVitacora()
        {
            InicializadorTarjeta();
            string url = "https://localhost:82/api/vitacora/ListarVitacora";
            List<VitacoraDAL> lstVitacora = new List<VitacoraDAL>();

            try
            {
                HttpResponseMessage respuesta = await cliente.GetAsync(url);
                if (respuesta.IsSuccessStatusCode)
                {
                    var jsonString = await respuesta.Content.ReadAsStringAsync();
                    lstVitacora = JsonConvert.DeserializeObject<List<VitacoraDAL>>(jsonString);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstVitacora;
        }
        #endregion
    }
}
