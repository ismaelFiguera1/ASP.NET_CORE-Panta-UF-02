using TaskAplication.Models;

namespace TaskAplication.Data
{
    public static class Tasques
    {
        public static List<Tasca> LlistaTasques = new List<Tasca>();

        static Tasques() 
        {
            LlistaTasques.Add(new Tasca("Regar les plantes"));
            LlistaTasques.Add(new Tasca("Escombrar la casa"));
            LlistaTasques.Add(new Tasca("Passegar el gos"));
        }
    }
}
