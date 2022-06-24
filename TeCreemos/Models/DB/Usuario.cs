using System;
using System.Collections.Generic;

#nullable disable

namespace TeCreemos.Models.DB
{
    public partial class Usuario
    {
        public Usuario()
        {
            Clientes = new HashSet<CatClientes>();
            Estatuses = new HashSet<CatEstatus>();
            TipoCuenta = new HashSet<TipoCuenta>();
            TipoMovimientos = new HashSet<TipoMovimiento>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string ClaveAcceso { get; set; }
        public string Contrasenia { get; set; }
        public int IdEstatus { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual CatEstatus IdEstatusNavigation { get; set; }
        public virtual ICollection<CatClientes> Clientes { get; set; }
        public virtual ICollection<CatEstatus> Estatuses { get; set; }
        public virtual ICollection<TipoCuenta> TipoCuenta { get; set; }
        public virtual ICollection<TipoMovimiento> TipoMovimientos { get; set; }
    }
}
