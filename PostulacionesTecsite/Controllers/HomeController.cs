using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostulacionesTecsite.Models;
using PostulacionesTecsite.Servicios;
using System.Diagnostics;

namespace PostulacionesTecsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicio_API _servicioAPI;

        public HomeController(IServicio_API _servicio)
        {
            _servicioAPI = _servicio;
        }

        public  ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> listaUsuarios()
        {
            List<listaUsuarioRoles> lista = await _servicioAPI.listaUsuarioRoles();
            return View(lista);
        }

        public IActionResult RegistrarUsuario()
        {
            return View(new Usuario());
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarUsuario(Usuario usuario)
        {
            await _servicioAPI.guardarUsuario(usuario);

            return RedirectToAction("Login","Acceso");
        }
        [Authorize(Roles = "ADMIN, USUARIO")]
        [HttpPost("index/registrarSolicitudes")]
        public async Task<IActionResult> RegistrarSolicitud(Solicitudes solicitudes)
        {
            await _servicioAPI.guardarSolicitud(solicitudes);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult editarUsuario()
        {
            return View();
        }

        [Authorize(Roles = "ADMIN")]
        public async Task< IActionResult > listarSolicitudes()
        {
            List<ListarSolicitudes> lista = await _servicioAPI.listarSolicitudes();
            return View(lista);
        }

        public async Task<IActionResult> aceptarSolis(int codSoli)
        {
            await _servicioAPI.aceptarSoli(codSoli);
            return RedirectToAction("listarSolicitudes", "Home");
        }

        public async Task<IActionResult> rechazarSolis(int codSoli)
        {
            await _servicioAPI.aceptarSoli(codSoli);
            return RedirectToAction("listarSolicitudes", "Home");
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
}