using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
   public  class MedicoLN
    {

        #region "PATRON SINGLETON"
        private static MedicoLN objMedico = null;
        private MedicoLN() { }
        public static MedicoLN getInstance()
        {
            if (objMedico == null)
            {
                objMedico = new MedicoLN();
            }
            return objMedico;
        }
        #endregion

        public Medico BuscarMedico(String dni)
        {
            try
            {
                return MedicoDAO.getInstance().BuscarMedico(dni);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Medico> ListarMedicos()
        {
            try
            {
                return MedicoDAO.getInstance().ListarMedicos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RegistrarMedico(Medico obj)
        {
            try
            {
                return MedicoDAO.getInstance().RegistrarMedico(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(Medico obj)
        {
            try
            {
                return MedicoDAO.getInstance().Actualizar(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                return MedicoDAO.getInstance().Eliminar(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
