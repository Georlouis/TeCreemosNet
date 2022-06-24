using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeCreemos.Models
{
    public class tipoMovimiento
    {
        public int id { get; set; }
        public string clave { get; set; }
        public string descripcion { get; set; }
        public string signo { get; set; }
        public string cargoAbono { get; set; }
        public DateTime fechaAlta { get; set; }
        public int idUsuarioAlta { get; set; }
        public int idEstatus { get; set; }
        public string estatus { get; set; }

        public static string GetDescMovimiento(int idTipoMovimiento)
        {
            using (var db = new Models.DB.TeCreemosDb())
            {
                var estatus = db.TipoMovimientos.Where(m => m.IdTipoMovimiento == idTipoMovimiento);
                if (estatus.Any())
                {
                    return estatus.First().Descripcion;
                }
                else
                {
                    return "";
                }

            }
        }

        public void GetTipoMovData(int id)
        {
            using (var db = new Models.DB.TeCreemosDb())
            {
                var Tipo = db.TipoMovimientos.Where(t => t.IdTipoMovimiento== id);
                if (Tipo.Any())
                {
                    
                    this.id = Tipo.First().IdTipoMovimiento;
                    this.clave = Tipo.First().Clave;
                    this.descripcion = Tipo.First().Descripcion;
                    this.signo = Tipo.First().Signo;
                    this.cargoAbono = Tipo.First().CargoAbono;
                    this.idEstatus = Tipo.First().IdEstatus;
                }
            }
        }
    }

}
