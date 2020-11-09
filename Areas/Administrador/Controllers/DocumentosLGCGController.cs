using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SIMAS.Models;
using SIMAS.Models.ViewModels;
using SIMAS.Repositories;

namespace SIMAS.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    public class DocumentosLGCGController : Controller
    {
        public IHostingEnvironment Environment { get; set; }

        public DocumentosLGCGController(IHostingEnvironment env)
        {
            Environment = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AgregarDocumento()
        {
            return View();
        }


        public IActionResult EditarDocumento()
        {
            return View();
        }




    }
}
