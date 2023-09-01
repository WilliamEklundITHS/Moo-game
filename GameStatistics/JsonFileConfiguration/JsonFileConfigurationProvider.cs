using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Text.Json;

namespace GameStatistics.JsonFileConfiguration
{
    public class JsonFileConfigurationProvider : ConfigurationProvider
    {
        private readonly string _filePath;

        public JsonFileConfigurationProvider(string filePath)
        {
            _filePath = filePath;
        }

        public override void Load()
        {
            var fileContents = File.ReadAllText($"{RetrieveDirectoryPath()}/{_filePath}");
            var jsonConfig = JsonSerializer.Deserialize<JsonElement>(fileContents);

            if (jsonConfig.TryGetProperty("FileSettings", out var fileSettings))
            {
                if (fileSettings.TryGetProperty("FileUrl", out var fileUrl))
                {
                    Data["FileSettings:FileUrl"] = fileUrl.GetString();
                }
            }
        }
        private static string RetrieveDirectoryPath()
        {
            StackTrace stackTrace = new StackTrace(true);
            StackFrame frame = stackTrace.GetFrame(0);
            string filePath = frame.GetFileName();
            string directoryPath = Path.GetDirectoryName(filePath);
            return directoryPath.Replace("\\", "/");
        }
    }

}
