using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SIMAS.Repositories;

namespace SIMAS.Controllers
{
    public class HomeController : Controller
    {
        public IHostingEnvironment Environment { get; set; }

        public HomeController(IHostingEnvironment env)
        {
            Environment = env;
        }

        public IActionResult Index()
        {
            return View();
        }


        //NOSOTROS
        [Route("Historia")]
        public IActionResult Historia()
        {
            return View();
        }

        [Route("Nosotros")]
        public IActionResult Nosotros()
        {
            return View();
        }

        [Route("Contacto")]
        public IActionResult Contacto()
        {
            return View();
        }


        //TRAMITES Y SERVICIOS
        [Route("Contratos")]
        public IActionResult Contratos()
        {
            return View();
        }

        [Route("FacturacionElectronica")]
        public IActionResult FacturacionElectronica()
        {
            return View();
        }

        [Route("Pensionado")]
        public IActionResult Pensionado()
        {
            return View();
        }

        [Route("CentrosPago")]
        public IActionResult CentrosPago()
        {
            return View();
        }

        //TARIFAS
        [Route("Tarifas")]
        public IActionResult Tarifas()
        {
            return View();
        }

        //CULTURA DEL AGUA

        [Route("CulturaAgua")]
        public IActionResult CulturaAgua()
        {
            return View();
        }

        [Route("ProgramasActividades")]
        public IActionResult  ProgramasActividades()
        {
            return View();
        }

        [Route("CuidaAgua")]
        public IActionResult CuidaAgua()
        {
            return View();
        }

        //TRANSPARENCIA
        [Route("Transparencia")]
        public IActionResult Transparencia()
        {
            return View();
        }

        [Route("TransparenciaLGCG")]
        public IActionResult TransparenciaLGCG()
        {
            return View();
        }

        //[Route("TransparenciaLGCG/{Nombre}")]
        [Route("TransparenciaLGCGCategoria")]
        public IActionResult TransparenciaLGCGCategoria()
        {
            return View();
        }

        [Route("TransparenciaLGCGArchivos")]
        public IActionResult TransparenciaLGCGArchivos()
        {
            return View();
        }

        //PREGUNTAS FRECUENTES
        [Route("PreguntasFrecuentes")]
        public IActionResult PreguntasFrecuentes()
        {
            return View();
        }


        //LEER MEDIDOR
        [Route("LeerMedidor")]
        public IActionResult LeerMedidor()
        {
            return View();
        }

        //REPORTAR FUGA
        [Route("ReportarFuga")]
        public IActionResult ReportarFuga()
        {
            return View();
        }

        //RECIBO
        [Route("Recibo")]
        public IActionResult Recibo()
        {
            return View();
        }



        //NOTICIAS
        [Route("Noticias")]
        public IActionResult Noticias()
        {
            return View();
        }

        //[Route("Noticia/{Id}")]
        [Route("Noticia")]
        public IActionResult Noticia()
        {
            return View();
        }

        //GALERIA
        [Route("Galeria")]
        public IActionResult Galeria()
        {
            return View();
        }

       
    }
}
