using System;
using System.Collections.Generic;

namespace SeguridadCiudadana.Domain.Entities
{
    public partial class Persona
    {
        public Persona()
        {
            Policia = new HashSet<Policia>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Idpersona { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int? Edad { get; set; }

        public virtual ICollection<Policia> Policia { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
