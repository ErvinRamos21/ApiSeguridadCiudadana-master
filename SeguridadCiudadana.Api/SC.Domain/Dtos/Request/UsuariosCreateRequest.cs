using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeguridadCiudadana.Domain.Dtos
{
    public partial class UsuariosCreateRequest
    {
        public string? NombreCompleto { get; set; }
        public int? Edad { get; set; }
        public string? Direccion { get; set; }
    }
}
