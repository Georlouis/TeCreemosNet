using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeCreemos.Models
{
    public class movimiento
    {
        public int id {get;set;}
        public int idTipoMovimiento{get;set;}
        public int idCuenta {get;set;}
        public string referencia {get;set;}
        public DateTime fechaMovimiento {get;set;}
        public DateTime fechaAlta {get;set;}
        public decimal importe {get;set;}
        public decimal cargo {get;set;}
        public decimal abono {get;set;}
        public int idUsuarioAlta {get;set;}
    }
}
