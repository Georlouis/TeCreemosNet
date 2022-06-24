using System;
using System.Collections.Generic;

#nullable disable

namespace TeCreemos.Models.DB
{
    public partial class CatEstatus
    {
        public CatEstatus()
        {
            Clientes = new HashSet<CatClientes>();
            Cuenta = new HashSet<CuentaCliente>();
            TipoMovimientos = new HashSet<TipoMovimiento>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdEstatus { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public int? IdUsuarioAlta { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual Usuario IdUsuarioAltaNavigation { get; set; }
        public virtual ICollection<CatClientes> Clientes { get; set; }
        public virtual ICollection<CuentaCliente> Cuenta { get; set; }
        public virtual ICollection<TipoMovimiento> TipoMovimientos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
