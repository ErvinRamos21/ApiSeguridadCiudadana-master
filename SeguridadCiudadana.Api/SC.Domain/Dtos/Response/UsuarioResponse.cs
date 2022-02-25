using System;
using SeguridadCiudadana.Domain.Entities;
using System.Collections.Generic;

namespace SeguridadCiudadana.Domain.Dtos
{
    public partial class UsuarioResponse
    {
        public string? NombreCompleto { get; set; }
        public int? Edad { get; set; }
        public string? Direccion { get; set; }

        //public int? idgenero { get; set; }

        

    }
}