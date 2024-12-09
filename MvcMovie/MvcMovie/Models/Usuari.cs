using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MvcMovie.Models 
{
    public class Usuari : IValidatableObject
    {
        public string nom { get; set; }

/*
        public void test() 
        { 
            nom = "pepe"; 
            Console.WriteLine(nom);
        }
*/
        public int edat { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
