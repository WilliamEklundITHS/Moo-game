using Models;
using Models.Enums;
namespace Application
{
    internal class GameFactory : IGameFactory
    {
        public GameBase CreateGame(GameVariant gameVariant, Player player)
        {
            if (gameVariant == GameVariant.Moo)
            {
                return new Moo.Moo(codeLength: 4);
            }
            else if (gameVariant == GameVariant.MasterMind)
            {
                return new MasterMind.MasterMind(player, codeLength: 4, numberOfColors: 6);
            }
            throw new NotSupportedException();
        }
    }
}
