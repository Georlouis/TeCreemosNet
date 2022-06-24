using System;
using System.Collections.Generic;

#nullable disable

namespace TeCreemos.Models.DB
{
    public partial class TipoCuenta
    {
        public TipoCuenta()
        {
            Cuenta = new HashSet<CuentaCliente>();
        }

        public int IdTipoCuenta { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaAlta { get; set; }
        public int IdUsuarioAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int IdEstatus { get; set; }

        public virtual Usuario IdUsuarioAltaNavigation { get; set; }
        public virtual ICollection<CuentaCliente> Cuenta { get; set; }
    }
}
