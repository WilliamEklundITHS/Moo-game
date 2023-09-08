using Application;
using Models.Enums;

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

        public void DisplayGameVariants()
        {
            Console.Write(MessageGenerator.GetGameVariantPrompt());
        }

        public GameVariant GetGameVariant()
        {
            int selectedGame;
            do
            {
                Console.WriteLine("Select a game:");
                Console.WriteLine("0 - Moo");
                Console.WriteLine("1 - Mastermind");
                //Console.WriteLine("2 - Exit");

                if (int.TryParse(Console.ReadLine(), out selectedGame))
                {
                    switch (selectedGame)
                    {
                        case 0:
                            // Initialize and start the Moo game
                            Console.WriteLine("Starting Moo game...");
                            return GameVariant.Moo;

                        case 1:
                            // Initialize and start the Mastermind game
                            Console.WriteLine("Starting Mastermind game...");
                            return GameVariant.MasterMind;

                        default:
                            Console.WriteLine("Invalid selection. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

            } while (selectedGame > 1);
            throw new InvalidOperationException();
        }
    }


}
