using Application;

namespace Presentation
{
    public class ConsoleUI : IUserInterface
    {

        public void DisplayInstructions()
        {
            Console.WriteLine(MessageGenerator.WelcomeMessage());
        }
        public string GetName()
        {
            Console.WriteLine(MessageGenerator.GetPlayerPrompt());
            return Console.ReadLine();
        }
        public string GetGuess()
        {
            Console.Write(MessageGenerator.GetGuessPrompt());
            return Console.ReadLine();
        }

        public bool AskForPlayAgain()
        {
            Console.Write(MessageGenerator.PlayAgainPrompt());
            string response = Console.ReadLine().Trim().ToUpper();
            return response == "Y";
        }

        public void DisplayProgress(string progress)
        {
            Console.WriteLine(MessageGenerator.ProgressMessage(progress));
        }

        public void DisplayGameOutcome(GameState status, string secretCode)
        {
            Console.WriteLine(MessageGenerator.GameOutcomeMessage(status, secretCode));
        }

        public string GetUsername()
        {
            Console.Write(MessageGenerator.GetPlayerPrompt());
            return Console.ReadLine();
        }
    }


}
