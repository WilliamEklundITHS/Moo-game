using GameStatistics;
using GameStatistics.FileHandler;
using Models;
using Moq;
using Xunit;

namespace UnitTesting
{
    public class PlayerManagerTests
    {
        [Fact]
        public void UpdatePlayer_Should_Update_Existing_Player_Statistics_Correctly()
        {
            string playerName = "TestPlayer";
            const int TotalGamesPlayedResult = 4;
            const int TotalGuessesResult = 31;

            Player existingPlayer = new Player(playerName);
            existingPlayer.TotalGamesPlayed = 3;
            existingPlayer.TotalGuesses = 12;

            List<Player> players = new List<Player>
            {
                existingPlayer
            };

            Mock<IFileHandler> mockFileHandler = new Mock<IFileHandler>();
            mockFileHandler.Setup(fh => fh.ReadPlayersFromFile()).Returns(players);

            PlayerManager playerManager = new PlayerManager(mockFileHandler.Object);

            Player updatedPlayer = new Player(playerName);
            updatedPlayer.TotalGamesPlayed = 1;
            updatedPlayer.TotalGuesses = 18;

            playerManager.UpdatePlayer(updatedPlayer);

            Player playerInFile = players.FirstOrDefault(p => p.Name == playerName);
            Assert.NotNull(playerInFile);
            Assert.Equal(playerInFile.TotalGamesPlayed, TotalGamesPlayedResult);
            Assert.Equal(playerInFile.TotalGuesses, TotalGuessesResult);
        }

    }
}
