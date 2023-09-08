using Models.Enums;

namespace Presentation
{
    class MessageGenerator
    {
        public static string WelcomeMessage()
        {
            return "Welcome to the Moo Game!\n";
        }
        public static string GetGameVariantPrompt()
        {
            return $" Select a game: \n0 - Moo\n1 - MasterMind";
        }
        public static string GetPlayerPrompt()
        {
            return "Enter your name: ";
        }
        public static string GetGuessPrompt()
        {
            return "Enter your guess: ";
        }

        public static string PlayAgainPrompt()
        {
            return "Do you want to play again? (Y/N): ";
        }

        public static string ProgressMessage(string progress)
        {
            return $"Your progress: {progress}";
        }

        public static string GameOutcomeMessage(GameState status, string secretCode)
        {
            if (status == GameState.Won)
            {
                return $"Congratulations! You've guessed the code {secretCode}.";
            }
            else
            {
                return $"Sorry, you've run out of guesses. The code was {secretCode}.";
            }
        }
    }

}
