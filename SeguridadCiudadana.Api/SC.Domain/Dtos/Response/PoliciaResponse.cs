using System;
using SeguridadCiudadana.Domain.Entities;
using System.Collections.Generic;

namespace SeguridadCiudadana.Domain.Dtos
{
    public partial class PoliciaResponse
    {
         public int Idpolicias { get; set; }
        public string? NombreCompleto { get; set; }
        public int? Edad { get; set; }
        public int? Numeroplaca { get; set; }
        public string? Tipoderango { get; set; }
        public string? Nombreestacion{ get; set; }
        public string? Direccion { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }      
        public int? Idrango { get; set; }
        public int? Idestacion { get; set; }
        //public int? Idcargo { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        //public int? idgenero { get; set; }

        

    }
}