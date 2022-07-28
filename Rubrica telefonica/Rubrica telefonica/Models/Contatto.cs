using System.ComponentModel.DataAnnotations.Schema;

namespace Rubrica_telefonica.Database
{
    public partial class Contatto
    {
        [NotMapped]
       public string? NumeroTelefono { get; set; }
    }
}
