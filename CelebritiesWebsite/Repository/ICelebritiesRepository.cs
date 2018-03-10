using System.Collections.Generic;

namespace CelebritiesWebsite.Repository
{
    public interface ICelebritiesRepository
    {
        IEnumerable<Celebrity> GetAll();

        Celebrity Get(int id);

        bool IsExists(int id);

        void Add(Celebrity celebrity);

        void Update(int id, Celebrity celebrity);

        void Remove(int id);
        
    }
}