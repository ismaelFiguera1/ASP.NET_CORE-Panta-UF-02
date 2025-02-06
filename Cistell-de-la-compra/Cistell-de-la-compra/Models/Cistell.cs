namespace Cistell_de_la_compra.Models
{
    public class Cistell
    {
        /* El cistell tambe sera un llistat de "Producte" pero ho haurem de fer dinamicament en una vista apart ,
            pero tambe es te que enmagatzemar les vegades que es vol aquell producte ex:  
        patata : 6
        x : 0
        a : 2
         */

        public int IdCocacola { get; set; }

        public int IdPatata { get; set; }

        public int IdLejia { get; set; }

        public int Cocacola { get; set; }
        public int Patata { get; set; }
        public int Lejia { get; set; }

    }
}
