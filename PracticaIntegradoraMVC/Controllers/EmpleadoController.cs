using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaWebEmpleado.Data;
using SistemaWebEmpleado.Models;
using System.Collections;
using System.Linq;

namespace SistemaWebEmpleado.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly DBEmpleadosContext context;
        public EmpleadoController(DBEmpleadosContext contex)
        {
            this.context = contex;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var empleados = context.Empleados.ToList();
            return View(empleados);
        }
        [HttpGet]
        public IActionResult IndexByTitle(string titulo)
        {
            var empleados =(from e in context.Empleados
                            where e.Titulo == titulo
                            select e).ToList();
            return View("Index", empleados);
        }



        [HttpGet]
        public ActionResult Create()
        {
            Empleado empleado = new Empleado();

            return View(empleado);//Vista para crear la opera
        }

        [HttpPost]
        public ActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                context.Empleados.Add(empleado);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", empleado);

        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var empleado = context.Empleados.Find(id);

            if (empleado == null) { return NotFound(); }
            else { return View("Delete", empleado); }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var empleado = context.Empleados.Find(id);
            if (empleado == null) return NotFound();
            else
            {
                context.Empleados.Remove(empleado);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var empleado = context.Empleados.Find(id);
            if (empleado == null) return NotFound();
            else return View("Detail", empleado);
        }

        [HttpGet]
        public ActionResult Edit(int id) 
        {
            var empleado = context.Empleados.Find(id);
            if (empleado == null) return NotFound();
            else return View("Edit", empleado);

        }
        [HttpPost]
        public ActionResult Edit(Empleado empleado) 
        {
            if (ModelState.IsValid)
            {
                context.Entry(empleado).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else return View("Edit", empleado);
        }

    }
}

