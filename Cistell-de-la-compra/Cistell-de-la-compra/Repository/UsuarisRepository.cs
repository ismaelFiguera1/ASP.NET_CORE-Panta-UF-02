using Cistell_de_la_compra.Data;
using Cistell_de_la_compra.Models;

namespace Cistell_de_la_compra.Repository
{
    public class UsuarisRepository
    {

        public bool Existeix(string email)
        {
            foreach (Usuari u in Usuaris._usuaris)
            {
                if (u.email == email) return true;
            }
            return false;
        }

        public bool CheckUsuari(string email, string password)
        {
            foreach (Usuari u in Usuaris._usuaris)
            {
                if (u.email == email && u.password == password) return true;
            }
            return false;
        }

    }   
}
