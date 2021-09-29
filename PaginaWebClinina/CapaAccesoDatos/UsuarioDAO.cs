using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class UsuarioDAO
    {
        #region "PATRON SINGLETON"
        private static UsuarioDAO obj = null;
        private UsuarioDAO() { }
        public static UsuarioDAO getInstance()
        {
            if (obj == null)
            {
                obj = new UsuarioDAO();
            }
            return obj;
        }
        #endregion

        public bool Actualizar(Usuario obj)
        {
            bool ok = false;
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spActualizarDatosUsuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdUsuario", obj.IdUsuario);
                cmd.Parameters.AddWithValue("@prmUsuario", obj.user);
                cmd.Parameters.AddWithValue("@prmClave", obj.password);
                cmd.Parameters.AddWithValue("@prmTipUser", obj.TipUser);

                conexion.Open();

                cmd.ExecuteNonQuery();

                ok = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return ok;
        }

        public Usuario AccesoSistema(string user, string pass)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            Usuario obj= null;
            SqlDataReader dr = null;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spAccesoSistemaUsuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmUser", user);
                cmd.Parameters.AddWithValue("@prmPass", pass);
                conexion.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    obj = new Usuario();
                    obj.IdUsuario= Convert.ToInt32(dr["idUsuario"].ToString());
                    obj.user = dr["usuario"].ToString();
                    obj.password = dr["clave"].ToString();
                    obj.Nombre = dr["nombres"].ToString();
                    obj.ApPaterno = dr["apPaterno"].ToString();
                    obj.ApMaterno = dr["apMaterno"].ToString();
                    // obj.TipUser = dr["tipoUser"].ToString();
                    obj.ID =Convert.ToInt32( dr["idEmpleado"]);
                    obj.estado = true;
                   
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return obj;
        }

        public bool RegistrarUsuario(Usuario obj)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spRegistrarUsuario", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmUsuario", obj.user);
                cmd.Parameters.AddWithValue("@prmClave", obj.password);
                cmd.Parameters.AddWithValue("@prmIdEmpleado", obj.ID);
                cmd.Parameters.AddWithValue("@prmTipUser", obj.TipUser);
                cmd.Parameters.AddWithValue("@prmEstado", obj.estado);
                con.Open();

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) response = true;

            }
            catch (Exception ex)
            {
                response = false;
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return response;
        }

        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> Lista = new List<Usuario>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spListarUsuarios", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // Crear objetos de tipo Usuario
                    Usuario obj = new Usuario();
                    obj.IdUsuario = Convert.ToInt32(dr["idUsuario"].ToString());
                    obj.Nombre = dr["nombres"].ToString();
                    obj.ApPaterno = dr["apPaterno"].ToString();
                    obj.ApMaterno = dr["apMaterno"].ToString();
                    obj.user = dr["usuario"].ToString();
                    obj.password = dr["clave"].ToString();
                    obj.NroDocumento = (dr["nroDocumento"].ToString());
                    obj.TipUser = dr["tipoUser"].ToString();
                    obj.Estado = true;


                    //añadir a la lista de objetos
                    Lista.Add(obj);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return Lista;
        }

        public bool Eliminar(int id)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            bool ok = false;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spEliminarUsuario", conexion);
                cmd.Parameters.AddWithValue("@prmIdUsuario", id);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                cmd.ExecuteNonQuery();

                ok = true;

            }
            catch (Exception ex)
            {
                ok = false;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return ok;
        }
    }
}
