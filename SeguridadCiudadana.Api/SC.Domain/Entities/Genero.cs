using System;
using System.Collections.Generic;

namespace SeguridadCiudadana.Domain.Entities
{
    public partial class Genero
    {
        public Genero()
        {
            Policia = new HashSet<Policia>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Idgenero { get; set; }
        public string Tipigenero { get; set; }

        public virtual ICollection<Policia> Policia { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
