using Application;
using Models.Enums;
using Xunit;

namespace UnitTesting

{
    public class GameplayTests
    {
        [Fact]
        public void ProcessGuess_Should_Return_Won_State_When_Guess_Is_Correct()
        {
            Gameplay gameplay = new Gameplay();
            string secretCode = gameplay.SecretCode;

            GameState result = gameplay.ProcessGuess(secretCode);

            Assert.Equal(GameState.Won, result);
        }
    }
}