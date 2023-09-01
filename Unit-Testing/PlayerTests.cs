using Models;
using Xunit;

namespace UnitTesting
{
    public class PlayerTests
    {
        [Fact]
        public void UpdateNewPlayerStatistics_Should_Update_Player_Statistics_Correctly()
        {
            Player player = new Player("TestPlayer");
            player.IncrementTotalGuesses();
            int initialTotalGuesses = player.TotalGuesses;
            player.UpdateNewPlayerStatistics();
            Assert.Equal(initialTotalGuesses + 1, player.TotalGuesses);
        }
    }
}

