using Cistell_de_la_compra.Models;

namespace Cistell_de_la_compra.Repository.interfaces
{
    public interface IUsuarisRepository
    {
        bool comprovarCorreu(string email);
        void controlIntents(bool correuCorrecte, string correu);
        void esborrarIntents(Usuari user);
        Dictionary<string, int> obtenirNumeroIntents();
        List<Usuari> ObtenirTotsUsuaris();
        (Usuari, string) trobar(string email, string password);
    }
}