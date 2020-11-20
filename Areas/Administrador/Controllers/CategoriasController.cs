using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SIMAS.Areas.Administrador.Models;
using SIMAS.Repositories;

namespace SIMAS.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    public class CategoriasController : Controller
    {
        public IHostingEnvironment Environment { get; set; }

        public CategoriasController(IHostingEnvironment env)
        {
            Environment = env;
        }

        [Route("Administrador/Categorias")]
        public IActionResult Index()
        {
            CategoriasRepository repos = new CategoriasRepository();
            return View(repos.GetCategorias());
        }

        [Route("Administrador/AgregarCategoria")]
        public IActionResult AgregarCategoria()
        {
            return View();

        }

        [HttpPost]
        public IActionResult AgregarCategoria(CategoriasViewModel c)
        {
            try
            {
                CategoriasRepository repos = new CategoriasRepository();
                Regex regex = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ0-9 ]+$");
                bool resultado = regex.IsMatch(c.Nombre);

                if (repos.GetCategoriasByNombre(c.Nombre) != null)
                {
                    ModelState.AddModelError("", "Ya existe una categoria con este nombre");
                    return View(c);
                }
                if (!resultado)
                {
                    ModelState.AddModelError("", "El nombre de la categoria no puede y caracteres especiales.");
                    return View(c);
                }
                repos.Insert(c);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(c);
            }

        }

        [Route("Administrador/EditarCategoria/{id}")]
        public IActionResult EditarCategoria(int id)
        {
            CategoriasRepository repos = new CategoriasRepository();
            var c = repos.GetCategoriaById(id);
            if (c == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(c);
            }
        }

        [HttpPost]
        public IActionResult EditarCategoria(CategoriasViewModel c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CategoriasRepository repos = new CategoriasRepository();
                    Regex regex = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ0-9 ]+$");
                    bool resultado = regex.IsMatch(c.Nombre);

                    if (repos.GetCategoriasByNombre(c.Nombre) != null)
                    {
                        ModelState.AddModelError("", "Ya existe una categoria con este nombre");
                        return View(c);
                    }
                    if (!resultado)
                    {
                        ModelState.AddModelError("", "El nombre de la categoria no puede y caracteres especiales.");
                        return View(c);
                    }
                    repos.Update(c);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(c);
                }
            }
            else
            {
                return View(c);
            }
        }

        [HttpPost]
        public IActionResult EliminarCategoria(int id)
        {
            CategoriasRepository categoriasRepository = new CategoriasRepository();
            var c = categoriasRepository.GetById(id);
            if (c != null)
            {
                categoriasRepository.Delete(c);
                ViewBag.Mensaje = "La categoria ha sido eliminado exitosamente.";
            }
            else
                ViewBag.Mensaje = "La categoria no existe o ya ha sido eliminado.";
            return RedirectToAction("Index");
        }

    }
}
