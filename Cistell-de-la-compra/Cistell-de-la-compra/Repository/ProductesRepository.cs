using Cistell_de_la_compra.Models;
using Cistell_de_la_compra.Data;

namespace Cistell_de_la_compra.Repository
{
    public class ProductesRepository
    {


        public List<Producte> ObtenirProductes()
        {
            return Productes.LlistaProductes;
        }

        public async Task<(bool, string)> AfegirProducte(Producte nouProducte)
        {
            ProductesRepository productsRepository = new();

            var LlistaProductes = productsRepository.ObtenirProductes();

            if (nouProducte == null)
            {

                return (false, "El producte no pot ser null");
            }

            if (string.IsNullOrWhiteSpace(nouProducte.Nom))
            {

                return (false, "El nom del producte es obligatori");
            }

            if (string.IsNullOrWhiteSpace(nouProducte.CodiProducte))
            {
                return (false, "El codi del producte es obligatori");
            }

            if (nouProducte.Preu <= 0)
            {

                return (false, "El preu te que ser mes gran que 0");
            }

            if (LlistaProductes.Any(producte => producte.CodiProducte == nouProducte.CodiProducte))
            {

                return (false, "El codi del producte no pot ser repetit");
            }

            if (nouProducte.ImatgeFile != null)
            {
                var carpetaImatges = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imatges");
                var nomArxiu = Path.GetFileName(nouProducte.ImatgeFile.FileName);
                var rutaCompleta = Path.Combine(carpetaImatges, nomArxiu);

                using (var stream = new FileStream(rutaCompleta, FileMode.Create))
                {
                    await nouProducte.ImatgeFile.CopyToAsync(stream);
                }
                nouProducte.Imatge = "/imatges/" + nomArxiu;
            }
            LlistaProductes.Add(nouProducte);

            return (true, "Producte afegit correctament");
        }
    }
}
