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

        
        public string? Imatge { get; set; }

        [Required(ErrorMessage = "Es obligatori pujar la imatge")]
        public IFormFile? ImatgeFile { get; set; }

        public Producte(){}

        public Producte(string codi, string nom, double preu, string? img=null, IFormFile? imgFile= null){
            CodiProducte=codi;
             Nom=nom; 
             Preu=preu; 
             Imatge=img; 
             ImatgeFile=imgFile;
        }

        public Producte(string codi, string nom, double preu, string? img=null){
            CodiProducte=codi;
             Nom=nom; 
             Preu=preu; 
             Imatge=img; 
        }




    }
}


