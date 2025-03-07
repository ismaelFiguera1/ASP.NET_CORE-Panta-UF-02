/*using Cistell_de_la_compra.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Cistell_de_la_compra.ViewModel
{
    public class FacturaViewModel
    {
        public List<FacturaElement> Elements { get; set; } = new List<FacturaElement>();

        public double preuTotal;

        public void AfegirElement(ElementCistell ec, Producte ep)
        {
            var preuTotalUnitat = ec.Quantitat * ep.Preu;
            Elements.Add(new FacturaElement
            {
                CodiProducte = ec.CodiProducte,
                Quantitat = ec.Quantitat,
                Nom = ep.Nom,
                Preu=ep.Preu,
                PreuTotalElement=preuTotalUnitat,
            });
        }

        public void CalcularTotal ()
        {
            preuTotal = 0;

            foreach (var item in Elements)
            {
                preuTotal += item.PreuTotalElement;
            }
        }
    }
}
*/