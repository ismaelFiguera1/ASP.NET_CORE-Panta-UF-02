using System.ComponentModel.DataAnnotations;

namespace TaskAplication.Models
{
    public class Tasca
    {
        [Required (ErrorMessage ="La descripcio es obligatoria")]
        public string Description { get; set; }

        public DateTime CrearModificar { get; set; }

        public bool TascaFeta { get; set; }

        public static int Contador { get; set; } = 0;

        public int Id { get; set; }

        public Tasca(string des)
        {
            this.Description = des;
            this.CrearModificar = DateTime.Now;
            this.TascaFeta = false;
            Contador = Contador + 1;
            this.Id = Contador;
        }

        public Tasca()
        {
            this.CrearModificar = DateTime.Now;
            this.TascaFeta = false;
            Contador = Contador + 1;
            this.Id = Contador;
        }
    }
}
