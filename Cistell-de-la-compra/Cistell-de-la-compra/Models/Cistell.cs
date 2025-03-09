using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Cistell_de_la_compra.Repository;
using Cistell_de_la_compra.ViewModel;

namespace Cistell_de_la_compra.Models
{
    public class Cistell
    {
        public double PreuTotalCistell { get; set; }
        public List<ProducteCistell> Elements { get; set; } = new List<ProducteCistell>();

        // No ho faig estatic perqu cada usuari te que tindrer la seva cesta, si ho faig tots els usuaris farien servir la mateixa cesta i hi haria error de logica


        public static Cistell CrearCistell()
        {
            return new Cistell();
        }

        public static Cistell ObtenirCistell(ISession session)
        {
            string clauSessio = "Cistell";

            string cistellJSON = session.GetString(clauSessio);

            if (string.IsNullOrEmpty(cistellJSON))
            {
                return null;
            }
            else
            {
                return JsonSerializer.Deserialize<Cistell>(cistellJSON);

                // deserialitza la cadena json i ho convirteia a un objecte cistell,
                // retorna el cistell
            }
        }


        public ProducteCistell BuscarElement(string codiProducte)
        {
            foreach (ProducteCistell element in Elements)
            {
                if (element.product.CodiProducte == codiProducte)
                {
                    return element;
                }
            }
            return null;
        }


        public void AfegirElement(string codi, int quantitat)
        {
            var element = BuscarElement(codi);

            if (element == null)
            {
                // Tenim que agafar el codi i buscarlo a la llista de productes,
                // llavors crear un producte cistell i insertar el producte cistell a la llista
                ProductesRepository Productes = new();
                var llistaProductes = Productes.ObtenirProductes();
                foreach (var item in llistaProductes)
                {
                    if(item.CodiProducte == codi)
                    {
                        ProducteCistell pc = new();
                        pc.product = item;
                        pc.Quantitat = quantitat;
                        pc.preuTotalProducteCistell = (pc.product.Preu * pc.Quantitat);

                        Elements.Add(pc);
                    }
                }
            }
            else
            {
                element.Quantitat += quantitat;
                element.preuTotalProducteCistell = element.product.Preu * element.Quantitat;
            }
        }

        public void EliminarElement(string codi)
        {
            var element = BuscarElement(codi);
            if(element!=null)
            {
                Elements.Remove(element);
            }
        }

        public void ModificarCistell(string[] codis, int[] quantitats)
        {
            int posicio = 0;
            double preu = 0;
            foreach (var item in codis)
            {
                
                foreach (var item1 in Elements)
                {
                    if (item == item1.product.CodiProducte)
                    {
                        item1.Quantitat = quantitats[posicio];
                        item1.preuTotalProducteCistell = item1.Quantitat * item1.product.Preu;
                        preu += item1.preuTotalProducteCistell;
                    }
                }
                posicio++;
            }


            PreuTotalCistell = preu;
        }

    }
}
