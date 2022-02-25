using System;
using System.Collections.Generic;
using SeguridadCiudadana.Domain.Dtos;

namespace SeguridadCiudadana.Domain.Entities
{
    public partial class Policia
    {
        public int Idpolicias { get; set; }
        public int? Idpersona { get; set; }
        public int? Numeroplaca { get; set; }
        public int? Idrango { get; set; }
        public int? Idestacion { get; set; }
        public int? Idtipousuario { get; set; }
        public int? Idgenero { get; set; }
        public int? Iddireccion { get; set; }

        public virtual Direccione IddireccionNavigation { get; set; }
        public virtual Estacion IdestacionNavigation { get; set; }
        public virtual Genero IdgeneroNavigation { get; set; }
        public virtual Persona IdpersonaNavigation { get; set; }
        public virtual Rango IdrangoNavigation { get; set; }
        public virtual Tipousuario IdtipousuarioNavigation { get; set; }

    }
}
