using System;
using System.Linq;

namespace TeCreemos.Models
{
    public class cuenta
    {
        public int id {get; set;}
        public int idCliente {get; set;}
        public string claveCliente { get; set; }
        public int idTipoCuenta {get; set;}
        public string tipoCuenta { get; set; }
        public int idEstatus { get; set; }
        public string estatus { get; set; }
        public string numero { get; set; }
        public decimal saldo{ get; set; }
        public DateTime fechaAlta{ get; set; }
        public int idUsuarioAlta{ get; set; }
        public DateTime FechaModificacion{ get; set; }

        public void GetCuentaData(int id)
        {
            using (var db = new Models.DB.TeCreemosDb())
            {
                var cta = db.Cuenta.Where(c => c.IdCuenta == id);
                if (cta.Any())
                {
                    
                    this.id = cta.First().IdCuenta;
                    this.numero = cta.First().Numero;
                    this.idTipoCuenta = cta.First().IdTipoCuenta;
                    this.saldo = cta.First().Saldo;
                    this.idEstatus = cta.First().IdEstatus;
                    
                }


            }
        }

    }
}
