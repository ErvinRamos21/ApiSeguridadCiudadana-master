using System;
using System.Collections.Generic;

namespace SeguridadCiudadana.Domain.Entities
{
    public partial class Categoriapeligro
    {
        public Categoriapeligro()
        {
            Direccionesseguras = new HashSet<Direccionessegura>();
        }

        public int Idpeligro { get; set; }
        public string Tipopeligro { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Direccionessegura> Direccionesseguras { get; set; }
    }
}
