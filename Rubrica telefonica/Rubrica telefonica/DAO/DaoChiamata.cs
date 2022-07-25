using Rubrica_telefonica.Database;

namespace Rubrica_telefonica.DAO
{
    public class DaoChiamata
    {
        private readonly CorsoRoma2022Context _context;

        public DaoChiamata(CorsoRoma2022Context context)
        {
            _context = context;
        }
        public Chiamatum StartChiamata(int idChiamante, string numeroRicevente)
        {

            DaoNumero daoNum = new DaoNumero(new CorsoRoma2022Context());
            int idRicevente = daoNum.GetNumeroDaNumeroTelefono(numeroRicevente).IdNumero;
            Chiamatum chiam = new Chiamatum();
            chiam.IdChiamante = idChiamante;
            chiam.IdRicevente = idRicevente;
            chiam.InizioChiamata = DateTime.Now;
            _context.Chiamata.Add(chiam);
            _context.SaveChanges();
            return chiam;
        }
        public Chiamatum EndChiamata(int idChiamata)
        {
            Chiamatum chia = _context.Chiamata.First(i => i.IdChiamata == idChiamata);
            chia.FineChiamata = DateTime.Now;
            _context.SaveChanges();
            return chia;
        }

        public static TimeSpan? GetDurata(Chiamatum chiamata)
        {
            TimeSpan? Durata;

            Durata = chiamata.InizioChiamata - chiamata.FineChiamata;
            return Durata;

        }
        
 

        public static TimeSpan? ChiamataMax(int idNumero)
        {
            List<Chiamatum> chiamata = new List<Chiamatum>();
            using (CorsoRoma2022Context context = new CorsoRoma2022Context())
            {
                chiamata = (from Chiamata in context.Chiamata
                            where Chiamata.IdChiamante == idNumero || Chiamata.IdRicevente == idNumero
                            select Chiamata).ToList();



            }
            List<TimeSpan?> a = new List<TimeSpan?>();

            foreach (var i in chiamata)
            {

                a.Add(DaoChiamata.GetDurata(i));

            }

            var massimo = a.Max();

            return massimo;
        }



        public static TimeSpan? ChiamataMin(int idNumero)
        {
            List<Chiamatum> chiamata = new List<Chiamatum>();
            using (CorsoRoma2022Context context = new CorsoRoma2022Context())
            {
                chiamata = (from Chiamata in context.Chiamata
                            where Chiamata.IdChiamante == idNumero || Chiamata.IdRicevente == idNumero
                            select Chiamata).ToList();



            }
            List<TimeSpan?> a = new List<TimeSpan?>();

            foreach (var i in chiamata)
            {

                a.Add(DaoChiamata.GetDurata(i));

            }

            var minimo = a.Min();

            return minimo;
        }
    }
        }
