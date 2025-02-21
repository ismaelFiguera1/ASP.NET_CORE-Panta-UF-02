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
        public static List<Producte> ObtenirProductes()
        {
            return LlistaProductes;
        }


        public static async  Task<(bool, string)>  AfegirProducte(Producte nouProducte)
		{
            if (nouProducte == null)
            {
                
                return (false, "El producte no pot ser null"); 
            }

            if(string.IsNullOrWhiteSpace(nouProducte.Nom))
            {
              
                return (false, "El nom del producte es obligatori");
            }

            if (string.IsNullOrWhiteSpace(nouProducte.CodiProducte))
            { 
                return (false, "El codi del producte es obligatori");
            }

            if(nouProducte.Preu <=0)
            {
                
                return (false, "El preu te que ser mes gran que 0");
            }

            if(LlistaProductes.Any(producte => producte.CodiProducte == nouProducte.CodiProducte))
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
                nouProducte.Imatge="/imatges/" + nomArxiu;
            }
            LlistaProductes.Add(nouProducte);
            
            return (true, "Producte afegit correctament");
        }
    }
}