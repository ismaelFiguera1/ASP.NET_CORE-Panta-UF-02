using Cistell_de_la_compra.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace Cistell_de_la_compra.Data
{
    public class Usuaris
    {
        // Es cre una llista estatica _usuaris

        public static readonly List<Usuari> _usuaris = [];

        // Com que es static sol s'executa la primera vegada, i ninguna mes. Sol s'afegeixen una vegada i ja queden per tots

		static Usuaris()
        {
            _usuaris.Add(new Usuari("12345", "joan23@gmail.com", false, false, new DateTime(2025, 1, 12, 16, 23, 45)));
            _usuaris.Add(new Usuari("23456", "maria@gmail.com", false, false, new DateTime(2025, 1, 1, 23, 21, 5)));
            _usuaris.Add(new Usuari("34567", "carme17@gmail.com", false, false, new DateTime(2025, 2, 11, 20, 00, 23)));
            _usuaris.Add(new Usuari("45678", "super@gmail.com", true, false, new DateTime(2024, 1, 1, 0, 0, 0)));
        }

        public static Dictionary<string, int> numeroIntents { get; set; } = new Dictionary<string, int>
        {
            {"joan23@gmail.com", 0 },
            {"maria@gmail.com", 0 },
            {"carme17@gmail.com", 0 },
            {"super@gmail.com", 0 }
        };
    }
}
