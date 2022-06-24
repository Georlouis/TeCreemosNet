using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeCreemos.Models
{
    public class usuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string claveAcceso { get; set; }
        public string contrasenia { get; set; }
        public int idEstatus { get; set; }

    }
}
