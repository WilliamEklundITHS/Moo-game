using GameStatistics.FileHandler;
using Models;

namespace GameStatistics
{
    public class LeaderboardManager
    {
        private readonly IFileHandler fileHandler;
        private List<Player>? players;
        private Leaderboard leaderboard;


        public LeaderboardManager(IFileHandler fileHandler)
        {
            this.fileHandler = fileHandler;
            leaderboard = new();
        }
        public void InitializeLeaderboard()
        {
            players = fileHandler.ReadPlayersFromFile();
            leaderboard.CalculateLeaderboard(players);

        }
        public void DisplayLeaderboard()
        {
            leaderboard.DisplayLeaderboard(players);
        }
    }
}
