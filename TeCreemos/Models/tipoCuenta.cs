using TeCreemos.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeCreemos.Models
{

    public class tipoCuenta
    {
        public int id { get; set; }
        public string clave { get; set; }
        public string descripcion { get; set; }


        public static string GetTipoCtaDesc(int IdTipoCta)
        {

            using (var db = new Models.DB.TeCreemosDb())
            {
                var tipoCuenta = db.TipoCuenta.Where(t => t.IdTipoCuenta == IdTipoCta);
                if (tipoCuenta.Any())
                {
                    return tipoCuenta.First().Descripcion;
                }
                else
                {
                    return "";
                }

            }
        }
    }
}
