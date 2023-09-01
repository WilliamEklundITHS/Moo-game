using Models;

namespace GameStatistics
{
    public class Leaderboard
    {
        public void CalculateLeaderboard(List<Player>? players)
        {
            players.Sort((p1, p2) => p1.CalculateAverageGuesses().CompareTo(p2.CalculateAverageGuesses()));
        }
        public void DisplayLeaderboard(List<Player>? players)
        {
            Console.WriteLine("Leaderboard:");

            foreach (Player player in players)
            {
                Console.WriteLine($"{player.Name} - Avg. Guesses: {player.CalculateAverageGuesses()}");
            }
        }
    }


}