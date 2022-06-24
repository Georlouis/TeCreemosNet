using System;
using System.Collections.Generic;

#nullable disable

namespace TeCreemos.Models.DB
{
    public partial class TipoMovimiento
    {
        public TipoMovimiento()
        {
            Movimientos = new HashSet<Movimientos>();
        }

        public int IdTipoMovimiento { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public string Signo { get; set; }
        public string CargoAbono { get; set; }
        public DateTime FechaAlta { get; set; }
        public int IdUsuarioAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int IdEstatus { get; set; }

        public virtual CatEstatus IdEstatusNavigation { get; set; }
        public virtual Usuario IdUsuarioAltaNavigation { get; set; }
        public virtual ICollection<Movimientos> Movimientos { get; set; }
    }
}
