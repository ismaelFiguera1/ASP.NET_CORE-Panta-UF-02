using TaskAplication.Models;

namespace TaskAplication.Repository.Interfaces
{
    public interface ITasquesRepository
    {
        List<Tasca> getTasques();
        bool deleteTasques(int id);
        bool postTasques(Tasca tasca);
    }
}