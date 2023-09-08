using Models;
using Models.Enums;

namespace Application
{
    public interface IGameFactory
    {
        public GameBase CreateGame(GameVariant gameVariant, Player player);
    }
}
