using Microsoft.Extensions.Configuration;

namespace GameStatistics.JsonFileConfiguration
{
    public class JsonFileConfigurationSource : IConfigurationSource
    {
        private readonly string _configurationName;

        public JsonFileConfigurationSource(string configFileName)
        {
            _configurationName = configFileName;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new JsonFileConfigurationProvider(_configurationName);
        }
    }

}
