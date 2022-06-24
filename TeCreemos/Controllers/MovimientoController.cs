using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

using TeCreemos.Components.Page;
using TeCreemos.Models;
using TeCreemos.Models.DB;

namespace TeCreemos.Controllers
{
    public class MovimientoController : Controller
    {

        /// <summary>
        /// GET: MovimientoController
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index(int id)
        {
            ViewBag.idCuenta = id;
            
                
                
                
                List<movimiento> lst = new List<movimiento>();
                using (var db = new Models.DB.TeCreemosDb())
                {
                    lst = (from c in db.Movimientos
                           select new movimiento
                           {
                               id = c.IdMovimiento,
                               idCuenta = c.IdCuenta,
                               idTipoMovimiento = c.IdTipoMovimiento,
                               referencia = c.Referencia,                               
                               importe = c.Importe,
                               cargo = c.Cargo,
                               abono = c.Abono,
                               fechaMovimiento = c.FechaMovimiento

                           }).ToList();

                    return View(lst);
                }
            
        }
        /// <summary>
        /// GET: MovimientoController/Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// GET: MovimientoController/Create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
            {
            ViewBag.tipoMovimiento = selectionList.lstTipoMovimiento(null);

            return View();
        }
        [HttpGet]
        public ActionResult Create(int idCta)
        {
            ViewBag.tipoMovimiento = selectionList.lstTipoMovimiento(null);
            ViewBag.idCuenta = idCta;

            return View();
        }

        /// <summary>
        /// POST: MovimientoController/Create
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                using (var db = new Models.DB.TeCreemosDb())
                {
                    tipoMovimiento tMov = new tipoMovimiento();
                    tMov.GetTipoMovData(int.Parse(collection["tipoMovimiento"]));
                    cuenta cta = new cuenta();
                    cta.GetCuentaData(int.Parse(collection["IdCuenta"]));

                    var Mov = new Movimientos()
                    {

                        IdTipoMovimiento = int.Parse(collection["tipoMovimiento"]),
                        IdCuenta = int.Parse(collection["IdCuenta"]),
                        Referencia = collection["Referencia"].ToString(),
                        FechaMovimiento = DateTime.Parse(collection["FechaMovimiento"]),
                        FechaAlta = DateTime.Parse(collection["FechaMovimiento"]),
                        Importe = int.Parse(collection["Importe"]),
                        Cargo = tMov.signo == "+" ? 0 : int.Parse(collection["Importe"]),
                        Abono = tMov.signo == "-" ? 0 : int.Parse(collection["Importe"]),
                        IdUsuarioAlta = int.Parse(collection["IdUsuarioAlta"])


                    };

                    var x = db.Add(Mov);
                    var y = db.SaveChanges();

                    var Cta = db.Cuenta.Where(c => c.IdCuenta == cta.id).First(); ;
                    Cta.Saldo = tMov.signo == "+" ? Cta.Saldo + Mov.Importe : Cta.Saldo - Mov.Importe;

                    db.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
