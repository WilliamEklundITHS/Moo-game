namespace Application
{
    public interface IUserInterface
    {
        void DisplayInstructions();
        string GetUsername();
        string GetGuess();
        bool AskForPlayAgain();
        void DisplayProgress(string progress);
        void DisplayGameOutcome(GameState gameState, string secretCode);
    }

}
