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
    public class CitaDAO
    {
        #region "PATRON SINGLETON"
        private static CitaDAO daoCita = null;
        private CitaDAO() { }
        public static CitaDAO getInstance()
        {
            if (daoCita == null)
            {
                daoCita = new CitaDAO();
            }
            return daoCita;
        }
        #endregion

        public bool RegistrarCita(Cita objCita)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spRegistrarCita", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMedico", objCita.Medico.IdMedico);
                cmd.Parameters.AddWithValue("@idPaciente", objCita.Paciente.IdPaciente);
                cmd.Parameters.AddWithValue("@fechaReserva", objCita.FechaReserva);
                cmd.Parameters.AddWithValue("@hora", objCita.Hora);

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

        public List<Cita> ListarCitas()
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Cita> ListaCitas = new List<Cita>();

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spListarCitas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    // Llenar la lista con las citas
                    Cita cita = new Cita();
                    cita.IdCita = Convert.ToInt32(dr["idCita"].ToString());
                    cita.Medico.IdMedico = Convert.ToInt32(dr["idMedico"].ToString());
                    cita.Medico.Especialidad = new Especialidad();
                    cita.Medico.Especialidad.Descripcion = dr["descripcion"].ToString();
                    cita.Paciente.IdPaciente = Convert.ToInt32(dr["idPaciente"].ToString());
                    cita.FechaReserva = Convert.ToDateTime(dr["fechaReserva"].ToString());
                    cita.Hora = dr["hora"].ToString();

                    cita.Paciente.Nombres = dr["nombres"].ToString();
                    cita.Paciente.ApPaterno = dr["apPaterno"].ToString();
                    cita.Paciente.ApMaterno = dr["apMaterno"].ToString();
                    cita.Paciente.Edad = Convert.ToInt32(dr["edad"].ToString());
                    cita.Paciente.Sexo = Convert.ToChar(dr["sexo"].ToString());
                    cita.Paciente.NroDocumento = dr["nroDocumento"].ToString();
                    cita.Paciente.Direccion = dr["direccion"].ToString();

                    ListaCitas.Add(cita);
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

            return ListaCitas;

        }

        public List<Cita> ListarCitasDNI(String dni)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Cita> ListaCitas = new List<Cita>();

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spListarCitasDNI", con);
                cmd.Parameters.AddWithValue("@prmDNI", dni);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    // Llenar la lista con las citas
                    Cita cita = new Cita();
                    cita.IdCita = Convert.ToInt32(dr["idCita"].ToString());
                    cita.Medico.IdMedico = Convert.ToInt32(dr["idMedico"].ToString());
                    cita.Medico.Especialidad = new Especialidad();
                    cita.Medico.Especialidad.Descripcion = dr["descripcion"].ToString();
                    cita.Paciente.IdPaciente = Convert.ToInt32(dr["idPaciente"].ToString());
                    cita.FechaReserva = Convert.ToDateTime(dr["fechaReserva"].ToString());
                    cita.Hora = dr["hora"].ToString();

                    cita.Paciente.Nombres = dr["nombres"].ToString();
                    cita.Paciente.ApPaterno = dr["apPaterno"].ToString();
                    cita.Paciente.ApMaterno = dr["apMaterno"].ToString();
                    cita.Paciente.Edad = Convert.ToInt32(dr["edad"].ToString());
                    cita.Paciente.Sexo = Convert.ToChar(dr["sexo"].ToString());
                    cita.Paciente.NroDocumento = dr["nroDocumento"].ToString();
                    cita.Paciente.Direccion = dr["direccion"].ToString();

                    ListaCitas.Add(cita);
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

            return ListaCitas;
        }

        public List<Cita> ListarCitasFECHA(DateTime fecha)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Cita> ListaCitas = new List<Cita>();

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spListarCitasFECHA", con);
                cmd.Parameters.AddWithValue("@prmFECHA", fecha);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    // Llenar la lista con las citas
                    Cita cita = new Cita();
                    cita.IdCita = Convert.ToInt32(dr["idCita"].ToString());
                    cita.Medico.IdMedico = Convert.ToInt32(dr["idMedico"].ToString());
                    cita.Medico.Especialidad = new Especialidad();
                    cita.Medico.Especialidad.Descripcion = dr["descripcion"].ToString();
                    cita.Paciente.IdPaciente = Convert.ToInt32(dr["idPaciente"].ToString());
                    cita.FechaReserva = Convert.ToDateTime(dr["fechaReserva"].ToString());
                    cita.Hora = dr["hora"].ToString();

                    cita.Paciente.Nombres = dr["nombres"].ToString();
                    cita.Paciente.ApPaterno = dr["apPaterno"].ToString();
                    cita.Paciente.ApMaterno = dr["apMaterno"].ToString();
                    cita.Paciente.Edad = Convert.ToInt32(dr["edad"].ToString());
                    cita.Paciente.Sexo = Convert.ToChar(dr["sexo"].ToString());
                    cita.Paciente.NroDocumento = dr["nroDocumento"].ToString();
                    cita.Paciente.Direccion = dr["direccion"].ToString();

                    ListaCitas.Add(cita);
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

            return ListaCitas;
        }

        public List<Cita> ListarCitasESPECILIDAD(String especialidad)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Cita> ListaCitas = new List<Cita>();

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spListarCitasESPECIALIDAD", con);
                cmd.Parameters.AddWithValue("@prmEspecialidad", especialidad);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    // Llenar la lista con las citas
                    Cita cita = new Cita();
                    cita.IdCita = Convert.ToInt32(dr["idCita"].ToString());
                    cita.Medico.IdMedico = Convert.ToInt32(dr["idMedico"].ToString());
                    cita.Medico.Especialidad = new Especialidad();
                    cita.Medico.Especialidad.Descripcion = dr["descripcion"].ToString();
                    cita.Paciente.IdPaciente = Convert.ToInt32(dr["idPaciente"].ToString());
                    cita.FechaReserva = Convert.ToDateTime(dr["fechaReserva"].ToString());
                    cita.Hora = dr["hora"].ToString();

                    cita.Paciente.Nombres = dr["nombres"].ToString();
                    cita.Paciente.ApPaterno = dr["apPaterno"].ToString();
                    cita.Paciente.ApMaterno = dr["apMaterno"].ToString();
                    cita.Paciente.Edad = Convert.ToInt32(dr["edad"].ToString());
                    cita.Paciente.Sexo = Convert.ToChar(dr["sexo"].ToString());
                    cita.Paciente.NroDocumento = dr["nroDocumento"].ToString();
                    cita.Paciente.Direccion = dr["direccion"].ToString();

                    ListaCitas.Add(cita);
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

            return ListaCitas;
        }

        public bool ActualizarCita(Int32 idCita, string estado)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spActualizarEstadoCita", con);
                cmd.Parameters.AddWithValue("@prmIdCita", idCita);
                cmd.Parameters.AddWithValue("@prmEstado", estado);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                // Ejecutar el procedimiento almacenado
                cmd.ExecuteNonQuery();

                response = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return response;
        }
    }
}
