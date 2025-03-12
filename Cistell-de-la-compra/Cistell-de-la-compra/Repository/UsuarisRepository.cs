using Cistell_de_la_compra.Data;
using Cistell_de_la_compra.Models;

namespace Cistell_de_la_compra.Repository
{
    public class UsuarisRepository
    {


        

        public List<Usuari> ObtenirTotsUsuaris()
		{
			return Usuaris._usuaris;
		}

        public Dictionary<string, int> obtenirNumeroIntents()
        {
            return Usuaris.numeroIntents;
        }

		public Usuari trobar(string email, string password)
		{
			UsuarisRepository ur = new();
			var llista = ur.ObtenirTotsUsuaris();
            foreach (var item in llista)
            {
                if (item.email == email)
                {
                    Dictionary<string, int> llistaIntents = ur.obtenirNumeroIntents();
                    foreach (var item1 in llistaIntents)
                    {
                        if (item1.Value >= 3)
                        {
                            return (null, "ERROR    USUARI    BLOQUEJAT");
                        }
                    }
                    if (item.password == password)
					{
						return item;
					}
                }
            }
            
			return null;
		}

        public bool comprovarCorreu(string email)
        {
            UsuarisRepository ur = new();

            var llistaUsuaris = ur.ObtenirTotsUsuaris();

            foreach (var item in llistaUsuaris)
            {
                if(item.email == email)
                {
                    return true;
                }
            }


            return false;
        }

        public bool controlIntents(bool correuCorrecte, string correu)
        {
            if (correuCorrecte)
            {
                UsuarisRepository ur = new UsuarisRepository();
                Dictionary<string, int> diccionari = ur.obtenirNumeroIntents();
                foreach (var item in diccionari)
                {
                    if (item.Key == correu)
                    {
                        diccionari[item.Key]++;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
                
        }
    }   
}
