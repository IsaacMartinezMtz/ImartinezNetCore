using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Paciente
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ImartinezNetCoreContext contex = new DL.ImartinezNetCoreContext())
                {

                    var query = contex.Pacientes.FromSqlRaw("GetAllPacientes").ToList();
                    if (query.Count > 0)
                    {
                        result.ObjectS = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Paciente paciente = new ML.Paciente();
                            paciente.IdPaciente = obj.IdPaciente;
                            paciente.Nombre = obj.Nombre;
                            result.ObjectS.Add(paciente);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMesasage = ex.Message;
            }
            return result;
        }
    }
}
