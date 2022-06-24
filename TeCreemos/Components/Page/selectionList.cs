using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using TeCreemos.Models;

namespace TeCreemos.Components.Page
{
    public class selectionList
    {

        public static List<SelectListItem> lstStatus(int? assigned)
        {
            List<GenericListModel> lstEstatus = null;
            using (var db = new Models.DB.TeCreemosDb())
            {
                lstEstatus = (from e in db.Estatuses
                              select new GenericListModel
                              {
                                  id = e.IdEstatus,
                                  nombre = e.Descripcion,
                                  predeterminado = assigned == null ? 1 : Convert.ToInt16(e.IdEstatus == assigned)
                              }).ToList();
            }

            List<SelectListItem> status = lstEstatus.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre.ToString(),
                    Value = d.id.ToString(),
                    Selected = d.predeterminado == 1 ? true : false
                };
            });

            return status;
        }

        public static List<SelectListItem> lstTipocuenta(int? assigned)
        {
            List<GenericListModel> lstTipoCta = null;
            using (var db = new Models.DB.TeCreemosDb())
            {
                lstTipoCta = (from e in db.TipoCuenta
                              select new GenericListModel
                              {
                                  id = e.IdTipoCuenta,
                                  nombre = e.Descripcion,
                                  predeterminado = assigned == null ? 1 : Convert.ToInt16(e.IdTipoCuenta == assigned)
                              }).ToList();
            }

            List<SelectListItem> tipoCuenta = lstTipoCta.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre.ToString(),
                    Value = d.id.ToString(),
                    Selected = d.predeterminado == 1 ? true : false
                };
            });

            return tipoCuenta;
        }

    

        public static List<SelectListItem> lstTipoIdentificacion(int? assigned)
        {
            List<GenericListModel> lstTipoIden = null;
            using (var db = new Models.DB.TeCreemosDb())
            {
                lstTipoIden = (from e in db.TipoIdentificacions
                              select new GenericListModel
                              {
                                  id = e.IdTipoIdentificacion,
                                  nombre = e.Descripcion,
                                  predeterminado = assigned == null ? 1 : Convert.ToInt16(e.IdTipoIdentificacion == assigned)
                              }).ToList();
            }

            List<SelectListItem> tipoIdentificacion = lstTipoIden.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre.ToString(),
                    Value = d.id.ToString(),
                    Selected = d.predeterminado == 1 ? true : false
                };
            });

            return tipoIdentificacion;
        }

        public static List<SelectListItem> lstTipoMovimiento(int? assigned)
        {
            List<GenericListModel> lstTipoMov = null;
            using (var db = new Models.DB.TeCreemosDb())
            {
                lstTipoMov = (from e in db.TipoMovimientos
                               select new GenericListModel
                               {
                                   id = e.IdTipoMovimiento,
                                   nombre = e.Descripcion,
                                   predeterminado = assigned == null ? 1 : Convert.ToInt16(e.IdTipoMovimiento == assigned)
                               }).ToList();
            }

            List<SelectListItem> tipoMovimiento = lstTipoMov.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre.ToString(),
                    Value = d.id.ToString(),
                    Selected = d.predeterminado == 1 ? true : false
                };
            });

            return tipoMovimiento;
        }

        public static List<SelectListItem> lstTipoPersona(int? assigned)
        {
            List<GenericListModel> lstTipoPer = new();
            
            for (int i=1; i<3; i++)
            {
                GenericListModel tipoPe = new GenericListModel();
                tipoPe.id = i;
                tipoPe.nombre = i==1?"Persona Física" : "Persona Moral";
                lstTipoPer.Add(tipoPe);
            }
            

            List<SelectListItem> tipoPersona = lstTipoPer.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre.ToString(),
                    Value = d.id.ToString(),
                    Selected = d.predeterminado == 1 ? true : false
                };
            });

            return tipoPersona;
        }

        public static List<SelectListItem> lstFiltroCta(int? assigned)
        {
            List<GenericListModel> lstFiltro = new();
            for (int i = 1; i < 3; i++)
            {
                GenericListModel tipoFil = new GenericListModel();
                tipoFil.id = i;
                tipoFil.nombre = i == 1 ? "Número de Cuenta" : "Clave de Cliente";
                lstFiltro.Add(tipoFil);
            }

            List<SelectListItem> tipoFiltro = lstFiltro.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre.ToString(),
                    Value = d.id.ToString(),
                    Selected = d.id == assigned ? true : false
                };
            });

            return tipoFiltro;
        }

    }
}
