using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SIMAS.Repositories;
using SIMAS.Areas.Administrador.Models;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;

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
            var documentosIEnumerable = repos.GetDocumentoConNavigationCategoria();
            //var documentoIEnumerable = repos.GetDocumentoConNavigationSubcategoria();
            return View(documentosIEnumerable);
        }


        [Route("Administrador/AgregarDocumento")]
        public IActionResult AgregarDocumento()
        {
            return View();


        }

        [HttpPost]
        public IActionResult AgregarDocumento(DocumentoViewModel d)
        {
            try
            {
                DocumentosRepository repos = new DocumentosRepository();
                Regex regex = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ0-9 ]+$");
                bool resultado = regex.IsMatch(d.Nombre);

                if (repos.GetDocumentoByNombre(d.Nombre) != null)
                {
                    ModelState.AddModelError("", "Ya existe un documento con este nombre");
                    return View(d);
                }
                if (!resultado)
                {
                    ModelState.AddModelError("", "El nombre del documento no puede y caracteres especiales.");
                    return View(d);
                }
                repos.Insert(d);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(d);
            }
        }

        [Route("Administrador/EditarDocumento/{id}")] 
        public IActionResult EditarDocumento(int id)
        {
            DocumentosRepository repos = new DocumentosRepository();
            var d = repos.GetDocumentoById(id);
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
        public IActionResult EditarDocumento(DocumentoViewModel d)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DocumentosRepository repos = new DocumentosRepository();
                    Regex regex = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ0-9 ]+$");
                    bool resultado = regex.IsMatch(d.Nombre);

                    if (repos.GetDocumentoByNombre(d.Nombre) != null)
                    {
                        ModelState.AddModelError("", "Ya existe un documento con este nombre");
                        return View(d);
                    }
                    if (!resultado)
                    {
                        ModelState.AddModelError("", "El nombre del documento no puede y caracteres especiales.");
                        return View(d);
                    }
                    repos.Update(d);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(d);
                }
            }
            else
            {
                return View(d);
            }
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
