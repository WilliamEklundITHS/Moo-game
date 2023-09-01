using Models;

namespace GameStatistics.FileHandler
{
    public interface IFileHandler
    {
        List<Player> ReadPlayersFromFile();
        void WritePlayersToFile(List<Player> items);
    }

}
