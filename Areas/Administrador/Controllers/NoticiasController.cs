using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIMAS.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using SIMAS.Areas.Administrador.Models;
using System.Text.RegularExpressions;
using SIMAS.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace SIMAS.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    public class NoticiasController : Controller
    {
        public IHostingEnvironment Environment { get; set; }

        public NoticiasController(IHostingEnvironment env)
        {
            Environment = env;
        }

        private readonly IHostingEnvironment hostingEnvironment;

        [Route("Administrador/Noticias")]
        public IActionResult Index()
        {
            NoticiasRepository repos = new NoticiasRepository();
            return View(repos.GetNoticias());
        }

        //Administrador ---- AgregarNoticia
        [Route("Administrador/AgregarNoticia")]
        public IActionResult AgregarNoticia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AgregarNoticia(NoticiasViewModel n)
        {
            string uniqueFileName = null;
            if (ModelState.IsValid)
            {
                try
                {
                    NoticiasRepository noticiasRepository = new NoticiasRepository();
                    var notic = noticiasRepository.GetNoticiasByNombre(n.Encabezado);

                    if (notic == null)
                    {
                        noticiasRepository.Insert(n);

                        if (n.Foto == null)
                        {
                            noticiasRepository.SetNoPhoto(n.idNoticias, $"{Environment.WebRootPath}");
                        }
                        else if (n.Foto.ContentType != "image/jpeg")
                        {
                            ModelState.AddModelError("", "Solo se pueden cargar imagenes JPEG.");
                            return View(n);
                        }
                        else if (n.Foto.Length > 1024 * 1024)
                        {
                            ModelState.AddModelError("", "El tamaño maximo de una imagen es de [ 1 MB ].");
                            return View(n);
                        }
                        else
                        {
                            noticiasRepository.GuardarArchivo(n.idNoticias, n.Foto, $"{Environment.WebRootPath}");
                        }

                        noticiasRepository.GuardarArchivo(n.idNoticias, n.Foto, $"{Environment.WebRootPath}");

                        return RedirectToAction("Noticias", "Administrador");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Ya existe una noticia con este nombre");
                        return View(n);
                    }
                

                
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(n);
                }
            }
            else
            {
                return View(n);
            }
                 
        }

        [Route("Administrador/EditarNoticia/{id}")]
        public IActionResult EditarNoticia(int id)
        {
            NoticiasRepository repos = new NoticiasRepository();
            var n = repos.NoticiaById(id);
            if (n == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
               return View(n);
            }
        }


        [HttpPost]
        public IActionResult EditarNoticia(NoticiasViewModel n)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    NoticiasRepository noticiasRepository = new NoticiasRepository();
                    var notic = noticiasRepository.GetNoticiasByNombre(n.Encabezado);

                    if (notic == null)
                    {
                        noticiasRepository.Update(n);

                        if (n.Foto == null)
                        {
                        }
                        else if (n.Foto.ContentType != "image/jpeg")
                        {
                            ModelState.AddModelError("", "Solo se pueden cargar imagenes JPG.");
                            return View(n);
                        }
                        else if (n.Foto.Length > 1024 * 1024)
                        {
                            ModelState.AddModelError("", "El tamaño maximo de una imagen es de [ 1 MB ].");
                            return View(n);
                        }
                        else
                        {
                            noticiasRepository.GuardarArchivo(n.idNoticias, n.Foto, $"{Environment.WebRootPath}");
                        }
                        return RedirectToAction("Noticias", "Administrador");
                    }
                    else if (notic.IdNoticias == n.idNoticias)
                    {
                        notic.Encabezado = n.Encabezado;
                        notic.Autor = n.Autor;
                        notic.Fecha = n.Fecha;
                        notic.DescripcionCorta = n.DescripcionCorta;
                        notic.Cuerpo = n.Cuerpo;
                        notic.VideoUrl = n.VideoURL;

                        noticiasRepository.Update(notic);

                        if (n.Foto == null)
                        {
                            //noticiasRepository.SetNOPhoto(n.idNoticias, Environment.WebRootPath);
                        }

                        else if (n.Foto.ContentType != "image/jpeg")
                        {
                            ModelState.AddModelError("", "Solo se pueden cargar imagenes JPG");
                            return View(n);
                        }
                        else if (n.Foto.Length > 1024 * 1024)
                        {
                            ModelState.AddModelError("", "El tamaño maximo de una imagen es de [ 1 MB ].");
                            return View(n);
                        }
                        else
                        {
                            noticiasRepository.GuardarArchivo(n.idNoticias, n.Foto, $"{Environment.WebRootPath}");
                        }
                        return RedirectToAction("Noticias", "Administrador");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Ya existe una notic con este nombre");
                        return View(n);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(n);
                }
            }
            else
            {
                return View(n);
            }
        }
       

        [HttpPost]
        public IActionResult EliminarNoticia(int id)
        {
            NoticiasRepository noticiasRepository = new NoticiasRepository();
            var n = noticiasRepository.GetById(id);
            if (n != null)
            {
                noticiasRepository.Delete(n);
                ViewBag.Mensaje = "La noticia ha sido eliminada exitosamente."; 
            }
            else
              ViewBag.Mensaje = "La noticia no existe o ya ha sido eliminada.";
            return RedirectToAction("Index");
        }



        [Route("Administrador/Imagen/{id}")]
        public IActionResult Imagen(int id)
        {
            NoticiasRepository repos = new NoticiasRepository();
            var n = repos.NoticiaById(id);

            if (n == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(n);
            }
        }
        [HttpPost]
        public IActionResult Imagen(NoticiasViewModel n)
        {
            NoticiasRepository repos = new NoticiasRepository();
            if (n.Foto == null)
            {
                if (n.Foto.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("", "Solo puede cargar imagenes en formato JPG.");
                    return View(n);
                }
                if (n.Foto.Length > 1024 * 1024)
                {
                    ModelState.AddModelError("", "El tamaño máximo del archivo debe ser 1MB.");
                    return View(n);
                }

                repos.GuardarArchivo(n.idNoticias, n.Foto, Environment.WebRootPath);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Debe seleccionar un archivo.");
                return View(n);
            }
        }

        public IActionResult VistaPrevia()
        {
            return View();
        }

    }
}
