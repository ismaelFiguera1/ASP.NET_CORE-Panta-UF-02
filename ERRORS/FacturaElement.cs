using System.ComponentModel.DataAnnotations;

namespace Cistell_de_la_compra.Models
{
    public class FacturaElement
    {
        public string CodiProducte { get; set; }

        public int Quantitat { get; set; }

        public string Nom { get; set; }

        public double Preu { get; set; }


        public double PreuTotalElement { get; set; }
    }
}
