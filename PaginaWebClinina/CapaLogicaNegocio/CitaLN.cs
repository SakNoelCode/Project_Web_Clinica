using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class CitaLN
    {

        #region "PATRON SINGLETON"
        private static CitaLN citaLN = null;
        private CitaLN() { }
        public static CitaLN getInstance()
        {
            if (citaLN == null)
            {
                citaLN = new CitaLN();
            }
            return citaLN;
        }
        #endregion

        public bool RegistrarCita(Cita objCita)
        {
            try
            {
                return CitaDAO.getInstance().RegistrarCita(objCita);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Cita> ListarCitas()
        {
            try
            {
                return CitaDAO.getInstance().ListarCitas();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Cita> ListarCitasDNI(String dni)
        {
            try
            {
                return CitaDAO.getInstance().ListarCitasDNI(dni);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Cita> ListarCitasFECHA(DateTime fecha)
        {
            try
            {
                return CitaDAO.getInstance().ListarCitasFECHA(fecha);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Cita> ListarCitasESPECIALIDAD(String especialidad)
        {
            try
            {
                return CitaDAO.getInstance().ListarCitasESPECILIDAD(especialidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ActualizarCita(Int32 idCita, string estado)
        {
            try
            {
                return CitaDAO.getInstance().ActualizarCita(idCita, estado);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
