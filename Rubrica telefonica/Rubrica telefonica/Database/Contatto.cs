using System;
using System.Collections.Generic;

namespace Rubrica_telefonica.Database
{
    public partial class Contatto
    {
        public int IdContatto { get; set; }
        public string Nome { get; set; } = null!;
        public string Cognome { get; set; } = null!;
        public int IdCellulare { get; set; }
        public decimal? IdTelefonoFisso { get; set; }
        public string? Email { get; set; }
        public string? Alias { get; set; }
        public string? Img { get; set; }
        public int IdPropietario { get; set; }


        public virtual Numero? IdPropietarioNavigation { get; set; }
    }
}
