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
    public partial class GestionarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static List<Usuario> ListarUsuarios()
        {
            List<Usuario> Lista = null;
            try
            {
                Lista = UsuarioLN.getInstance().ListarUsuarios();
            }
            catch (Exception)
            {
                Lista = new List<Usuario>();
            }
            return Lista;
        }

        [WebMethod]
        public static bool EliminarDatosUsuario(String id)
        {
            Int32 idUsuario = Convert.ToInt32(id);

            bool ok = UsuarioLN.getInstance().Eliminar(idUsuario);

            return ok;

        }

        private Usuario GetEntity()
        {
            Usuario obj = new Usuario();
            obj.IdUsuario = 0;
            obj.user = txtUsuario.Text;
            obj.password = txtContraseña.Text;
            obj.ID = Convert.ToInt32(idEmpleado.Value);
            obj.TipUser = ddlTipoUsuario.SelectedValue.ToString();
            obj.Estado = true;

            return obj;
        }

        private Usuario GetEntity2()
        {
            Usuario obj = new Usuario();
            obj.IdUsuario = Convert.ToInt32(idUsuario.Value); 
            obj.user = txtUsuario.Text;
            obj.password = txtContraseña.Text;
            obj.TipUser = ddlTipoUsuario.SelectedValue.ToString();
            obj.Estado = true;
            return obj;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Usuario obj = GetEntity();
            bool response = UsuarioLN.getInstance().RegistrarUsuario(obj);
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
         

        [WebMethod]
        public static Empleado BuscarEmpleadoDNI(String dni)
        {
            return EmpleadoLN.getInstance().BuscarEmpleado(dni);
        }

        private void Limpiar()
        {
            txtDNI.Text="";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            ddlTipoUsuario.SelectedIndex = 0;
            txtTipoEmpleado.Text = "";
            idEmpleado.Value = "0";
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Usuario obj = GetEntity2();
            bool response = UsuarioLN.getInstance().Actualizar(obj);
            if (response)
            {
                Response.Write("<script>alert('ACTUALIZACION CORRECTA.')</script>");

            }
            else
            {
                Response.Write("<script>alert('ACTUALIZACION INCORRECTA.')</script>");
            }
            Limpiar();

        }
    }
}