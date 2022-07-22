using System;
using System.Collections.Generic;

namespace Rubrica_telefonica.Database
{
    public partial class Chiamatum
    {
        public int IdChiamata { get; set; }
        public int IdChiamante { get; set; }
        public int IdRicevente { get; set; }
        public DateTime InizioChiamata { get; set; }
        public DateTime? FineChiamata { get; set; }

        public virtual Numero IdChiamanteNavigation { get; set; } = null!;
        public virtual Numero IdRiceventeNavigation { get; set; } = null!;
    }
}
