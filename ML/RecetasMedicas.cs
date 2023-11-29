using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class RecetasMedicas
    {
        public int IdReceta { get; set; }
        public ML.Paciente Paciente { get; set; }
        public string FechaDeconsulta { get; set; }
        public DateTime FechaDeconsultaG { get; set; }
        public string Diagnostico { get; set; }
        public string NombreMedico { get; set; }
        public string NotasAdicionales { get; set; }

        public List<object> RecetasMdicasG { get; set; }
    }
}
