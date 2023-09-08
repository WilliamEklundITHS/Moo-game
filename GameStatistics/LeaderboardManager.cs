using GameStatistics.FileHandler;
using Models;
using Models.Enums;

namespace GameStatistics
{
    public class LeaderboardManager
    {
        private readonly IFileHandler _fileHandler;
        private List<Player>? _players;
        private readonly GameVariant _gameVariant;
        public LeaderboardManager(IFileHandler fileHandler, GameVariant gameVariant)
        {
            this._fileHandler = fileHandler;
            _gameVariant = gameVariant;
        }
        public void InitializeLeaderboard()
        {
            _players = _fileHandler.ReadPlayersFromFile(_gameVariant);
            Leaderboard.CalculateLeaderboard(_players);

        }
        public void DisplayLeaderboard()
        {
            Leaderboard.DisplayLeaderboard(_players);
        }
    }
}
