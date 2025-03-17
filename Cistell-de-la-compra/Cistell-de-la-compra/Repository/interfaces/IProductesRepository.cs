using Cistell_de_la_compra.Models;

namespace Cistell_de_la_compra.Repository.interfaces
{
    public interface IProductesRepository
    {
        Task<(bool, string)> AfegirProducte(Producte nouProducte);
        List<Producte> ObtenirProductes();
    }
}