using Cistell_de_la_compra.Models;
using Microsoft.AspNetCore.Mvc;

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




    }
}