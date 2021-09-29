using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class EnfermeraDAO
    {
        #region "PATRON SINGLETON"
        private static EnfermeraDAO daoEnfermera = null;
        private EnfermeraDAO() { }
        public static EnfermeraDAO getInstance()
        {
            if (daoEnfermera == null)
            {
                daoEnfermera = new EnfermeraDAO();
            }
            return daoEnfermera;
        }
        #endregion

        public bool Actualizar(Enfermera obj)
        {
            bool ok = false;
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spActualizarDatosEnfermera", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdEnfermera", obj.IdEnfermera);
                cmd.Parameters.AddWithValue("@prmDocumento", obj.NroDocumento);

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

        public Enfermera BuscarEnfermera(string dni)
        {

            SqlConnection conexion = null;
            SqlCommand cmd = null;
            Enfermera obj = null;
            SqlDataReader dr = null;

            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spBuscarEnfermera", conexion);
                cmd.Parameters.AddWithValue("@prmDni", dni);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // instanciar nuestro objeto
                    obj = new Enfermera()
                    {
                        IdEnfermera = Convert.ToInt32(dr["idEnfermera"].ToString()),
                        ID = Convert.ToInt32(dr["idEmpleado"].ToString()),
                        Nombre = dr["nombre"].ToString(),
                        ApPaterno = dr["apPaterno"].ToString(),
                        ApMaterno = dr["apMaterno"].ToString(),
                        TipoEnfermera = dr["tipoEnfermera"].ToString(),
                        Estado = Convert.ToBoolean(dr["estadoEnfermera"].ToString())
                    };
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return obj;
        }

        public bool RegistrarEnfermera(Enfermera obj)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spRegistrarEnfermera", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdTipoEmp", obj.RTipoEmpleado.ID);
                cmd.Parameters.AddWithValue("@prmNombres", obj.Nombre);
                cmd.Parameters.AddWithValue("@prmApPaterno", obj.ApPaterno);
                cmd.Parameters.AddWithValue("@prmApMaterno", obj.ApMaterno);
                cmd.Parameters.AddWithValue("@prmNroDoc", obj.NroDocumento);
                cmd.Parameters.AddWithValue("@prmEstado", obj.Estado);
                cmd.Parameters.AddWithValue("@prmTipoEnfermera", obj.TipoEnfermera);
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

        public List<Enfermera> ListarEnfermeras()
        {
            List<Enfermera> Lista = new List<Enfermera>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spListarEnfermeras", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // Crear objetos de tipo Paciente
                    Enfermera obj = new Enfermera();
                    obj.IdEnfermera = Convert.ToInt32(dr["idEnfermera"].ToString());
                    obj.Nombre = dr["nombres"].ToString();
                    obj.ApPaterno = dr["apPaterno"].ToString();
                    obj.ApMaterno = dr["apMaterno"].ToString();
                    obj.NroDocumento = (dr["nroDocumento"].ToString());
                    obj.TipoEnfermera = dr["tipoEnfermera"].ToString();
                    obj.Estado = true;


                    // añadir a la lista de objetos
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
                cmd = new SqlCommand("spEliminarEnfermera", conexion);
                cmd.Parameters.AddWithValue("@prmIdEnfermera", id);
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
