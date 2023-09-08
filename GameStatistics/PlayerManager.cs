using GameStatistics.FileHandler;
using Models;
using Models.Enums;

namespace GameStatistics
{
    public class PlayerManager
    {
        private readonly IFileHandler _fileHandler;
        private readonly GameVariant _gameVariant;
        public PlayerManager(IFileHandler fileHandler, GameVariant gameVariant)
        {
            _fileHandler = fileHandler;
            _gameVariant = gameVariant;
        }
        public void UpdatePlayer(Player player)
        {
            List<Player> players = _fileHandler.ReadPlayersFromFile(_gameVariant);
            Player? existingPlayer = players.FirstOrDefault(p => p.GameVariant == _gameVariant && p.Name == player.Name);
            if (existingPlayer != null)
            {
                existingPlayer.UpdateExistingPlayerStatistics(player);
            }
            else
            {
                player.UpdateNewPlayerStatistics();
                players.Add(player);
            }
            _fileHandler.WritePlayersToFile(players);
        }
    }
}
