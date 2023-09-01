using GameStatistics.FileHandler;
using Models;

namespace GameStatistics
{
    public class PlayerManager
    {
        private readonly IFileHandler fileHandler;

        public PlayerManager(IFileHandler fileHandler)
        {
            this.fileHandler = fileHandler;
        }
        public void UpdatePlayer(Player player)
        {
            List<Player> players = fileHandler.ReadPlayersFromFile();
            Player existingPlayer = players.FirstOrDefault(p => p.Name == player.Name);

            if (existingPlayer != null)
            {
                existingPlayer.UpdateExistingPlayerStatistics(player);
            }
            else
            {
                player.UpdateNewPlayerStatistics();
                players.Add(player);
            }

            fileHandler.WritePlayersToFile(players);
        }
    }
}
