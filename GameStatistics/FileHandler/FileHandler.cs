using GameStatistics.JsonFileConfiguration;
using Microsoft.Extensions.Configuration;
using Models;
using Models.Enums;
using System.Text.Json;

namespace GameStatistics.FileHandler
{

    public class FileHandler : IFileHandler
    {
        private readonly IConfiguration _configuration;
        private readonly string? _statsFileName;

        private FileHandler()
        {

        }
        public FileHandler(string statsFileName)
        {
            _configuration = new ConfigurationBuilder()
            .Add(new JsonFileConfigurationSource("FileSettings.json"))
            .Build();
            _statsFileName = _configuration.GetRequiredSection(statsFileName).Value;
        }

        public List<Player> ReadPlayersFromFile(GameVariant gameVariant)
        {
            if (File.Exists(_statsFileName))
            {
                string jsonData = File.ReadAllText(_statsFileName);
                var allPlayers = JsonSerializer.Deserialize<List<Player>>(jsonData) ?? new List<Player>();

                // Filter players by game variant
                return allPlayers.Where(player => player.GameVariant == gameVariant).ToList();
            }

            return new List<Player>();
        }

        public void WritePlayersToFile(List<Player> players)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;

            string jsonData = JsonSerializer.Serialize(players, options);
            File.WriteAllText(_statsFileName, jsonData);
        }
    }
}
