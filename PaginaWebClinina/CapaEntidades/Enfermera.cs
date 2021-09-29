using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Enfermera : Empleado
    {
        public int IdEnfermera { get; set; }
        public String TipoEnfermera { get; set; }
        public bool estado { get; set; }

        public Enfermera():base()
        {

        }

        public Enfermera(int IdEnfermera,String TipoEnfermera,bool estado)
            :base(0, new TipoEmpleado(), "", "", "", "", true, "", "", "")
        {
            this.IdEnfermera = IdEnfermera;
            this.TipoEnfermera = TipoEnfermera;
            this.estado = estado;
        }
    }
}
