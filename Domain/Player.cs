using System.Text.Json.Serialization;

namespace Models
{
    public class Player
    {
        public string Name { get; }
        //public List<string> Guesses { get; } = new List<string>();
        public int TotalGamesPlayed { get; set; }
        public int TotalGuesses { get; set; }



        [JsonConstructor]
        public Player(string name, int totalGamesPlayed, int totalGuesses)
        {
            Name = name;
            TotalGamesPlayed = totalGamesPlayed;
            TotalGuesses = totalGuesses;

        }
        public Player(string name)
        {
            Name = name;
        }

        //public void AddGuess(string guess)
        //{
        //    Guesses.Add(guess);
        //}

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
