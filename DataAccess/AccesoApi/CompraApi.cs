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
    public class CompraApi
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

        /// <summary>
        /// lista todos los TipoAeronaves por medio del api request
        /// </summary>
        /// <returns>retorna una lista de TipoAeronaves</returns>
        public async Task<List<CompraDAL>> ListarCompra()
        {
            InicializazdorCliente();
            string url = "api/Compra/ListarCompra";

            List<CompraDAL> lstCompra = new List<CompraDAL>();

            try
            {
                HttpResponseMessage respuesta = await cliente.GetAsync(url);
                if (respuesta.IsSuccessStatusCode)
                {
                    var jsonString = await respuesta.Content.ReadAsStringAsync();
                    lstCompra = JsonConvert.DeserializeObject<List<CompraDAL>>(jsonString);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstCompra;
        }






        /// <summary>
        /// Agrega una aeronave a la bd por medio de un apoi request
        /// </summary>
        /// <param name="oAeronaveDAL">Contiene el objeto con todos los datos que vamos a agregar</param>
        /// <returns>retorna true si hubo exito, false lo contrario</returns>
        public async Task<bool> AgregarCompra(CompraDAL oCompraDAL)
        {
            InicializazdorCliente();
            string url = "https://localhost:82/api/Compra/AgregarCompra";
            try
            {
                HttpResponseMessage respuesta = await cliente.PostAsJsonAsync(url, oCompraDAL);
                return respuesta.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Modifica TipoAeronaves
        /// </summary>
        /// <param name="oAeronaveDAL">contiene los datos nuevos y el id del objeto a modificar</param>
        /// <returns>retorna true si hubo exito, false lo contrario</returns>
        public async Task<bool> ModificarCompra(CompraDAL oCompraDAL)
        {
            InicializazdorCliente();
            string url = "https://localhost:82/api/Compra/ModificarCompra";
            try
            {
                HttpResponseMessage respuesta = await cliente.PostAsJsonAsync(url, oCompraDAL);
                return respuesta.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        /// <summary>
        /// Elimina una aeronave de la base de datos por medio de un api
        /// </summary>
        /// <param name="oAeronaveDAL">contiene el id del objeto a eliminar</param>
        /// <returns>retorna true si hubo exito, false lo contrario</returns>
        public async Task<bool> EliminarCompra(CompraDAL oCompraDAL)
        {
            InicializazdorCliente();
            string url = "https://localhost:82/api/Compra/EliminarCompra";
            try
            {
                HttpResponseMessage respuesta = await cliente.PostAsJsonAsync(url, oCompraDAL);
                return respuesta.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Filtrar TipoAeronaves
        /// </summary>
        /// <param name="oTipoAeronavesDAL">Contiene la variable por la cual vamos a filtrar</param>
        /// <returns>Retorna la lista de TipoAeronaves filtradas</returns>
        public async Task<List<CompraDAL>> FiltrarTipoAeronaves(CompraDAL oCompraDAL)
        {
            InicializazdorCliente();
            string url = "";
            List<CompraDAL> lstCompra = new List<CompraDAL>();
            try
            {
                HttpResponseMessage respuesta = await cliente.PostAsJsonAsync(url, oCompraDAL);
                if (respuesta.IsSuccessStatusCode)
                {
                    var jsonString = await respuesta.Content.ReadAsStringAsync();
                    lstCompra = JsonConvert.DeserializeObject<List<CompraDAL>>(jsonString);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lstCompra;
        }


        

        #endregion
    }
}
