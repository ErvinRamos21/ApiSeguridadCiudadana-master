using System;
using System.Collections.Generic;

namespace SeguridadCiudadana.Domain.Entities
{
    public partial class Usuario
    {
        public int Idusuario { get; set; }
        public int? Idpersona { get; set; }
        public int? Idtipousuario { get; set; }
        public int? Idgenero { get; set; }
        public int? Iddireccion { get; set; }

        public virtual Direccione IddireccionNavigation { get; set; }
        public virtual Genero IdgeneroNavigation { get; set; }
        public virtual Persona IdpersonaNavigation { get; set; }
        public virtual Tipousuario IdtipousuarioNavigation { get; set; }
    }
}
