using TeCreemos.Components.Page;
using TeCreemos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TeCreemos.Models.DB;

namespace TeCreemos.Controllers
{
    public class UsuarioController : Controller
    {
        public TeCreemosDb _context;
        public UsuarioController(TeCreemosDb master)
        {
            this._context = master;
        }

        public IActionResult Index()
        {
            List<usuario> lst = new List<usuario>();
            using (var db = new Models.DB.TeCreemosDb())
            {
                lst = (from u in db.Usuarios
                       select new usuario
                       {
                           id = u.IdEstatus,
                           nombre = u.Nombre,
                           apellidos = u.Apellidos,
                           claveAcceso = u.ClaveAcceso,
                           idEstatus = u.IdEstatus
                       }).ToList();
            }
            ViewBag.estatus = selectionList.lstStatus(0);
            ViewBag.tipoMov = selectionList.lstTipoMovimiento(2);

            return View(lst);
        }

        [HttpPost]
        public IActionResult UserLogin(string Clave, string Password)
        {
            var user = _context.Usuarios.Where(u => u.ClaveAcceso == Clave && u.Contrasenia == Password);

            if (user.Any())
            {
                if (user.Where(u => u.ClaveAcceso == Clave && u.Contrasenia == Password).Any())
                {
                    return Json(new { status = true, message = $"Bienvenido {user.First().Nombre} {user.First().Apellidos}" });
                }
                else
                {
                    return Json(new { status = false, message = $"El usuario o contraseña son incorrectos" });
                }
            }
            else
            {
                return Json(new { status = true, message = $"Bienvenido {user.First().Nombre} {user.First().Apellidos}" });
            }

        }
    }
}
