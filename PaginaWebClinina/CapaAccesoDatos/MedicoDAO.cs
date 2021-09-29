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
    public class MedicoDAO
    {

        #region "PATRON SINGLETON"
        private static MedicoDAO daoMedico = null;
        private MedicoDAO() { }
        public static MedicoDAO getInstance()
        {
            if (daoMedico == null)
            {
                daoMedico = new MedicoDAO();
            }
            return daoMedico;
        }
        #endregion


        public Medico BuscarMedico(String dni)
        { 
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            Medico objMedico = null;
            SqlDataReader dr = null;

            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spBuscarMedico", conexion);
                cmd.Parameters.AddWithValue("@prmDni", dni);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // instanciar nuestro objeto
                    objMedico = new Medico()
                    {
                        IdMedico = Convert.ToInt32(dr["idMedico"].ToString()),
                        ID = Convert.ToInt32(dr["idEmpleado"].ToString()),
                        Nombre = dr["nombre"].ToString(),
                        ApPaterno = dr["apPaterno"].ToString(),
                        ApMaterno = dr["apMaterno"].ToString(),
                        Especialidad = new Especialidad()
                        {
                            IdEspecialidad = Convert.ToInt32(dr["idEspecialidad"].ToString()),
                            Descripcion = dr["descripcion"].ToString(),
                        },
                        Estado = Convert.ToBoolean(dr["estadoMedico"].ToString())
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
            return objMedico;
        }

        public bool Actualizar(Medico obj)
        {
            bool ok = false;
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spActualizarDatosMedico", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdMedico", obj.IdMedico);
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

        public bool RegistrarMedico(Medico obj)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spRegistrarMedico", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdTipoEmp", obj.RTipoEmpleado.ID);
                cmd.Parameters.AddWithValue("@prmNombres", obj.Nombre);
                cmd.Parameters.AddWithValue("@prmApPaterno", obj.ApPaterno);
                cmd.Parameters.AddWithValue("@prmApMaterno", obj.ApMaterno);
                cmd.Parameters.AddWithValue("@prmEspecialidad", obj.Especialidad.IdEspecialidad);
                cmd.Parameters.AddWithValue("@prmNroDoc", obj.NroDocumento);
                cmd.Parameters.AddWithValue("@prmEstado", obj.Estado);
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

        public List<Medico> ListarMedicos()
        {
            List<Medico> Lista = new List<Medico>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spListarMedicos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // Crear objetos de tipo Paciente
                    Medico obj = new Medico();
                    obj.IdMedico = Convert.ToInt32(dr["idMedico"].ToString());
                    obj.Nombre = dr["nombres"].ToString();
                    obj.ApPaterno = dr["apPaterno"].ToString();
                    obj.ApMaterno = dr["apMaterno"].ToString();
                    obj.NroDocumento = (dr["nroDocumento"].ToString());
                    obj.Especialidad = new Especialidad();
                    obj.Especialidad.Descripcion = dr["descripcion"].ToString();
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
                cmd = new SqlCommand("spEliminarMedico", conexion);
                cmd.Parameters.AddWithValue("@prmIdMedico", id);
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
