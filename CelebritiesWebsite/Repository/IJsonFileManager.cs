
namespace CelebritiesWebsite.Repository
{
    public interface IJsonFileManager
    {
        string Read();

        void Write(string json);
    }
}