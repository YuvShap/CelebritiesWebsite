using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace CelebritiesWebsite.Repository
{
    public class CelebritiesRepository : ICelebritiesRepository
    {
        private readonly IJsonFileManager _jsonFileManager;

        public CelebritiesRepository(IJsonFileManager jsonFileManager)
        {
            _jsonFileManager = jsonFileManager;
        }

        public IEnumerable<Celebrity> GetAll()
        {
            return GetCelebrities();
        }

        public Celebrity Get(int id)
        {
            return GetCelebrities().Single(celebrity => celebrity.Id == id);
        }

        public bool IsExists(int id)
        {
            var celebrities = GetCelebrities();
            return celebrities.Any(celebrity => celebrity.Id == id);
        }

        public void Add(Celebrity celebrity)
        {
            //TODO: In real world I would use AutoNumber at database level
            celebrity.Id = celebrity.GetHashCode();
            var celebrities = GetCelebrities();
            celebrities.Add(celebrity);
            _jsonFileManager.Write(SerializeCelebrities(celebrities));
        }

        public void Update(int id, Celebrity celebrity)
        {
            var celebrities = GetCelebrities();
            var celebrityToUpdate = celebrities.Single(c => c.Id == id);
            //TODO: In real world I would use AutoMapper
            celebrityToUpdate.Name = celebrity.Name;
            celebrityToUpdate.Age = celebrity.Age;
            celebrity.Country = celebrity.Country;
            _jsonFileManager.Write(SerializeCelebrities(celebrities));
        }

        public void Remove(int id)
        {
            var celebrities = GetCelebrities();
            _jsonFileManager.Write(SerializeCelebrities(celebrities.Where(celebrity => celebrity.Id != id)));
        }

        private List<Celebrity> GetCelebrities()
        {
            var json = _jsonFileManager.Read();
            return JsonConvert.DeserializeObject<List<Celebrity>>(json);
        }

        private string SerializeCelebrities(IEnumerable<Celebrity> celebrities)
        {
            return JsonConvert.SerializeObject(celebrities, Formatting.Indented);
        }

    }
}
