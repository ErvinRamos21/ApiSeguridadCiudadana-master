using System;
using System.Collections.Generic;

namespace SeguridadCiudadana.Domain.Entities
{
    public partial class Direccione
    {
        public Direccione()
        {
            Estacions = new HashSet<Estacion>();
            Policia = new HashSet<Policia>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Iddireccion { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Colonia { get; set; }
        public string Calle { get; set; }
        public string Cruzamientos { get; set; }

        public virtual ICollection<Estacion> Estacions { get; set; }
        public virtual ICollection<Policia> Policia { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
