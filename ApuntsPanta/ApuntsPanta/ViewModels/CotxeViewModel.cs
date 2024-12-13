using ApuntsPanta.Models;

namespace ApuntsPanta.ViewModels
{
    public class CotxeViewModel
    {
        public Cotxes ElCotxe { get; set; }

        public List<string> Marques { get; set; } = ["renault", "Seat", "Audi", "Volksbagen"];
    }
}
