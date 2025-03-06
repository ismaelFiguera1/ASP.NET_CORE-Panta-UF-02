using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cistell_de_la_compra.Models
{
    public class Cistell
    {

        public List<Producte> Elements { get; set; } = new List<Producte>();

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


        public Producte BuscarElement(string codiProducte)
        {
            foreach (Producte element in Elements)
            {
                if (element.CodiProducte == codiProducte)
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
                Elements.Add(element);
            }
            else
            {
                element.Quantitat += quantitat;
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

        public void ModificarQuantitat(string[] codis, int[] quantitats)
        {
            for(int i = 0; i<codis.Length; i++) 
            {
                string codi = codis[i];
                var element = BuscarElement(codi);
                if (element != null)
                {
                    element.Quantitat = quantitats[i];
                }
                
            }

        }

    }
}
