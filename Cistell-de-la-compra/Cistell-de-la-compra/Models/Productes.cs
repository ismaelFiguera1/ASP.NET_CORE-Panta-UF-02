namespace Cistell_de_la_compra.Models
{
    public class Productes
    {
        public List<Producte> llistaProductes { get;} = new List<Producte>();  /* Inicialitzem la llista de productes */

        /* Ara fiquarem els productes manualment a la llista de productes */

        public Productes()
        {
            llistaProductes.Add(new Producte { CodiProducte = "001", Nom = "Patata", Preu = 0.23 });
            llistaProductes.Add(new Producte { CodiProducte = "002", Nom = "Coca-cola", Preu = 1.20 });
            llistaProductes.Add(new Producte { CodiProducte = "003", Nom = "Lejia", Preu = 2.67 });
        }

        /* Es crea una instanca de si mateix i li afegeix els productes a la variable "llistaProductes" */


    }
}

