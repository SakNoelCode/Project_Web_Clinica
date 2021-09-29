using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Usuario :Empleado
    {
        public int IdUsuario { get; set; }
        public String user { get;set; }
        public String password { get; set; }
        public bool estado { get; set; }

        public String TipUser { get; set; }
   
        public Usuario():base()
        {

        }

        public Usuario(int IdUsuario,String user,String password,bool estado,String TipUser)
            : base(0, new TipoEmpleado(), "", "", "", "", true, "", "", "")
        {
            this.IdUsuario = IdUsuario;
            this.user = user;
            this.password = password;
            this.estado = estado;
            this.TipUser = TipUser;
        }
    }
}
