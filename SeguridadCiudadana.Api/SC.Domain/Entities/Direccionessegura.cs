using System;
using System.Collections.Generic;

namespace SeguridadCiudadana.Domain.Entities
{
    public partial class Direccionessegura
    {
        public int Iddireccionsegura { get; set; }
        public int? Latitud { get; set; }
        public int? Longitud { get; set; }
        public int? Idpeligro { get; set; }

        public virtual Categoriapeligro IdpeligroNavigation { get; set; }
    }
}
