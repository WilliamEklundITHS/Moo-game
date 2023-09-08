using Models;
using Models.Enums;

namespace GameStatistics.FileHandler
{
    public interface IFileHandler
    {
        List<Player> ReadPlayersFromFile(GameVariant gameVariant);
        void WritePlayersToFile(List<Player> items);
    }

}
