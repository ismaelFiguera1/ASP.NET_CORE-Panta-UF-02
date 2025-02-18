using Cistell_de_la_compra.Models;

namespace Cistell_de_la_compra.Data
{
    public static class Productes
    {
        /* Creem una llista estatica perque si no ho fem i l'instanciem, aquella instancia pot ser diferent a una altra.
         i si fem una altra instancia aquells canvis no es guarden */
        public static List<Producte> LlistaProductes { get; } = new List<Producte>
        {
            new Producte { CodiProducte = "001", Nom = "Patata", Preu = 0.23, Imatge="/imatges/patata.jpg" },

        };

        /* Aqui retorno la llista, es estatica perque el model productes es static */
        public static List<Producte> ObtenirProductes()
        {
            return LlistaProductes;
        }


        public static bool AfegirProducte(Producte nouProducte, out string missatge)
        {
            if (nouProducte == null)
            {
                missatge = "El producte no pot ser null";
                return false; 
            }

            if(string.IsNullOrWhiteSpace(nouProducte.Nom))
            {
                missatge = "El nom del producte es obligatori";
                return false;
            }

            if (string.IsNullOrWhiteSpace(nouProducte.CodiProducte))
            {
                missatge = "El codi del producte es obligatori";
                return false;
            }

            if(nouProducte.Preu <=0)
            {
                missatge = "El preu te que ser mes gran que 0";
                return false;
            }

            if(LlistaProductes.Any(producte => producte.CodiProducte == nouProducte.CodiProducte))
            {
                missatge = "El codi del producte no pot ser repetit";
                return false;
            }

            LlistaProductes.Add(nouProducte);
            missatge = "Producte afegit correctament";
            return true;
        }
    }
}

