using Models;
using Models.Enums;

namespace Application.Moo
{
    public class Moo : GameBase
    {
        public int CodeLength { get; }
        private readonly Player _player;
        public Moo(Player player, int codeLength)
        {
            _player = player;
            CodeLength = codeLength;
            SecretCode = GenerateSecretCode(codeLength);
        }
        public override GameState ProcessGuess(string guess)
        {
            int cows = 0;
            int bulls = 0;
            int minLength = Math.Min(guess.Length, SecretCode.Length);
            for (int i = 0; i < minLength; i++)
            {
                if (guess[i] == SecretCode[i])
                {
                    bulls++;
                }
                else if (SecretCode.Contains(guess[i]))
                {
                    cows++;
                }
            }

            PlayerGuess playerGuess = new PlayerGuess(cows, bulls);
            if (IsGuessCorrect(playerGuess))
            {
                return GameState.Won;
            }
            PlayerProgress = GetPlayerProgress(cows, bulls);
            _player.IncrementTotalGuesses();
            return GameState.Ongoing;
        }
        protected override string GenerateSecretCode(int codeLength)
        {
            Random random = new Random();
            List<int> digits = new List<int>();

            while (digits.Count < CodeLength)
            {
                int digit = random.Next(1, 10);
                if (!digits.Contains(digit))
                {
                    digits.Add(digit);
                }
            }
            return string.Join("", digits);
        }
        protected override bool IsGuessCorrect(PlayerGuess playerGuess) => playerGuess.Bulls == SecretCode.Length;

        protected override string GetPlayerProgress(int cows, int bulls)
        {
            return $"{new string('C', cows)}{new string('B', bulls)}" +
                              new string('-', Math.Max(0, SecretCode.Length - cows - bulls));

        }
    }
}
