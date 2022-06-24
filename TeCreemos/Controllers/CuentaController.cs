using TeCreemos.Models;
using TeCreemos.Models.DB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TeCreemos.Components.Page;


namespace TeCreemos.Controllers
{
    public class CuentaController : Controller
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            estatus st = new estatus();
            ViewBag.tipoFiltro = selectionList.lstFiltroCta(1);
            List<cuenta> lst = new List<cuenta>();
            using (var db = new Models.DB.TeCreemosDb())
            {
                lst = (from c in db.Cuenta
                       select new cuenta
                       {
                           id = c.IdCuenta,
                           numero = c.Numero,
                           idCliente = c.IdCliente,
                           claveCliente = cliente.GetCteClave(c.IdCliente), 
                           idTipoCuenta = c.IdTipoCuenta,
                           saldo = c.Saldo,
                           tipoCuenta = tipoCuenta.GetTipoCtaDesc(c.IdTipoCuenta),
                           idEstatus = c.IdEstatus,
                           estatus = estatus.GetStatusDesc(c.IdEstatus),
                           fechaAlta = c.FechaAlta

                       }).ToList();
            }


            return View(lst);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index(int id)
        {
            estatus st = new estatus();
            ViewBag.tipoFiltro = selectionList.lstFiltroCta(2);
            ViewBag.ClaveCte = cliente.GetCteClave(id);
            List<cuenta> lst = new List<cuenta>();
            using (var db = new Models.DB.TeCreemosDb())
            {
                lst = (from c in db.Cuenta
                       select new cuenta
                       {
                           id = c.IdCuenta,
                           numero = c.Numero,
                           idCliente = c.IdCliente,
                           claveCliente = cliente.GetCteClave(c.IdCliente), 
                           idTipoCuenta = c.IdTipoCuenta,
                           tipoCuenta = tipoCuenta.GetTipoCtaDesc(c.IdTipoCuenta),
                           saldo = c.Saldo,
                           idEstatus = c.IdEstatus,
                           estatus = estatus.GetStatusDesc(c.IdEstatus),
                           fechaAlta = c.FechaAlta

                       }).ToList();

                var list = lst.Where(l => l.claveCliente == cliente.GetCteClave(id));

                return View(list);
            }
            }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoFiltro"></param>
        /// <param name="Criterio"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(int? tipoFiltro, string Criterio)
        {
            ViewBag.tipoFiltro = selectionList.lstFiltroCta(tipoFiltro);
            estatus st = new estatus();
            List<cuenta> lst = new List<cuenta>();
            using (var db = new Models.DB.TeCreemosDb())
            {
                if(tipoFiltro == 1) {
                    lst = (from c in db.Cuenta 
                           select new cuenta
                           {
                               id = c.IdCuenta,
                               numero = c.Numero,
                               idCliente = c.IdCliente,
                               claveCliente = cliente.GetCteClave(c.IdCliente), 
                               idTipoCuenta = c.IdTipoCuenta,
                               tipoCuenta = tipoCuenta.GetTipoCtaDesc(c.IdTipoCuenta),
                               saldo = c.Saldo,
                               idEstatus = c.IdEstatus,
                               estatus = estatus.GetStatusDesc(c.IdEstatus),
                               fechaAlta = c.FechaAlta

                           }).ToList();

                    var list = lst.Where(l => l.numero == Criterio);
                    return View(list);
                } else {
                    lst = (from c in db.Cuenta
                           select new cuenta
                           {
                               id = c.IdCuenta,
                               numero = c.Numero,
                               idCliente = c.IdCliente,
                               claveCliente = cliente.GetCteClave(c.IdCliente),
                               idTipoCuenta = c.IdTipoCuenta,
                               tipoCuenta = tipoCuenta.GetTipoCtaDesc(c.IdTipoCuenta),
                               saldo = c.Saldo,
                               idEstatus = c.IdEstatus,
                               estatus = estatus.GetStatusDesc(c.IdEstatus),
                               fechaAlta = c.FechaAlta

                           }).ToList();

                    var list = lst.Where(l => l.claveCliente == Criterio);
                    
                    return View(list); }
                

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.estatus = selectionList.lstStatus(1);
            ViewBag.tipoCuenta = selectionList.lstTipocuenta(0);

            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Cliente"></param>
        /// <param name="Numero"></param>
        /// <param name="IdTipoCuenta"></param>
        /// <param name="Saldo"></param>
        /// <param name="IdEstatus"></param>
        /// <param name="FechaAlta"></param>
        /// <param name="IdUsuarioAlta"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( string Cliente,string Numero, int IdTipoCuenta,double Saldo, int IdEstatus, string FechaAlta, int IdUsuarioAlta)
        {
            ViewBag.estatus = selectionList.lstStatus(1);
            ViewBag.tipoCuenta = selectionList.lstTipocuenta(0);

            //Se recupera info del cliente
            cliente cte = new cliente();
            cte.GetClienteData(Cliente);

            try
            {

                using (var db = new Models.DB.TeCreemosDb())
                {
                    var Cta = new CuentaCliente()
                    {
                        IdCliente = cte.id,
                        Numero = Numero,
                        IdTipoCuenta = IdTipoCuenta,
                        IdEstatus = IdEstatus,
                        Saldo = decimal.Parse(Saldo.ToString()),
                        FechaAlta = DateTime.Parse(FechaAlta),
                        IdUsuarioAlta = 1
                    };

                    var x = db.Add(Cta);
                    var y = db.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return View();
            }

        }
    }
}
