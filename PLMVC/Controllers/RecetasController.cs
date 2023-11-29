using Microsoft.AspNetCore.Mvc;

namespace PLMVC.Controllers
{
    public class RecetasController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            ML.RecetasMedicas recetas = new ML.RecetasMedicas();
            ML.Result result = BL.RecetasMedicas.GetAll();

            if (result.Correct)
            {
                recetas.RecetasMdicasG = result.ObjectS;
            }
            else
            {
                return View();
            }
            return View(recetas);
        }
        [HttpGet]
        public IActionResult Form(int? IdReceta)
        {
            ML.RecetasMedicas recetas = new ML.RecetasMedicas();
            recetas.Paciente = new ML.Paciente();
            ML.Result resulPaciente = BL.Paciente.GetAll();
            if (IdReceta != null) 
            {
                ML.Result result = BL.RecetasMedicas.GetById(IdReceta.Value);
                if (result.Correct)
                {
                    recetas = (ML.RecetasMedicas)result.Object;
                    recetas.Paciente.Pacientes = resulPaciente.ObjectS;
                }
            }
            else
            {
                recetas.Paciente.Pacientes = resulPaciente.ObjectS;
            }
            return View(recetas);
        }
        [HttpPost]
        public IActionResult Form(ML.RecetasMedicas recetas)
        {
            if (recetas.IdReceta == 0)
            {
                ML.Result result = BL.RecetasMedicas.Add(recetas);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se registro correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "Error al registrar";
                }
            }
            else
            {
                ML.Result result = BL.RecetasMedicas.Update(recetas);
                if(result.Correct)
                {
                    ViewBag.Mensaje = "Se Actualizo correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "Error al Actualizar";
                }
            }
            return PartialView("Modal");
        }
        [HttpGet]
        public IActionResult Delete(int IdRecetas)
        {
            ML.Result result = BL.RecetasMedicas.Delete(IdRecetas);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Se elimino correctamente";
            }
            else
            {
                ViewBag.Mensaje = "Error al eliminar";
            }
            return PartialView("Modal");
        }
    }
}
