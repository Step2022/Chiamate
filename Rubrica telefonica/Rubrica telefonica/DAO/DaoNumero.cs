using Rubrica_telefonica.Database;

namespace Rubrica_telefonica.DAO
{
    public class DaoNumero
    {


        private readonly CorsoRoma2022Context _context;

        public DaoNumero(CorsoRoma2022Context context)
        {
            _context = context;
        }
    }
}
