using System;
using System.Collections.Generic;

#nullable disable

namespace TeCreemos.Models.DB
{
    public partial class CuentaCliente
    {
        public CuentaCliente()
        {
            Movimientos = new HashSet<Movimientos>();
        }

        public int IdCuenta { get; set; }
        public int IdCliente { get; set; }
        public int IdTipoCuenta { get; set; }
        public int IdEstatus { get; set; }
        public string Numero { get; set; }
        public decimal Saldo { get; set; }
        public DateTime FechaAlta { get; set; }
        public int IdUsuarioAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual CatClientes IdClienteNavigation { get; set; }
        public virtual CatEstatus IdEstatusNavigation { get; set; }
        public virtual TipoCuenta IdTipoCuentaNavigation { get; set; }
        public virtual ICollection<Movimientos> Movimientos { get; set; }
    }
}
