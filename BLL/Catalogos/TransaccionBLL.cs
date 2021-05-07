using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Catalogos;
using DataAccess.AccesoApi;

namespace BLL.Catalogos
{
    public class TransaccionBLL
    {

        #region Metodos para conectar al Api

        public async Task<List<FacturaDAL>> ConsultarTransaccion()
        {
            var oTransaccionAccess = new TransaccionApi();

            return await oTransaccionAccess.ConsultarTransaccion();
        }



        public async Task<bool> AgregarTransaccion(FacturaDAL transaccion)
        {
            var oTransaccionAccess = new TransaccionApi();
            return await oTransaccionAccess.AgregarTransaccion(transaccion);
        }




        #endregion


    }
}
