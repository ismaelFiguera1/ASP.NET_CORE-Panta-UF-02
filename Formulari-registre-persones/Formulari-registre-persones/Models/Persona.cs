using System.ComponentModel.DataAnnotations;

namespace Formulari_registre_persones.Models
{
    public class Persona
    {
        [Required(ErrorMessage = "El nom no pot estar en blanc")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nom te que tindrer entre 3 i 50 caracters")]
        public string Nom {  get; set; }

        [Required(ErrorMessage = "El cognom no pot estar en blanc")]
        public string Cognoms { get; set; }

        [Required(ErrorMessage = "El e-mail no pot estar en blanc")]
        public string Email {  get; set; }

        [Required(ErrorMessage = "La data de naixement no pot estar en blanc")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Naixement")]
        public DateOnly DataNaixement { get; set; }  
    }

    public class RetornPersona
    {
        public Persona LaPersona { get; set; }
    }

}
