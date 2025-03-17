using Cistell_de_la_compra.Models;
using Cistell_de_la_compra.Data;
using Cistell_de_la_compra.Repository.interfaces;

namespace Cistell_de_la_compra.Repository
{
    public class ProductesRepository : IProductesRepository
	{


		public List<Producte> ObtenirProductes()
		{
			return Productes.LlistaProductes;
		}

		public async Task<(bool, string)> AfegirProducte(Producte nouProducte)
		{
			ProductesRepository productsRepository = new();

			var LlistaProductes = productsRepository.ObtenirProductes();

			//     nouProducte.Nom = "   ";

			if (string.IsNullOrWhiteSpace(nouProducte.Nom))
			{

				return (false, "El nom del producte no pot ser null ni buit ni sol espais");
			}

			if (string.IsNullOrWhiteSpace(nouProducte.CodiProducte))
			{
				return (false, "El codi del producte no pot ser null ni buit ni sol espais");
			}

			if (nouProducte.Preu >= 101)
			{

				return (false, "El preu no pot ser mes gran que 100");
			}



			foreach (var item in LlistaProductes)
			{
				if (item.CodiProducte == nouProducte.CodiProducte)
				{
					return (false, "El codi del producte no pot ser repetit, te que ser individual");
				}
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
			else
			{
				return (false, "falta pujar una imatge");
			}
			nouProducte.ImatgeFile = null;
			LlistaProductes.Add(nouProducte);

			return (true, "Producte afegit correctament");
		}
	}
}
