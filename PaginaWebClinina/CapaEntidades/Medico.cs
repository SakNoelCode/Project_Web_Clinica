using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Medico : Empleado
    {

        public int IdMedico { get; set; }
        public Especialidad Especialidad { get; set; }
        public new bool Estado { get; set; }


        public Medico(): base()
        {

        }


        public Medico(int IdMedico, Especialidad _Especialidad, bool Estado)
            : base(0, new TipoEmpleado(), "", "", "", "", true, "", "", "")
        {
            this.IdMedico = IdMedico;
            this.Especialidad = _Especialidad;
            this.Estado = Estado;
        }

    }
}
