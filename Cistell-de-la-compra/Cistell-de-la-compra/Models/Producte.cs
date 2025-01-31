using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Cistell_de_la_compra.Models
{
    public class Producte
    {

        [Required(ErrorMessage = "El codi del producte no pot estar en blanc")]
        public string CodiProducte { get; set; }

        [Required(ErrorMessage = "El nom no pot estar en blanc")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "El preu del producte no pot estar en blanc")]
        public double Preu {  get; set; }

        [Required(ErrorMessage = "La imatge del producte no pot estar en blanc")]
        public string Imatge { get; set; }


    }
}


