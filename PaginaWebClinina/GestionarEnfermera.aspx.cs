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
    public partial class GestionarEnfermera : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static List<Enfermera> ListarEnfermeras()
        {
            List<Enfermera> Lista = null;
            try
            {
                Lista = EnfermeraLN.getInstance().ListarEnfermeras();
            }
            catch (Exception)
            {
                Lista = new List<Enfermera>();
            }
            return Lista;
        }

        [WebMethod]
        public static bool ActualizarDatosEnfermera(String id, String documento)
        {
            Enfermera obj = new Enfermera()
            {
                IdEnfermera = Convert.ToInt32(id),
                NroDocumento = documento
            };

            bool ok = EnfermeraLN.getInstance().Actualizar(obj);

            return ok;
        }

        [WebMethod]
        public static bool EliminarDatosEnfermera(String id)
        {
            Int32 idEnfermera = Convert.ToInt32(id);

            bool ok = EnfermeraLN.getInstance().Eliminar(idEnfermera);

            return ok;

        }


        private Enfermera GetEntity()
        {

            Enfermera obj = new Enfermera();
            obj.IdEnfermera = 0;
            obj.RTipoEmpleado.ID = 1003;
            obj.Nombre = txtNombres.Text;
            obj.ApPaterno = txtApPaterno.Text;
            obj.ApMaterno = txtApMaterno.Text;
            obj.NroDocumento = txtNroDocumento.Text;
            obj.TipoEnfermera = ddlTipoEnfermera.SelectedValue.ToString();
            obj.Estado = true;

            return obj;
        }


        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Enfermera obj = GetEntity();
            bool response = EnfermeraLN.getInstance().RegistrarEnfermera(obj);
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


        private void Limpiar()
        {
            txtApMaterno.Text = "";
            txtApPaterno.Text = "";
            txtNombres.Text = "";
            txtNroDocumento.Text = "";
            ddlTipoEnfermera.SelectedIndex = 0;
        }
    }
}