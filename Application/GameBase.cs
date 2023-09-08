using Models;
using Models.Enums;

namespace Application
{
    public abstract class GameBase
    {
        public string SecretCode { get; protected set; }
        public string PlayerProgress { get; protected set; }
        public abstract GameState ProcessGuess(string guess);
        protected abstract string GenerateSecretCode(int codeLength);
        protected abstract bool IsGuessCorrect(PlayerGuess playerGuess);
        protected abstract string GetPlayerProgress(int cows, int bulls);

    }

}
