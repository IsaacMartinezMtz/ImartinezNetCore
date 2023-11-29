using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RecetasMedicas
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ImartinezNetCoreContext contex = new DL.ImartinezNetCoreContext())
                {
                    var query = contex.RecetasMedicas.FromSqlRaw("RecetasGetAll").ToList();
                    if (query.Count > 0)
                    {
                        result.ObjectS = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.RecetasMedicas recetaMed = new ML.RecetasMedicas();
                            recetaMed.IdReceta = obj.IdReceta;
                            recetaMed.Paciente = new ML.Paciente();
                            recetaMed.Paciente.IdPaciente = (int)obj.IdPaciente;
                            recetaMed.Paciente.Nombre = obj.NombrePaciente;
                            recetaMed.FechaDeconsultaG = (DateTime)obj.FechaDeConsulta;
                            recetaMed.Diagnostico = obj.Diagnostico;
                            recetaMed.NombreMedico = obj.NombreMedico;
                            recetaMed.NotasAdicionales = obj.NotasAdicionales;

                            result.ObjectS.Add(recetaMed);
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
        public static ML.Result GetById(int IdReceta)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ImartinezNetCoreContext cotext = new DL.ImartinezNetCoreContext())
                {
                    var query = cotext.RecetasMedicas.FromSqlRaw($"RecetasGetById {IdReceta}").AsEnumerable().FirstOrDefault();
                    result.Object = new List<object>();
                    if (query != null)
                    {
                        ML.RecetasMedicas recetasM = new ML.RecetasMedicas();
                        recetasM.IdReceta= query.IdReceta;
                        recetasM.Paciente = new ML.Paciente();
                        recetasM.Paciente.IdPaciente = (int)query.IdPaciente;
                        recetasM.Paciente.Nombre = query.NombrePaciente;
                        recetasM.FechaDeconsultaG = (DateTime)query.FechaDeConsulta;
                        recetasM.Diagnostico = query.Diagnostico;
                        recetasM.NombreMedico = query.NombreMedico;
                        recetasM.NotasAdicionales = query.NotasAdicionales;

                        result.Object = recetasM;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct= false;
                    }
                }

            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMesasage= ex.Message;
            }
            return result;
        }

        public static ML.Result Add(ML.RecetasMedicas recetas)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ImartinezNetCoreContext context = new DL.ImartinezNetCoreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"RecetaMedicaAdd {recetas.Paciente.IdPaciente}, '{recetas.FechaDeconsulta}','{recetas.Diagnostico}','{recetas.NombreMedico}', '{recetas.NotasAdicionales}'");
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMesasage = ex.Message;
            }
            return result;
        }
        public static ML.Result Delete(int IdRecetas)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ImartinezNetCoreContext context = new DL.ImartinezNetCoreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"RecetasMedicasDelete {IdRecetas}");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }catch(Exception ex) 
            {
                result.Correct = false;
                result.ErrorMesasage=ex.Message;
            }
            return result;
        }
        public static ML.Result Update (ML.RecetasMedicas recetas)
        {
            ML.Result result= new ML.Result();
            try
            {
                using(DL.ImartinezNetCoreContext context =new DL.ImartinezNetCoreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"MateriasUpdate {recetas.IdReceta},{recetas.Paciente.IdPaciente}, '{recetas.FechaDeconsulta}','{recetas.Diagnostico}','{recetas.NombreMedico}', '{recetas.NotasAdicionales}'");
                    if (query > 0)
                    {
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
                result.Correct=false;
                result.ErrorMesasage=ex.Message;
            }
            return result;
        }
    }
}
