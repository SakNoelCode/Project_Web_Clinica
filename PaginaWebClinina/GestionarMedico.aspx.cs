using CapaEntidades;
using CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaWebClinina
{
    public partial class GestionarMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarEspecialidades();
            }

        }

        [WebMethod]
        public static List<Medico> ListarMedicos()
        {
            List<Medico> Lista = null;
            try
            {
                Lista = MedicoLN.getInstance().ListarMedicos();
            }
            catch (Exception)
            {
                Lista = new List<Medico>();
            }
            return Lista;
        }

        [WebMethod]
        public static bool ActualizarDatosMedico(String id, String documento )
        {
            Medico obj = new Medico()
            {
                IdMedico = Convert.ToInt32(id),
                NroDocumento = documento
            };

            bool ok = MedicoLN.getInstance().Actualizar(obj);

            return ok;
        }

        [WebMethod]
        public static bool EliminarDatosMedico(String id)
        {
            Int32 idMedico= Convert.ToInt32(id);

            bool ok = MedicoLN.getInstance().Eliminar(idMedico);

            return ok;

        }

        private Medico GetEntity()
        {
            
            Medico obj = new Medico();
            obj.IdMedico = 0;
            obj.RTipoEmpleado.ID = 1002;
            obj.Nombre = txtNombres.Text;
            obj.ApPaterno = txtApPaterno.Text;
            obj.ApMaterno = txtApMaterno.Text;
            obj.Especialidad = new Especialidad();
            obj.Especialidad.IdEspecialidad = (ddlEspecialidad.SelectedIndex)+1;
            obj.NroDocumento = txtNroDocumento.Text;
            obj.Estado = true;

            return obj;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Medico obj = GetEntity();
            bool response = MedicoLN.getInstance().RegistrarMedico(obj);
            if (response)
            {
                Response.Write("<script>alert('REGISTRO CORRECTO.')</script>");

            }
            else
            {
                Response.Write("<script>alert('REGISTRO INCORRECTO.')</script>");
            }
            Limpiar();
        }

        private void LlenarEspecialidades()
        {
            List<Especialidad> Lista = EspecialidadLN.getInstance().Listar();

            ddlEspecialidad.DataSource = Lista;
            ddlEspecialidad.DataValueField = "IdEspecialidad";
            ddlEspecialidad.DataTextField = "Descripcion";
            ddlEspecialidad.DataBind();
        }

        private void Limpiar()
        {
            txtApMaterno.Text = "";
            txtApPaterno.Text = "";
            txtNombres.Text = "";
            txtNroDocumento.Text = "";
            ddlEspecialidad.SelectedIndex = 0;
        }
    }
}