using DAL.Catalogos;
using DataAccess.AccesoApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Catalogos
{
    public class VitacoraBLL
    {
        public async Task<List<VitacoraDAL>> ListarViacora()
        {
            VitacoraAcceso oVitacoraAcceso = new VitacoraAcceso();
            return await oVitacoraAcceso.ListarVitacora();
        }
    }
}
