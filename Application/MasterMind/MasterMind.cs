using Models;
using Models.Enums;

namespace Application.MasterMind
{
    public class MasterMind : GameBase
    {
        public int CodeLength { get; }
        public int NumberOfColors { get; }
        private readonly static Dictionary<Color, char> ColorCharMap = new Dictionary<Color, char>
        {
            { Color.Red, 'R' },
            { Color.Green, 'G' },
            { Color.Blue, 'B' },
            { Color.Yellow, 'Y' },
            { Color.Orange, 'O' },
            { Color.Purple, 'P' }
        };
        private readonly Player _player;
        public MasterMind(Player player, int codeLength, int numberOfColors)
        {
            _player = player;
            CodeLength = codeLength;
            NumberOfColors = numberOfColors;
            SecretCode = GenerateSecretCode(codeLength);
        }

        public override GameState ProcessGuess(string guess)
        {
            guess = guess.ToUpper();
            int bulls = 0;
            int cows = 0;
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
            string secretCode = "";

            for (int i = 0; i < CodeLength; i++)
            {
                int randomIndex = random.Next(NumberOfColors);
                secretCode += ColorCharMap.ElementAt(randomIndex).Value;
            }
            return secretCode;
        }

        protected override bool IsGuessCorrect(PlayerGuess playerGuess) => playerGuess.Bulls == SecretCode.Length;


        protected override string GetPlayerProgress(int cows, int bulls)
        {
            return $"{new string('C', cows)}{new string('B', bulls)}" +
                                         new string('-', Math.Max(0, SecretCode.Length - cows - bulls));
        }
    }

}
