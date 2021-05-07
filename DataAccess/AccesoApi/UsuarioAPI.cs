using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using DAL.Catalogos;
using System.Net;
using System.Net.Http;

namespace DataAccess.AccesoApi
{
    public class UsuarioAPI
    {

        #region Atributos
        private HttpClient cliente = new HttpClient();
        #endregion

        #region Metodos Privados
        /// <summary>
        /// Metodo para inicializar el atributo cliente, con el cual se realiza la conexion al web api
        /// </summary>
        private void InicializacionCliente()
        {
            cliente.BaseAddress=new Uri("https://localhost:82");
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Login Method
        /// </summary>
        /// <param name="model">Modelo</param>
        /// <returns>El objeto usuario</returns>
        public async Task<List<UsuarioDAL>> Login(UsuarioDAL oUsuarioDAL)
        {
            InicializacionCliente();
            string url = "https://localhost:82/api/usuarios/Login";
            List<UsuarioDAL> lstUsuario = new List<UsuarioDAL>();
            try
            {
                HttpResponseMessage respuesta = await cliente.PostAsJsonAsync(url, oUsuarioDAL); //postAsAsync necesita otra libreria
                if(respuesta.IsSuccessStatusCode)
                {
                    var jsonString = await respuesta.Content.ReadAsStringAsync();
                    lstUsuario = JsonConvert.DeserializeObject<List<UsuarioDAL>>(jsonString);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lstUsuario;
        }


        /// <summary>
        /// Trae los usuarios desde el api
        /// </summary>
        /// <returns>lista de usuarios</returns>
        public async Task<List<UsuarioDAL>> ListarUsuario()
        {
            InicializacionCliente();
            string url = "https://localhost:82/api/Usuarios/ListarUsuarios";
            List<UsuarioDAL> lstUsuarios = new List<UsuarioDAL>();
            try
            {
                HttpResponseMessage respuesta = await cliente.GetAsync(url);
                if (respuesta.IsSuccessStatusCode)
                {
                    var jsonString = await respuesta.Content.ReadAsStringAsync();
                    lstUsuarios = JsonConvert.DeserializeObject<List<UsuarioDAL>>(jsonString);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return lstUsuarios;
        }

        /// <summary>
        /// Agregar usuario
        /// </summary>
        /// <returns>true o false</returns>
        public async Task<bool> AgregarUsuario(UsuarioDAL oUsuarioDAL)
        {
            InicializacionCliente();
            string url = "https://localhost:82/api/usuarios/AgregarUsuario";
            try
            {
                HttpResponseMessage respuesta = await cliente.PostAsJsonAsync(url, oUsuarioDAL); //postAsAsync necesita otra libreria
                return respuesta.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Modificar usuario
        /// </summary>
        /// <param name="oUsuarioDAL">trae los datos a modificar</param>
        /// <returns>true = éxito/ false = error</returns>
        public async Task<bool> ModificarUsuarios(UsuarioDAL oUsuarioDAL)
        {
            InicializacionCliente();
            string url = "https://localhost:82/api/Usuarios/ActualizarUsuario";
            try
            {
                HttpResponseMessage respuesta = await cliente.PostAsJsonAsync(url, oUsuarioDAL); //postAsAsync necesita otra libreria
                return respuesta.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Modificar usuario
        /// </summary>
        /// <param name="oUsuarioDAL">trae el id a eliminar</param>
        /// <returns>true = éxito/ false = error</returns>
        public async Task<bool> EliminarUsuarios(UsuarioDAL oUsuarioDAL)
        {
            InicializacionCliente();
            string url = "https://localhost:82/api/Usuarios/EliminarUsuarios";
            try
            {
                HttpResponseMessage respuesta = await cliente.PostAsJsonAsync(url, oUsuarioDAL); //postAsAsync necesita otra libreria
                return respuesta.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<bool> RecuperarContraseña(UsuarioDAL oUsuarioDAL)
        {
            InicializacionCliente();
            string url = "https://localhost:82/api/Usuarios/RecuperarContraseña";
            try
            {
                HttpResponseMessage respuesta = await cliente.PostAsJsonAsync(url, oUsuarioDAL); //postAsAsync necesita otra libreria
                return respuesta.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Metodo para cambiar contraseña cuando se recupera la contraseña
        /// </summary>
        /// <param name="oUsuarioDAL"></param>
        /// <returns></returns>
        public async Task<bool> CambiarContraseña(UsuarioDAL oUsuarioDAL)
        {
            InicializacionCliente();
            string url = "https://localhost:82/api/Usuarios/CambiarContraseña";
            try
            {
                HttpResponseMessage respuesta = await cliente.PostAsJsonAsync(url, oUsuarioDAL); //postAsAsync necesita otra libreria
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
