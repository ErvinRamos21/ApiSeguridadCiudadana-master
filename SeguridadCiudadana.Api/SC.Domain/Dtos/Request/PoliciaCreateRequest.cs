using System;
using System.Collections.Generic;

namespace SeguridadCiudadana.Domain.Dtos
{
    public partial class PoliciaCreateRequest
    {
        public int Idpolicias {get; set;}
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public int? Edad { get; set; }
        public int? Numeroplaca { get; set; }
        public int? Idrango { get; set; }
        public int? Idestacion { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }

        

    }
}
