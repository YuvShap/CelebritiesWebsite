using System.IO;
using Microsoft.Extensions.Options;

namespace CelebritiesWebsite.Repository
{
    public class JsonFileManager : IJsonFileManager
    {
        private readonly string _jsonFilePath;

        public JsonFileManager(IOptions<JsonFileOptions> options)
        {
            _jsonFilePath = options.Value.JsonFilePath;
        }

        public string Read()
        {
            return File.ReadAllText(_jsonFilePath);
        }

        public void Write(string json)
        {
            File.WriteAllText(_jsonFilePath, json);
        }
    }
}
