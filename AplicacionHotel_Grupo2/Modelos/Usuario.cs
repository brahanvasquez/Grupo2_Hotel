using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Usuario
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public string? Correo { get; set; }
        public string Rol { get; set; }
        public bool EstaActivo { get; set; }
    }
}
