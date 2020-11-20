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
    public class SubcategoriasController : Controller
    {
        public IHostingEnvironment Environment { get; set; }

        public SubcategoriasController(IHostingEnvironment env)
        {
            Environment = env;
        }

        [Route("Administrador/Subcategorias")]
        public IActionResult Index()
        {
            SubcategoriasRepository repos = new SubcategoriasRepository();
            var subcategoriasIEnumerable = repos.GetSubcategoriasConNavigation();
            return View(subcategoriasIEnumerable);
        }

        [Route("Administrador/AgregarSubcategoria")]
        public IActionResult AgregarSubcategoria()
        {
            return View();

        }

        [HttpPost]
        public IActionResult AgregarSubcategoria(SubcategoriasViewModel s)
        {
            try
            {
                SubcategoriasRepository repos = new SubcategoriasRepository();
                Regex regex = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ0-9 ]+$");
                bool resultado = regex.IsMatch(s.Nombre);

                if (repos.GetSubcategoriasByNombre(s.Nombre) != null)
                {
                    ModelState.AddModelError("", "Ya existe una subcategoria con este nombre");
                    return View(s);
                }
                if (!resultado)
                {
                    ModelState.AddModelError("", "El nombre de la subcategoria no puede y caracteres especiales.");
                    return View(s);
                }
                repos.Insert(s);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(s);
            }
        }

        [Route("Administrador/EditarSubcategoria/{id}")]
        public IActionResult EditarSubcategoria(int id)
        {
            SubcategoriasRepository repos = new SubcategoriasRepository();
            var c = repos.GetSubcategoriasById(id);
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
        public IActionResult EditarSubcategoria(SubcategoriasViewModel s)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SubcategoriasRepository repos = new SubcategoriasRepository();
                    Regex regex = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ0-9 ]+$");
                    bool resultado = regex.IsMatch(s.Nombre);

                    if (repos.GetSubcategoriasByNombre(s.Nombre) != null)
                    {
                        ModelState.AddModelError("", "Ya existe una subcategoria con este nombre");
                        return View(s);
                    }
                    if (!resultado)
                    {
                        ModelState.AddModelError("", "El nombre de la subcategoria no puede y caracteres especiales.");
                        return View(s);
                    }
                    repos.Update(s);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(s);
                }
            }
            else
            {
                return View(s);
            }
        }

        [HttpPost]
        public IActionResult EliminarSubcategoria(int id)
        {
            SubcategoriasRepository repos = new SubcategoriasRepository();
            var s = repos.GetById(id);
            if (s != null)
            {
                repos.Delete(s);
                ViewBag.Mensaje = "La subcategoria ha sido eliminado exitosamente.";
            }
            else
                ViewBag.Mensaje = "La subcategoria no existe o ya ha sido eliminado.";
            return RedirectToAction("Index");
        }
    }
}
