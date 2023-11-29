using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class RecetasMedicas
    {
        public static void GetAll()
        {

          ML.Result result = new ML.Result();
          result = BL.RecetasMedicas.GetAll();

            List<object> objects = result.ObjectS;


            if (result.Correct)
           {
                foreach (ML.RecetasMedicas recetas in objects)
                {
                    Console.WriteLine("-------------");
                    Console.WriteLine("Id Receta: " + recetas.IdReceta);
                    Console.WriteLine("Id Paciente: " + recetas.Paciente.IdPaciente);
                    Console.WriteLine("Fecha de Consulta: " + recetas.FechaDeconsultaG);
                    Console.WriteLine("Diagnostico: " + recetas.Diagnostico);
                    Console.WriteLine("Diagnostico: " + recetas.NombreMedico);
                    Console.WriteLine("Diagnostico: " + recetas.NotasAdicionales);

                }
            }
            else
            {
                Console.WriteLine("Error " + result.ErrorMesasage);
            }
        }

        public static void GetById()
        {
            Console.WriteLine("Ingresa el id del usuario a consultar");
            int IdReceta = int.Parse(Console.ReadLine());
            ML.Result result = new ML.Result();
            result = BL.RecetasMedicas.GetById(IdReceta); 
                ML.RecetasMedicas recetas = new ML.RecetasMedicas();

            


            if (result.Correct)
            {
                recetas = (ML.RecetasMedicas)result.Object;
                    Console.WriteLine("-------------");
                    Console.WriteLine("Id Receta: " + recetas.IdReceta);
                    Console.WriteLine("Id Paciente: " + recetas.Paciente.IdPaciente);
                    Console.WriteLine("Fecha de Consulta: " + recetas.FechaDeconsultaG);
                    Console.WriteLine("Diagnostico: " + recetas.Diagnostico);
                    Console.WriteLine("Nombre del Medico: " + recetas.NombreMedico);
                    Console.WriteLine("Notas Adicionales : " + recetas.NotasAdicionales);

                
            }
            else
            {
                Console.WriteLine("Error " + result.ErrorMesasage);
            }
        }

        public static void Add()
        {
            ML.RecetasMedicas recetas = new ML.RecetasMedicas();

            Console.WriteLine("Ingresa el id del paciente");
            recetas.Paciente = new ML.Paciente(); 
            recetas.Paciente.IdPaciente = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la Fecha de Consulta ");
            recetas.FechaDeconsulta = Console.ReadLine();
            Console.WriteLine("Ingresa el diagnostico");
            recetas.Diagnostico = Console.ReadLine();
            Console.WriteLine("Ingresa el Nombre del medico");
            recetas.NombreMedico = Console.ReadLine();
            Console.WriteLine("Ingresa las notas adicionales");
            recetas.NotasAdicionales = Console.ReadLine();

            ML.Result result= BL.RecetasMedicas.Add(recetas);
            if (result.Correct)
            {
                Console.WriteLine("Receta Ingresado Correctamente");

            }
            else
            {
                Console.WriteLine("Receta no ingresada: " + result.ErrorMesasage);
            }
        }
        public static void Delete()
        {
            Console.WriteLine("Ingresa el id del la receta a eliminar");
            int IdReceta = int.Parse(Console.ReadLine());
           

            ML.Result result = BL.RecetasMedicas.Delete(IdReceta);
            if (result.Correct)
            {
                Console.WriteLine("Receta Eliminado Correctamente");

            }
            else
            {
                Console.WriteLine("Receta no Eliminada: " + result.ErrorMesasage);
            }
        }

        public static void Update()
        {
            ML.RecetasMedicas recetas = new ML.RecetasMedicas();

            Console.WriteLine("Ingresa el id de la receta a actualizar");
            recetas.IdReceta = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el id del paciente");
            recetas.Paciente = new ML.Paciente();
            recetas.Paciente.IdPaciente = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la Fecha de Consulta ");
            recetas.FechaDeconsulta = Console.ReadLine();
            Console.WriteLine("Ingresa el diagnostico");
            recetas.Diagnostico = Console.ReadLine();
            Console.WriteLine("Ingresa el Nombre del medico");
            recetas.NombreMedico = Console.ReadLine();
            Console.WriteLine("Ingresa las notas adicionales");
            recetas.NotasAdicionales = Console.ReadLine();

            ML.Result result = BL.RecetasMedicas.Update(recetas);
            if (result.Correct)
            {
                Console.WriteLine("Receta Actualizada Correctamente");

            }
            else
            {
                Console.WriteLine("Receta no Actualizada: " + result.ErrorMesasage);
            }

        }

    }
}
