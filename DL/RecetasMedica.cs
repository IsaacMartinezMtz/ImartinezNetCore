using System;
using System.Collections.Generic;

namespace DL;

public partial class RecetasMedica
{
    public int IdReceta { get; set; }

    public int? IdPaciente { get; set; }

    public DateTime? FechaDeConsulta { get; set; }

    public string? Diagnostico { get; set; }

    public string? NombreMedico { get; set; }

    public string? NotasAdicionales { get; set; }

    public virtual Paciente? IdPacienteNavigation { get; set; }
    public string? NombrePaciente { get; set; }
}
