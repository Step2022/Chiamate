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
                if (contatto != null)//implementare logica per la sicurezza e impedire all utente alcuene cose 
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
            return _context.Contattos.FirstOrDefault(x => x.IdContatto == idContatto && x.IdPropietario == idPropietario);
        }
        public List<Contatto> GetContatti(int idNumero)
        {
            return _context.Contattos.Where(x => x.IdPropietario == idNumero).Select(x => new Contatto()
            {
                Alias = x.Alias,
                Cognome = x.Cognome,
                Nome = x.Nome,
                Email = x.Email,
                IdCellulare = x.IdCellulare,
                IdContatto = x.IdContatto,
                IdPropietario = x.IdPropietario,
                IdTelefonoFisso = x.IdTelefonoFisso,
                Img = x.Img
                

            }).ToList();
        }
        public bool EditContatto(Contatto contatto, string cellulare)
        {
            try
            {
                DaoNumero dn = new DaoNumero(_context);
                var numero = dn.CheckNumero(cellulare);

                var c = GetContatto(contatto.IdContatto, contatto.IdPropietario);
                int Idnumero_old = c.IdCellulare;
                c.Nome = contatto.Nome;
                c.Cognome = contatto.Cognome;
                c.Alias = contatto.Cognome;
                c.Email = contatto.Email;
                c.Img = contatto.Img;
                c.IdCellulare = numero.IdNumero;
                //
                dn.RemoveNumero(Idnumero_old);
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
     
        public bool RemoveContatto(int idContatto, int idPropietario)
        {
            try
            {
                _context.Contattos.Remove(GetContatto(idContatto, idPropietario));
                _context.SaveChanges();      
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool checkContatto(int idChiamante, int idRicevente)
        {
            try
            {
                return _context.Contattos.FirstOrDefault(x => x.IdPropietario == idChiamante && x.IdCellulare == idRicevente) != null ? true : false;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return false;

            }
        }

        //scoppiaa
        public Contatto GetContattoInclude(int idContatto, int idPropietario)
        {
           /* var query = _context.Contattos.FirstOrDefault(x => x.IdPropietario == idPropietario && x.IdContatto == idContatto);
          if(  query != null)
            {
                query.NumeroTelefono = _context.Numeros.FirstOrDefault(x => x.IdNumero == query.IdCellulare).NumeroTelefono;


            }
            else { return null; }
            return query;*/
            /*var query = from c in _context.Contattos.ToList()
                        where c.IdContatto == idContatto && c.IdPropietario == idPropietario
                        join n in _context.Numeros.ToList() on
                        c.IdCellulare equals n.IdNumero
                        select new Contatto()
                        {
                            NumeroTelefono = n.NumeroTelefono
                        };
            return query.FirstOrDefault();

            */






           return _context.Contattos.ToList().Where(x => x.IdPropietario == idPropietario && x.IdContatto==idContatto).ToList().Join(_context.Numeros.ToList(),
                                                c => c.IdCellulare,
                                                n => n.IdNumero,
                                                (c, n) => new Contatto()

                                                {
                                                    IdPropietario = c.IdPropietario,
                                                    IdCellulare = c.IdCellulare,
                                                    Email = c.Email,
                                                    Alias = c.Alias,
                                                    Cognome = c.Cognome,
                                                    Nome = c.Nome,
                                                    Img = c.Img,
                                                   // IdTelefonoFisso = c.IdTelefonoFisso,
                                                    IdContatto = c.IdContatto,
                                                    NumeroTelefono=n.NumeroTelefono


                                                }
                  ).FirstOrDefault();
        }
        /*AddContatto(idNumero)
         GetContatto(idContatto)
         GetContatti(idNumero)
         ModificaContatto(idContatto)
         EliminaContatto(idContatto)*/

    }
}
