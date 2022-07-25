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



        //INSERT INTO dbo.Numero(NumeroTelefono) VALUES (3349800360)
        public Numero AddNumero(string numDiTelefono)
        {
            Numero num = new Numero();
            try
            {

            num.NumeroTelefono = numDiTelefono;
            _context.Numeros.Add(num);
            
             _context.SaveChanges();
                
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
            return num;
        }



        //SELECT NumeroTelefono FROM dbo.Numero WHERE IdNumero = 1
        public string GetNumero(int idNumero) {

            var numeroDiTelefono = _context.Numeros.FirstOrDefault(x=>x.IdNumero==idNumero);
                //(from singoloNum in _context.Numeros
                //                    where singoloNum.IdNumero == idNumero
                //                    select singoloNum.NumeroTelefono).First();
            return numeroDiTelefono!=null?numeroDiTelefono.NumeroTelefono: null;
        }

        public Numero GetNumeroDaNumeroTelefono(string numeroDiTelefono)
        {

            Numero num = (from singoloNum in _context.Numeros
                                    where singoloNum.NumeroTelefono == numeroDiTelefono
                       select singoloNum).First();
            return num;
        }



        /*
        SELECT * FROM dbo.Numero WHERE NumeroTelefono = 3349800360
		SE È NULL
        INSERT INTO dbo.Numero(NumeroTelefono) VALUES (3349800360)         
         */
        public Numero CheckNumero(string numeroDiTelefono)
        {
            var esiste = _context.Numeros.FirstOrDefault(x=>x.NumeroTelefono==numeroDiTelefono);
            //var esiste = from singoloNum in _context.Numeros
            //             where singoloNum.NumeroTelefono == numeroDiTelefono
            //             select singoloNum;
            if (esiste == null)
            {
                return AddNumero(numeroDiTelefono);
            }
            else
            {
                return GetNumeroDaNumeroTelefono(numeroDiTelefono);
            }  
        }
    }
}
