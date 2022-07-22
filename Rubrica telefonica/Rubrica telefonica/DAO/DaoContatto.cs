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
        public bool AddContatto(Contatto contatto)
        {
            try
            {
                if (contatto != null)
                {

                    _context.Contattos.Add(contatto);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;

            }

        }

        public Contatto GetContatto(int idContatto, int idPropietario)
        {
           return _context.Contattos.FirstOrDefault(x => x.IdContatto == idContatto && x.IdPropietario==idPropietario);
        }
        public List<Contatto> GetContatti(int idNumero)
        {
            return _context.Contattos.Where(x => x.IdPropietario == idNumero).ToList();
        }

       public bool EditContatto(Contatto contatto)
        {
            try{
            var c= GetContatto(contatto.IdContatto, contatto.IdPropietario);
                c.Nome = contatto.Nome;
                c.Cognome = contatto.Cognome;
                c.Alias = contatto.Cognome;
                c.Email = contatto.Email;
                c.Img = contatto.Img;
                _context.SaveChanges();
                return true;

            }catch (Exception ex)
            {
                return false;
            }
        }
      
        public bool RemoveContatto(int idContatto, int idPropietario)
        {
            try
            {
                _context.Contattos.Remove(GetContatto(idContatto,idPropietario));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



           /*AddContatto(idNumero)
            GetContatto(idContatto)
            GetContatti(idNumero)
            ModificaContatto(idContatto)
            EliminaContatto(idContatto)*/

    }
}
