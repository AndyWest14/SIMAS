using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SIMAS.Repositories;
using SIMAS.Areas.Administrador.Models;

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

        [Route("Administrador/DocumentosLGCG")]
        public IActionResult Index()
        {
            DocumentosRepository repos = new DocumentosRepository();
            return View(repos.GetDocumentos());
        }

        [Route("Administrador/AgregarDocumento")]
        public IActionResult AgregarDocumento()
        {
            return View();


        }

        [HttpPost]
        public IActionResult AgregarDocumento(DocumentoViewModel d)
        {
            return View(d);
        }

        [Route("Administrador/EditarDocumento/{id}")]
        public IActionResult EditarDocumento(int id)
        {
            DocumentosRepository repos = new DocumentosRepository();
            var d = repos.DocumentoById(id);
            if (d == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(d);
            }
        }

        [HttpPost]
        public IActionResult Editar (DocumentoViewModel d)
        {
            return View(d);
        }

        [HttpPost]
        public IActionResult EliminarDocumento(int id)
        {
            DocumentosRepository documentosRepository = new DocumentosRepository();
            var d = documentosRepository.GetById(id);
            if (d != null)
            {
                documentosRepository.Delete(d);
                ViewBag.Mensaje = "El documento ha sido eliminado exitosamente.";
            }
            else
                ViewBag.Mensaje = "El documento no existe o ya ha sido eliminado.";
            return RedirectToAction("Index");
        }


    }
}
