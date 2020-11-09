using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SIMAS.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace SIMAS.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //Accion para IniciarSesion
        public async Task<IActionResult> Index(string user, string password)
        {
            try
            {
                bdsimasContext context = new bdsimasContext();

                var usuario = context.Usuario
                    .FirstOrDefault(x => x.Nombre == user && x.Contraseña == password);

                if (usuario == null)
                {
                    ModelState.AddModelError("", "El usuario o la contraseña son incorrectos");
                    return View();

                }
                else
                {
                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,usuario.Nombre),
                            new Claim(ClaimTypes.Role,usuario.Rol),
                            new Claim("Id",usuario.Id.ToString()),
                        };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Administrador/Home");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }


        public IActionResult Denied()
        {
            return View();
        }

        //Acccion para CerrarSesion
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
