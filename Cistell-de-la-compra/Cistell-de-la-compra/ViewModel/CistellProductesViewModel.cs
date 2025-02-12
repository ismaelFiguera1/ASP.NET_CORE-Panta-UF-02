using Cistell_de_la_compra.Models;

namespace Cistell_de_la_compra.ViewModel
{
	public class CistellProductesViewModel
	{
		public Cistell cistell { get; set; }

		public List<Producte> products { get; set; }

		public List<Producte> ObtenirProductes()
		{
			return products;
		}

		public Cistell ObtenirCistell()
		{
			return cistell;
		}


	}
}
