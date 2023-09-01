using Microsoft.Extensions.Configuration;

namespace GameStatistics.JsonFileConfiguration
{
    public class JsonFileConfigurationSource : IConfigurationSource
    {
        public string FilePath { get; set; }

        public JsonFileConfigurationSource(string filePath)
        {
            FilePath = filePath;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new JsonFileConfigurationProvider(FilePath);
        }
    }

}
