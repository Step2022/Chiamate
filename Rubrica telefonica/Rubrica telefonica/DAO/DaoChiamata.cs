using Rubrica_telefonica.Database;

namespace Rubrica_telefonica.DAO
{
    public class DaoChiamata
    {
        private readonly CorsoRoma2022Context _context;
        private readonly DaoNumero daoNum;

        public DaoChiamata(CorsoRoma2022Context context)
        {
            _context = context;
        }
        public int StartChiamata(int idChiamante, string numeroRicevente)
        {
            int idRicevente = daoNum.GetNumeroDaNumeroTelefono(numeroRicevente).IdNumero;
            Chiamatum chiam = new Chiamatum();
            chiam.IdChiamante = idChiamante;
            chiam.IdRicevente = idRicevente;
            chiam.InizioChiamata = DateTime.Now;
            _context.Chiamata.Add(chiam);
            _context.SaveChanges();
            return chiam.IdChiamata;
        }
        public bool EndChiamata(int idChiamata)
        {
            try
            {
                Chiamatum chia = _context.Chiamata.First(i => i.IdChiamata == idChiamata);
                chia.FineChiamata = DateTime.Now;
                _context.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public TimeSpan? GetDurata(Chiamatum chiamata)
        {
            TimeSpan? Durata;

            Durata = chiamata.InizioChiamata - chiamata.FineChiamata;
            return Durata;

        }
    }
}
