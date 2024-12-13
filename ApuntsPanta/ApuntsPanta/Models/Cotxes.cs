using System.ComponentModel.DataAnnotations;

namespace ApuntsPanta.Models
{
    public enum CotxeTipus
    {
        Gasolina,
        Diesel, Hibrid,
        Electric
    }

    public class Cotxes
    {
        [Required (ErrorMessage="La matricula no pot estar en blanc")]

        [Length(7,7, ErrorMessage="Ha de tenir 7 caracters")]
        public string matricula { get; set; }
        public string marca { get; set; }

        [DataType(DataType.Date)]
        [Display(Name="Data de Matriculacio")]
        public DateOnly dataMatriculacio { get; set; }

        [Required]
        public  CotxeTipus Tipus { get; set; }

    }
}
