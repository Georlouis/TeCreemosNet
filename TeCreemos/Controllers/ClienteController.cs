using TeCreemos.Components.Page;
using TeCreemos.Models;
using TeCreemos.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TeCreemos.Controllers
{
    public class ClienteController : Controller
    {
        /// <summary>
        /// Recupera lista de clientes
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            
            //creamos una lista de modelo cliente
            List<cliente> lst = new List<cliente>();
            //Recupero valores
            
            using (var db = new Models.DB.TeCreemosDb())
            {
                lst = (from c in db.Clientes
                       select new cliente
                       {
                           id = c.IdCliente,
                           clave = c.Clave,
                           nombre = c.NombreRazonSocial,
                           apellidos = $"{c.ApellidoPaterno} {c.ApellidoMaterno}",
                           rfc = c.Rfc,
                           idEstatus = c.IdEstatus,
                           estatus = estatus.GetStatusDesc(c.IdEstatus),
                           tipoPersona = c.TipoPersona == "PF" ? "Persona física" : "Persona Moral",
                           idTipoIdentificacion = c.IdTipoIdentificacion,
                           tipoIdentificacion = tipoIdentificacion.GetDescTipoIdentificacion(c.IdTipoIdentificacion),
                           numeroIdentificacion = c.NumeroIdentificacion
            }).ToList();
                // se crea una lista de todo lo que exista en clienta
            }
            //crea una lista con el modelo lst
            return View(lst);
        }
        
        //Vista para abror en forma vertical
        public ActionResult Details(int id)
        {
            return View();
        }
        /// <summary>
        /// carga la página para captura GET ClienteController/Create
        /// </summary>
        /// <returns></returns>
        //Se utiliza para cargar la pagina para captura
        public ActionResult Create()
        {
            ViewBag.estatus = selectionList.lstStatus(0);
            ViewBag.tipoPersona = selectionList.lstTipoPersona(null);
            ViewBag.tipoIdentificacion = selectionList.lstTipoIdentificacion(null);

            return View();
        }

        /// <summary>
        /// Colección de los campos de la página | Se asignan valores para enviar a base de datos
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection )
        {
            try
            {
                //Se realiza conexion a base de datos
                using (var db = new Models.DB.TeCreemosDb())
                {
                    //se cra variable lista para recibir información
                    var Cte = new CatClientes()
                    {
                        //De la colección se asignan los valores
                        Clave = collection["Clave"].ToString() ,
                        NombreRazonSocial = collection["NombreRazonSocial"].ToString(),
                        ApellidoPaterno = collection["ApellidoPaterno"].ToString(),
                        ApellidoMaterno = collection["ApellidoMaterno"].ToString(),
                        Rfc=collection["Rfc"].ToString(),
                        
                        IdEstatus = int.Parse( collection["IdEstatus"]),
                        FechaAlta = DateTime.Parse(collection["FechaAlta"]),
                        IdUsuarioAlta = 1,
                        TipoPersona = int.Parse(collection["TipoPersona"]) == 1?"PF":"PM",
                        IdTipoIdentificacion = int.Parse(collection["IdTipoIdentificacion"]),
                        NumeroIdentificacion = collection["NumeroIdentificacion"].ToString(),

                    };

                  var x =  db.Add(Cte);//Se agrega a base de datos
                  var y=  db.SaveChanges(); // Se salva hasta este puento en la base de datos
                }

                return RedirectToAction(nameof(Index)); //una vez que se guarda regresa a listado de clientes
            }
            catch(Exception)
            {
                
                return View(); //se regresa la vista de alta
            }
        }

    }
}
