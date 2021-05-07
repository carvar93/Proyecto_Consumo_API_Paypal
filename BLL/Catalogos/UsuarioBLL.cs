using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Catalogos;
using DataAccess.AccesoApi;
using BLL.Helpers;

namespace BLL.Catalogos
{
    public class UsuarioBLL
    {
        #region Metodos para conectar al Api
        public Task<List<UsuarioDAL>> Login(UsuarioDAL oUsuarioDAL)
        {
            var oUsuarioAccess = new UsuarioAPI();

            string CryptPass = EncryptPassword.GetSHA256(oUsuarioDAL._Pass);

            oUsuarioDAL._Pass = CryptPass;

            return oUsuarioAccess.Login(oUsuarioDAL);
        }

        public async Task<List<UsuarioDAL>> ListarUsuario()
        {
            var oUsuarioAccess = new UsuarioAPI();

            return await oUsuarioAccess.ListarUsuario();
        }

        public async Task<bool> AgregarUsuario(UsuarioDAL oUsuarioDAL)
        {
            var oUsuarioAccess = new UsuarioAPI();

            string CryptPass = EncryptPassword.GetSHA256(oUsuarioDAL._Pass);

            oUsuarioDAL._Pass = CryptPass;

            return await oUsuarioAccess.AgregarUsuario(oUsuarioDAL);
        }

        public async Task<bool> ModificarUsuario(UsuarioDAL oUsuarioDAL)
        {
            var oUsuarioAccess = new UsuarioAPI();

            return await oUsuarioAccess.ModificarUsuarios(oUsuarioDAL);
        }

        public async Task<bool> ActualizarContraseña(UsuarioDAL oUsuarioDAL)
        {
            var oUsuarioAccess = new UsuarioAPI();

            string CryptPass = EncryptPassword.GetSHA256(oUsuarioDAL._Pass);

            oUsuarioDAL._Pass = CryptPass;

            return await oUsuarioAccess.ModificarUsuarios(oUsuarioDAL);
        }

        public async Task<bool> EliminarUsuario(UsuarioDAL oUsuarioDAL)
        {
            var oUsuarioAccess = new UsuarioAPI();

            return await oUsuarioAccess.EliminarUsuarios(oUsuarioDAL);
        }

        public async Task<bool> RecuperarContraseña(UsuarioDAL oUsuarioDAL)
        {
            var oUsuarioAccess = new UsuarioAPI();

            return await oUsuarioAccess.RecuperarContraseña(oUsuarioDAL);
        }

        /// <summary>
        /// Metodo para actualizar contraseña caundo se recupera la contraseña
        /// </summary>
        /// <param name="oUsuarioDAL"></param>
        /// <returns></returns>
        public async Task<bool> CambiarContraseña(UsuarioDAL oUsuarioDAL)
        {
            var oUsuarioAccess = new UsuarioAPI();

            string CryptPass = EncryptPassword.GetSHA256(oUsuarioDAL._Pass);

            oUsuarioDAL._Pass = CryptPass;

            return await oUsuarioAccess.CambiarContraseña(oUsuarioDAL);
        }
        #endregion
    }
}
