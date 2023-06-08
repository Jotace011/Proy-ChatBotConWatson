using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PostulacionesTecsite.Models;
using PostulacionesTecsite.Servicios;
using System.Security.Claims;

namespace PostulacionesTecsite.Controllers
{
    public class AccesoController : Controller
    {
        ServicioUsuario_API data = new ServicioUsuario_API();

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(string correo, string clave) 
        {
            var usuarios = new listaUsuarioRoles();
            var user = data.listaUsuarioRoles().Result.Where(item => item.correo_usu == correo && item.clave_usu == clave).FirstOrDefault();           

            if (user != null)
            {
                var id = user.dni_usu;
                var mail = user.correo_usu;
                HttpContext.Session.SetString("correo", id);
                HttpContext.Session.SetString("clave", mail);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.nom_usu),
                    new Claim("mail_usuario",user.correo_usu),
                    new Claim(ClaimTypes.Role,user.desc_rol)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }
            else
            {

                return View();
            }
        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Acceso");
        }

    }
}
