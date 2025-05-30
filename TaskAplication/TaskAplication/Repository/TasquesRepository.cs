using TaskAplication.Data;
using TaskAplication.Models;
using TaskAplication.Repository.Interfaces;

namespace TaskAplication.Repository
{
    public class TasquesRepository : ITasquesRepository
    {
        public List<Tasca> getTasques()
        {
            return Tasques.LlistaTasques;
        }

        public bool deleteTasques(int id)
        {
            foreach (var item in Tasques.LlistaTasques)
            {
                if (item.Id == id)
                {
                    Tasques.LlistaTasques.Remove(item);
                    return true;
                }
            }
            return false;
        }

        public bool postTasques(Tasca tasca)
        {
            foreach (var item in Tasques.LlistaTasques)
            {
                if (tasca.Id == item.Id)
                {
                    return false;
                }
            }
            Tasques.LlistaTasques.Add(tasca);
            return true;
        }
    }
}
