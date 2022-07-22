using System;
using System.Collections.Generic;

namespace Rubrica_telefonica.Database
{
    public partial class Numero
    {
        public Numero()
        {
            ChiamatumIdChiamanteNavigations = new HashSet<Chiamatum>();
            ChiamatumIdRiceventeNavigations = new HashSet<Chiamatum>();
            Contattos = new HashSet<Contatto>();
        }

        public int IdNumero { get; set; }
        public string NumeroTelefono { get; set; } = null!;

        public virtual ICollection<Chiamatum> ChiamatumIdChiamanteNavigations { get; set; }
        public virtual ICollection<Chiamatum> ChiamatumIdRiceventeNavigations { get; set; }
        public virtual ICollection<Contatto> Contattos { get; set; }
    }
}
