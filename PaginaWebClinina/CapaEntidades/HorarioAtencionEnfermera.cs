using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class HorarioAtencionEnfermera
    {
        public int IdHorarioAtencionEnfermera { get; set; }
        public Enfermera Enfermera { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }
        public String Turno { get; set; }

        public HorarioAtencionEnfermera()
        {
        }
    }
}
