using System.ComponentModel.DataAnnotations;

namespace Alumnes.Models
{
    public class Alumne
    {
        [Required(ErrorMessage = "El nom no pot estar en blanc")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "El nom no pot tindrer mes de 30 caracters i no pot estar buit")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "El cognom no pot estar en blanc")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "El cognom no pot tindrer mes de 30 caracters i no pot estar buit")]
        public string Cognoms { get; set; }

        [Required(ErrorMessage = "La edat no pot estar en blanc")]
        [Range(1, 100, ErrorMessage = "L'edat ha de ser mes petita de 100 pero mes gran que 1")]
        public int Edat { get; set; }

        [Required(ErrorMessage = "El correu electronic no pot estar en blanc")]
        [EmailAddress(ErrorMessage = "L'email no és vàlid")]
        public string Email { get; set; }

        
        [DataType(DataType.Date)]
        public DateOnly DataNaixement { get; set; }
    }
}
