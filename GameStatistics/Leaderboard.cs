using Models;

namespace GameStatistics
{
    public class Leaderboard
    {
        public static void CalculateLeaderboard(List<Player>? players)
        {
            players?.Sort((p1, p2) => p1.CalculateAverageGuesses().CompareTo(p2.CalculateAverageGuesses()));
        }
        public static void DisplayLeaderboard(List<Player>? players)
        {
            Console.WriteLine("Leaderboard:");
            if (players is null) return;
            foreach (Player player in players)
            {
                Console.WriteLine($"{player?.Name} - Avg. Guesses: {player?.CalculateAverageGuesses()}");
            }
        }
    }


}