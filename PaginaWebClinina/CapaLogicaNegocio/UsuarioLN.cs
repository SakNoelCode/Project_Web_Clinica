using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class UsuarioLN
    {
        #region "PATRON SINGLETON"
        private static UsuarioLN obj = null;
        private UsuarioLN() { }
        public static UsuarioLN getInstance()
        {
            if (obj == null)
            {
                obj = new UsuarioLN();
            }
            return obj;
        }

        public Usuario BuscarPacienteDNI(string dni)
        {
            throw new NotImplementedException();
        }
        #endregion


        public Usuario AccesoSistema(String user, String pass)
        {
            try
            {
                return UsuarioDAO.getInstance().AccesoSistema(user, pass);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Usuario> ListarUsuarios()
        {
            try
            {
                return UsuarioDAO.getInstance().ListarUsuarios();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RegistrarUsuario(Usuario obj)
        {
            try
            {
                return UsuarioDAO.getInstance().RegistrarUsuario(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(Usuario obj)
        {
            try
            {
                return UsuarioDAO.getInstance().Actualizar(obj);
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
                return UsuarioDAO.getInstance().Eliminar(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
