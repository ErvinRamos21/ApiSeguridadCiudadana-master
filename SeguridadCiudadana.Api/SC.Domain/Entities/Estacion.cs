using System;
using System.Collections.Generic;

namespace SeguridadCiudadana.Domain.Entities
{
    public partial class Estacion
    {
        public Estacion()
        {
            Policia = new HashSet<Policia>();
        }

        public int Idestacion { get; set; }
        public string? Nombreestacion { get; set; }
        public int? Iddireccion { get; set; }

        public virtual Direccione IddireccionNavigation { get; set; }
        public virtual ICollection<Policia> Policia { get; set; }
    }
}
