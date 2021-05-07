using DAL.Catalogos;
using DataAccess.AccesoApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Catalogos
{
    public class CompraBLL
    {
        #region Metodos para conectar al Api

        public async Task<List<CompraDAL>> ListarCompra()
        {
            var oCompra = new CompraApi();

            return await oCompra.ListarCompra();
        }

        public async Task<bool> AgregarCompra(CompraDAL oCompraDAL)
        {
            var oCompra = new CompraApi();

            return await oCompra.AgregarCompra(oCompraDAL);
        }

        public async Task<bool> ModificarCompra(CompraDAL oCompraDAL)
        {
            var oCompra = new CompraApi();

            return await oCompra.ModificarCompra(oCompraDAL);
        }

        public async Task<bool> EliminarCompra(CompraDAL oCompraDAL)
        {
            var oCompra = new CompraApi();

            return await oCompra.EliminarCompra(oCompraDAL);
        }




        #endregion
    }
}
