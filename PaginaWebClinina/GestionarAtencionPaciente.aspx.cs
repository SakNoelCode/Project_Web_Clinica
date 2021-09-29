using CapaEntidades;
using CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaWebClinina
{
    public partial class GestionarAtencionPaciente : System.Web.UI.Page
    {
        private static String COMMAND_REGISTER = "Registrar";
        private static String COMMAND_CANCEL = "Cancelar";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblFechaAtencion.Text = DateTime.Now.ToShortDateString();
                llenarDataList();
            }

        }

        private void llenarDataList()
        {
            List<Cita> ListaCitas = CitaLN.getInstance().ListarCitas();
            dlAtencionMedica.DataSource = ListaCitas;
            dlAtencionMedica.DataBind();
        }

        protected void dlAtencionMedica_ItemCommand(object source, DataListCommandEventArgs e)
        {
            String IdCita = (e.Item.FindControl("hdIdCita") as HiddenField).Value;

            if (e.CommandName == COMMAND_REGISTER)
            {
                //realizar el registro de la atención
                //Redirección a la página de GestionarAtencionCita.aspx
                bool response = CitaLN.getInstance().ActualizarCita(Convert.ToInt32(IdCita), "A");

                if (response)
                {
                    Response.Redirect("GestionarAtencionCita.aspx?idcita=" + IdCita);
                }
                else
                {
                    Response.Write("<script>alert('NO SE PUEDE REALIZAR LA ATENCIÓN DE LA CITA.')</script>");
                }


            }
            else if (e.CommandName == COMMAND_CANCEL)
            {
                //realizar la cancelación de la reserva de cita
                bool response = CitaLN.getInstance().ActualizarCita(Convert.ToInt32(IdCita), "E");

                if (response)
                {
                  //  recargar la información
                        llenarDataList();
                }
                else
                {
                    Response.Write("<script>alert('NO SE PUEDE ELIMINAR LA CITA.')</script>");
                }
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                BaseDeDatos db = new BaseDeDatos();
                if (ddlBuscar.SelectedValue == "DNI")
                {
                    try
                    {
                        String dni = txtBuscar.Text;
                        List<Cita> ListaCitasDNI = CitaLN.getInstance().ListarCitasDNI(dni);
                        dlAtencionMedica.DataSource = ListaCitasDNI;
                        dlAtencionMedica.DataBind();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
                if (ddlBuscar.SelectedValue =="Fecha")
                {
                    try
                    {
                        String fecha = txtBuscar.Text;
                        DateTime fech = Convert.ToDateTime(fecha);
                        List<Cita> ListaCitasFECHA = CitaLN.getInstance().ListarCitasFECHA(fech);
                        dlAtencionMedica.DataSource = ListaCitasFECHA;
                        dlAtencionMedica.DataBind();
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }

                }
                if (ddlBuscar.SelectedValue=="Especialidad")
                {
                    try
                    {
                        String especialidad = txtBuscar.Text;
                        List<Cita> ListaCitasESPECIALIDAD = CitaLN.getInstance().ListarCitasESPECIALIDAD(especialidad);
                        dlAtencionMedica.DataSource = ListaCitasESPECIALIDAD;
                        dlAtencionMedica.DataBind();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
            }
            else
            {
                llenarDataList();
            }
        }
    }
}