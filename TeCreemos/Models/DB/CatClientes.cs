using System;
using System.Collections.Generic;

#nullable disable

namespace TeCreemos.Models.DB
{
    public partial class CatClientes
    {
        public CatClientes()
        {
            Cuenta = new HashSet<CuentaCliente>();
        }

        public int IdCliente { get; set; }
        public string Clave { get; set; }
        public string NombreRazonSocial { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Rfc { get; set; }
        public int IdEstatus { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int IdUsuarioAlta { get; set; }
        public string TipoPersona { get; set; }
        public int IdTipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }

        public virtual CatEstatus IdEstatusNavigation { get; set; }
        public virtual Usuario IdUsuarioAltaNavigation { get; set; }
        public virtual ICollection<CuentaCliente> Cuenta { get; set; }
        
    }
}
