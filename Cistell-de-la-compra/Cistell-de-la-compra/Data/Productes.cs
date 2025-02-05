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
            new Producte { CodiProducte = "002", Nom = "Coca-cola", Preu = 1.20, Imatge="/imatges/cocacola.webp" },
            new Producte { CodiProducte = "003", Nom = "Lejia", Preu = 2.67, Imatge = "/imatges/Lejia.jpg" }
        };

        /* Aqui retorno la llista, es estatica perque el model productes es static */
        public static List<Producte> ObtenirProductes()
        {
            return LlistaProductes;
        }
    }
}

