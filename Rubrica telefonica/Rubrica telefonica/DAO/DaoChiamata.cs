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

            };

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

            };

            var minimo = a.Min();

            return minimo;
        }


        public static int CountChiamate(int idChiamante, int idRicevente)
        {
            List<Chiamatum> Chiamate = new List<Chiamatum>();
            using (CorsoRoma2022Context context = new CorsoRoma2022Context())
            {
                Chiamate = (from Chiamata in context.Chiamata
                                  where Chiamata.IdChiamante == idChiamante & Chiamata.IdRicevente == idRicevente ||
                                  Chiamata.IdRicevente == idChiamante & Chiamata.IdChiamante == idRicevente
                                  select Chiamata).ToList();

            }

           int NumeroChiamate = Chiamate.Count();

            return NumeroChiamate;
        }


        public static int GetChiamateTotali(int idNumero)
        {
            List<Chiamatum> Chiamate = new List<Chiamatum>();
            using (CorsoRoma2022Context context = new CorsoRoma2022Context())
            {
                Chiamate = (from Chiamata in context.Chiamata
                            where Chiamata.IdChiamante == idNumero || Chiamata.IdRicevente == idNumero
                            select Chiamata).ToList();

            }

            int NumeroChiamateTotali = Chiamate.Count();

            return NumeroChiamateTotali;
        }



    }
}


