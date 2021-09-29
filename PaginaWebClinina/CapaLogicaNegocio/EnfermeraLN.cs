using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class EnfermeraLN
    {
        #region "PATRON SINGLETON"
        private static EnfermeraLN objEnfermera = null;
        private EnfermeraLN() { }
        public static EnfermeraLN getInstance()
        {
            if (objEnfermera == null)
            {
                objEnfermera = new EnfermeraLN();
            }
            return objEnfermera;
        }
        #endregion


        public Enfermera BuscarEnfermera(string dni)
        {
            try
            {
                return EnfermeraDAO.getInstance().BuscarEnfermera(dni);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Enfermera> ListarEnfermeras()
        {
            try
            {
                return EnfermeraDAO.getInstance().ListarEnfermeras();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RegistrarEnfermera(Enfermera obj)
        {
            try
            {
                return EnfermeraDAO.getInstance().RegistrarEnfermera(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(Enfermera obj)
        {
            try
            {
                return EnfermeraDAO.getInstance().Actualizar(obj);
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
                return EnfermeraDAO.getInstance().Eliminar(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
