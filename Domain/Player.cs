using Models.Enums;
using System.Text.Json.Serialization;

namespace Models
{
    public class Player
    {
        public string Name { get; }
        public int TotalGamesPlayed { get; set; }
        public int TotalGuesses { get; set; }
        public GameVariant GameVariant { get; set; }

        [JsonConstructor]
        public Player(GameVariant gameVariant, string name, int totalGamesPlayed, int totalGuesses)
        {
            GameVariant = gameVariant;
            Name = name;
            TotalGamesPlayed = totalGamesPlayed;
            TotalGuesses = totalGuesses;

        }
        public Player(GameVariant gameVariant, string name)
        {
            GameVariant = gameVariant;
            Name = name;
        }
        public void UpdateExistingPlayerStatistics(Player player)
        {
            TotalGamesPlayed++;
            TotalGuesses += player.TotalGuesses + 1;
        }
        public void UpdateNewPlayerStatistics()
        {
            TotalGamesPlayed++;
            //Add the winning guess
            TotalGuesses++;
        }
        public double CalculateAverageGuesses()
        {
            if (TotalGamesPlayed == 0)
                return 0.0;

            return (double)TotalGuesses / TotalGamesPlayed;
        }
        public void IncrementTotalGuesses()
        {
            TotalGuesses++;
        }
    }


}
