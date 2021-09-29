using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class HorarioAtencionEnfermeraLN
    {

        #region "PATRON SINGLETON"
        private static HorarioAtencionEnfermeraLN daoHorarioEnfermera = null;
        private HorarioAtencionEnfermeraLN() { }
        public static HorarioAtencionEnfermeraLN getInstance()
        {
            if (daoHorarioEnfermera == null)
            {
                daoHorarioEnfermera = new HorarioAtencionEnfermeraLN();
            }
            return daoHorarioEnfermera;
        }
        #endregion

        public List<HorarioAtencionEnfermera> Listar(Int32 id)
        {
            try
            {
                return HorarioAtencionEnfermeraDAO.getInstance().Listar(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HorarioAtencionEnfermera RegistrarHorarioAtencion(HorarioAtencionEnfermera objHorarioAtencion)
        {
            try
            {
                return HorarioAtencionEnfermeraDAO.getInstance().RegistrarHorarioAtencionEnfermera(objHorarioAtencion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idHorario)
        {
            try
            {
                return HorarioAtencionEnfermeraDAO.getInstance().Eliminar(idHorario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
