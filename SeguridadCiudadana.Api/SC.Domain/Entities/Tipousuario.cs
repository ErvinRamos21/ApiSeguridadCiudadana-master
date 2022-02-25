using System;
using System.Collections.Generic;

namespace SeguridadCiudadana.Domain.Entities
{
    public partial class Tipousuario
    {
        public Tipousuario()
        {
            Policia = new HashSet<Policia>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Idtipousuario { get; set; }
        public int? Idcargo { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }

        public virtual Cargo IdcargoNavigation { get; set; }
        public virtual ICollection<Policia> Policia { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
