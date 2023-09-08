using Models;
using Models.Enums;

namespace Application
{
    public class Gameplay
    {
        public string SecretCode { get; }
        public string PlayerProgress { get; private set; }
        public Gameplay()
        {
            SecretCode = GenerateSecretCode();
        }

        public GameState ProcessGuess(string guess)
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
            return GameState.Ongoing;
        }
        private static bool IsGuessCorrect(PlayerGuess playerGuess) => playerGuess.Bulls == 4;

        private string GetPlayerProgress(int cows, int bulls)
        {
            return $"{new string('C', cows)}{new string('B', bulls)}" +
                              new string('-', Math.Max(0, SecretCode.Length - cows - bulls));

        }
        private string GenerateSecretCode()
        {
            Random random = new Random();
            List<int> digits = new List<int>();

            while (digits.Count < 4)
            {
                int digit = random.Next(1, 10);
                if (!digits.Contains(digit))
                {
                    digits.Add(digit);
                }
            }

            return string.Join("", digits);
        }



    }
}

