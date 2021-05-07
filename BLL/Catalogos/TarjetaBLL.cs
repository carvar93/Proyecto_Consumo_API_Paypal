using DAL.Catalogos;
using DataAccess.AccesoApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Catalogos
{
    public class TarjetaBLL
    {
        #region Metodos para conectar al Api

        public async Task<List<TarjetaDAL>> ListarTarjeta()
        {
            var oEstadoUsuarioAccess = new TarjetaApi();

            return await oEstadoUsuarioAccess.ListarTarjeta();
        }

        public async Task<TarjetaDAL> FiltrarTarjeta(TarjetaDAL oEstadoUsuarioDAL)
        {
            var oEstadoUsuarioAccess = new TarjetaApi();

            return await oEstadoUsuarioAccess.FiltrarTarjeta(oEstadoUsuarioDAL);
        }

        public async Task<bool> AgregarTarjeta(TarjetaDAL oEstadoUsuarioDAL)
        {
            var oEstadoUsuarioAccess = new TarjetaApi();

            return await oEstadoUsuarioAccess.AgregarTarjeta(oEstadoUsuarioDAL);
        }

        public async Task<bool> ModificarTarjeta(TarjetaDAL oEstadoUsuarioDAL)
        {
            var oEstadoUsuarioAccess = new TarjetaApi();

            return await oEstadoUsuarioAccess.ModificarTarjeta(oEstadoUsuarioDAL);
        }

        public async Task<bool> EliminarTarjeta(TarjetaDAL oEstadoUsuarioDAL)
        {
            var oEstadoUsuarioAccess = new TarjetaApi();

            return await oEstadoUsuarioAccess.EliminarTarjeta(oEstadoUsuarioDAL);
        }
        #endregion
    }
}
