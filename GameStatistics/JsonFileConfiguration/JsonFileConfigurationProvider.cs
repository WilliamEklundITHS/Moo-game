using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Text.Json;

namespace GameStatistics.JsonFileConfiguration
{
    public class JsonFileConfigurationProvider : ConfigurationProvider
    {
        private readonly string _configFile;

        public JsonFileConfigurationProvider(string configFile)
        {
            _configFile = configFile;
        }

        public override void Load()
        {
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).Replace("\\", "/");
            var fileContents = File.ReadAllText($"{GetDirectoryPathForJsonConfig()}/{_configFile}");
            var jsonConfig = JsonSerializer.Deserialize<JsonElement>(fileContents);
            if (jsonConfig.TryGetProperty("FileSettings", out var fileSettings))
            {
                if (fileSettings.TryGetProperty("FilePath", out var filePath))
                {
                    Data["FileSettings:FilePath"] = filePath.GetString().Replace("{FilePath}", desktop).Replace("{FileName}", "game_stats.json");
                }

                if (fileSettings.TryGetProperty("StaticFilePath", out var customFilePath))
                {
                    Data["FileSettings:StaticFilePath"] = customFilePath.GetString();
                }
            }
        }
        private static string GetDirectoryPathForJsonConfig()
        {
            StackTrace stackTrace = new StackTrace(true);
            StackFrame frame = stackTrace.GetFrame(0);
            string CustomFilePath = frame.GetFileName();
            string directoryPath = Path.GetDirectoryName(CustomFilePath);
            return directoryPath.Replace("\\", "/");
        }
    }

}
