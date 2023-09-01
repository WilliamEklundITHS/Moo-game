using GameStatistics.JsonFileConfiguration;
using Microsoft.Extensions.Configuration;
using Models;
using System.Text.Json;

namespace GameStatistics.FileHandler
{

    public class FileHandler : IFileHandler
    {
        readonly IConfiguration configuration = new ConfigurationBuilder()
               .Add(new JsonFileConfigurationSource("FileSettings.json"))
               .Build();
        private readonly string? StatsFileName;

        public FileHandler(string statsFileName)
        {

            StatsFileName = configuration.GetSection(statsFileName).Value;
        }

        public List<Player> ReadPlayersFromFile()
        {
            if (File.Exists(StatsFileName))
            {
                string jsonData = File.ReadAllText(StatsFileName);
                return JsonSerializer.Deserialize<List<Player>>(jsonData) ?? new List<Player>();
            }

            return new List<Player>();
        }

        public void WritePlayersToFile(List<Player> items)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;

            string jsonData = JsonSerializer.Serialize(items, options);
            File.WriteAllText(StatsFileName, jsonData);
        }
    }
}
