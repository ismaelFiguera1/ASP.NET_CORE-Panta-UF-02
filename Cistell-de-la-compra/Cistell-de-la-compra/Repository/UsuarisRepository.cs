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

		public Usuari trobar(string email, string password)
		{
			UsuarisRepository ur = new();
			var llista = ur.ObtenirTotsUsuaris();
            foreach (var item in llista)
            {
                if (item.email == email)
                {
                    if(item.password == password)
					{
						return item;
					}
                }
            }
            
			return null;
		}

	}   
}
