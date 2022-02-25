using System;
using System.Collections.Generic;

namespace SeguridadCiudadana.Domain.Dtos
{        
        public partial class EstacionCreateRequest
    {
        public int idestacion {get; set;}
        public string? Nombreestacion { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Colonia { get; set; }
        public string Calle { get; set; }
        public string Cruzamientos { get; set; }
        
    }
        
    
}