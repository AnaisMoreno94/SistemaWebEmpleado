﻿using Microsoft.AspNetCore.Mvc;
using System;

namespace SistemaWebEmpleado.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Mensaje = "Bienvenido al sitio web!";
            ViewBag.Fecha = DateTime.Now.ToString();
            return View();
        }
    }
}
