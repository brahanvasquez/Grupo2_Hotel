using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Usuario
    {
        [Required(ErrorMessage = "El codigo es obligatorio")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La clave es obligatoria")]
        public string Clave { get; set; }
        public string? Correo { get; set; }
        [Required(ErrorMessage = "El Rol es obligatorio")]
        public string Rol { get; set; }
        public bool EstaActivo { get; set; }
    }
}
