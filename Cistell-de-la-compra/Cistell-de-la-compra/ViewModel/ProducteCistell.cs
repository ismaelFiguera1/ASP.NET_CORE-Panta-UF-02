using System.ComponentModel.DataAnnotations;
using Cistell_de_la_compra.Models;

namespace Cistell_de_la_compra.ViewModel
{
    public class ProducteCistell
    {
       public Producte product { get; set; }
        public int Quantitat { get; set; }
         public double preuTotalProducteCistell { get; set; }
    }
}
