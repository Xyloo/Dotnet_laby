using Lab8.Models;

namespace Lab8.Data
{
    public interface IFoxesRepository
    {
        void Add(Fox f);
        Fox? Get(int id);
        IEnumerable<Fox> GetAll();
        void Update(int id, Fox f);
        Fox? IncrementLoves(int id);
        Fox? IncrementHates(int id);
    }
}
