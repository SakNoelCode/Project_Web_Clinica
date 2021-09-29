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
    public class HorarioAtencionEnfermeraDAO
    {
        #region "PATRON SINGLETON"
        private static HorarioAtencionEnfermeraDAO daoHorarioEnfermera = null;
        private HorarioAtencionEnfermeraDAO() { }
        public static HorarioAtencionEnfermeraDAO getInstance()
        {
            if (daoHorarioEnfermera == null)
            {
                daoHorarioEnfermera = new HorarioAtencionEnfermeraDAO();
            }
            return daoHorarioEnfermera;
        }
        #endregion


        public List<HorarioAtencionEnfermera> Listar(Int32 id)
        {
            SqlConnection conexion = Conexion.getInstance().ConexionBD();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<HorarioAtencionEnfermera> Lista = null;

            try
            {
                cmd = new SqlCommand("spListaHorariosAtencionEnfermera", conexion);
                cmd.Parameters.AddWithValue("@prmIdEnfermera", id);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                dr = cmd.ExecuteReader();

                Lista = new List<HorarioAtencionEnfermera>();

                while (dr.Read())
                {
                    // llenamos los objetos
                    HorarioAtencionEnfermera obj = new HorarioAtencionEnfermera();

                    obj.IdHorarioAtencionEnfermera = Convert.ToInt32(dr["idHorarioAtencionEnfermera"].ToString());
                    obj.Fecha = Convert.ToDateTime(dr["fecha"].ToString());
                    obj.Turno = (dr["Turno"].ToString());
                    
                    Lista.Add(obj);
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
            return Lista;
        }

        public bool Eliminar(int idHorario)
        {
            SqlConnection conexion = Conexion.getInstance().ConexionBD();
            SqlCommand cmd = null;
            bool ok = false;
            try
            {
                cmd = new SqlCommand("spEliminarHorarioAtencionEnfermera", conexion);
                cmd.Parameters.AddWithValue("@prmIdHorarioAtencion", idHorario);
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

        public HorarioAtencionEnfermera RegistrarHorarioAtencionEnfermera(HorarioAtencionEnfermera objHorarioAtencion)
        {
            SqlConnection conexion = Conexion.getInstance().ConexionBD();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            HorarioAtencionEnfermera objHorario = null;

            try
            {
                cmd = new SqlCommand("spRegistrarHorarioAtencionEnfermera", conexion);
                cmd.Parameters.AddWithValue("@prmIdEnfermera", objHorarioAtencion.Enfermera.IdEnfermera);
                cmd.Parameters.AddWithValue("@prmTurno", objHorarioAtencion.Turno);
                cmd.Parameters.AddWithValue("@prmFecha", objHorarioAtencion.Fecha);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    objHorario = new HorarioAtencionEnfermera()
                    {
                        IdHorarioAtencionEnfermera = Convert.ToInt32(dr["idHorarioAtencionEnfermera"].ToString()),
                        Fecha = Convert.ToDateTime(dr["fecha"].ToString()),
                        Turno = dr["Turno"].ToString(),
                        Estado = Convert.ToBoolean(dr["estado"].ToString())
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

            return objHorario;
        }
    }
}
