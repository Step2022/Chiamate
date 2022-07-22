using Rubrica_telefonica.Database;

namespace Rubrica_telefonica.DAO
{
    public class DaoContatto
    {

        private readonly CorsoRoma2022Context _context;

        public DaoContatto(CorsoRoma2022Context context)
        {
            _context = context;
        }
    }
}
