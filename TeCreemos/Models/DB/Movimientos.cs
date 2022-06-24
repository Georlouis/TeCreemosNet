using System;
using System.Collections.Generic;

#nullable disable

namespace TeCreemos.Models.DB
{
    public partial class Movimientos
    {
        public int IdMovimiento { get; set; }
        public int IdTipoMovimiento { get; set; }
        public int IdCuenta { get; set; }
        public string Referencia { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public DateTime FechaAlta { get; set; }
        public int IdUsuarioAlta { get; set; }
        public decimal Importe { get; set; }
        public decimal Cargo { get; set; }
        public decimal Abono { get; set; }

        public virtual CuentaCliente IdCuentaNavigation { get; set; }
        public virtual TipoMovimiento IdTipoMovimientoNavigation { get; set; }
    }
}
