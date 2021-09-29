using CapaEntidades;
using CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaWebClinina
{
    public partial class GestionarHorariosEnfermeras : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        [WebMethod]
        public static Enfermera BuscarEnfermera(String dni)
        {
            return EnfermeraLN.getInstance().BuscarEnfermera(dni);
        }

        [WebMethod]
        public static List<HorarioAtencionEnfermera> ListarHorariosAtencion(String idenfermera)
        {
            Int32 idEnfermera = Convert.ToInt32(idenfermera);

            return HorarioAtencionEnfermeraLN.getInstance().Listar(idEnfermera);
        }
       

        [WebMethod]
        public static HorarioAtencionEnfermera AgregarHorario( String fecha, String turno, String id)
        {
            HorarioAtencionEnfermera objHorarioAtencion = new HorarioAtencionEnfermera()
            {
                Fecha = Convert.ToDateTime(fecha),
                Turno = turno,
                Enfermera = new Enfermera()
                {
                    IdEnfermera = Convert.ToInt32(id)
                }
            };
                return HorarioAtencionEnfermeraLN.getInstance().RegistrarHorarioAtencion(objHorarioAtencion);
        }

        
        [WebMethod]
        public static bool EliminarHorarioAtencion(String id)
        {
            Int32 idHorario = Convert.ToInt32(id);

            return HorarioAtencionEnfermeraLN.getInstance().Eliminar(idHorario);
        }
    }
}