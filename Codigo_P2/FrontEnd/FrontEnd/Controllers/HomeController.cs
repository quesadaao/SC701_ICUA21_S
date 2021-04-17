using FrontEnd.DAL;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MVC = System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private PeliculasRepository _repository;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _repository = new PeliculasRepository();
        }

        public IActionResult Index()
        {

            // 1 envio de un html hacia el view
            //return Content("Pedro");
            // 2 Uso de variables para carga de datos diferentes al modelo del controller
            //ViewBag.Variable1 = "Envio de Lista de Objetos";
            //ViewData["Variable2"] = "Envio de grupos sayayin a la tierra";
            //return View();
            // 3 Redireccionamiento hacia paginas externas
            //return Redirect("http://google.com");
            // 4 Redireccionamiento hacia Controller y Action en especifico
            //return RedirectToAction("Index","Customers");

            return View();
        }

        public MVC.HttpStatusCodeResult Description()
        {
            // 5 Envio de status code por medio del action 

            //return new MVC.HttpStatusCodeResult(401,"hOlas error ");

            // Envio de un Warining 

            return new MVC.HttpStatusCodeResult(301, "hOlas warning ");
        }

        //public IActionResult Querys(string nombre)
        //{
        //    // 6 Envio de datos por medio URL string 
        //    ViewData["nombre"] = nombre;
        //    return View();
        //}

        public IActionResult Querys(string nombre, int edad)
        {
            // 6 Envio de datos por medio URL string 
            ViewData["nombre"] = nombre;
            ViewBag.edad = edad;
            return View();
        }

        // 7 Carga de informacion en el load del view y un action recargando la informacion agregada en la parte1  
        [HttpGet]
        public IActionResult Contact()
        {
            ViewBag.Variable1 = "Envio de Lista de Objetos";
            
            ViewBag.edad = 55;
            ViewBag.Fecha = DateTime.Today;
            return View();
        }

        [HttpPost]
        public IActionResult Contact(int edad)
        {
            ViewData["Variable2"] = "Envio de grupos sayayin a la tierra de edad " + edad;
            return View();
        }

        // 8 Carga de datos con apis personalizadas
        public IActionResult MisPeliculas()
        {
            ViewBag.Message = "Test de carga de Peliculas";
            var model = _repository.GetPeliculas();
            return View(model);
        }

        // 9 Carga de datos con DisplayTemplates
        public IActionResult MisDisplaytemplate()
        {
            ViewBag.propiedad = new PersonaTemp { Nombre = "Pedro", Edad = 15, Empleado = true, Nacimiento = DateTime.Today }; 
            return View();
        }

        // 10 Carga de datos con dropdownList
        public IActionResult MiDropDownList()
        {
            ViewBag.listado = _repository.GetData();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class PersonaTemp {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public bool Empleado { get; set; }
        public DateTime Nacimiento { get; set; }

    }
}
