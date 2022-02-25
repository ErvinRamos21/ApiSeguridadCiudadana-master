using System;
using System.Collections.Generic;

namespace SeguridadCiudadana.Domain.Entities
{
    public partial class Cargo
    {
        public Cargo()
        {
            Tipousuarios = new HashSet<Tipousuario>();
        }

        public int Idcargo { get; set; }
        public string Nombrcargo { get; set; }

        public virtual ICollection<Tipousuario> Tipousuarios { get; set; }
    }
}
