using Application;
using GameStatistics;
using GameStatistics.FileHandler;
using Models;

public class GameController
{
    private readonly PlayerManager playerManager;
    private readonly LeaderboardManager leaderboardManager;
    private Gameplay gameplay;
    private readonly IUserInterface userInterface;
    private readonly Player player;
    private GameState gameState;

    public GameController(IUserInterface userInterface)
    {
        var fileHandler = new FileHandler("FileSettings:FileUrl");
        this.playerManager = new(fileHandler);
        this.leaderboardManager = new(fileHandler);
        this.userInterface = userInterface;
        player = new Player(userInterface.GetUsername());
    }

    public void Play()
    {
        //create new game for everytime the player wants to play again
        gameplay = new();
        do
        {
            Console.WriteLine(gameplay.SecretCode);
            string guess = userInterface.GetGuess();
            if (string.IsNullOrWhiteSpace(guess)) { continue; }
            gameState = gameplay.ProcessGuess(guess);
            if (gameState == GameState.Won)
            {
                userInterface.DisplayGameOutcome(gameState, gameplay.SecretCode);
                playerManager.UpdatePlayer(player);
                leaderboardManager.InitializeLeaderboard();
                leaderboardManager.DisplayLeaderboard();
            }
            else
            {
                player.IncrementTotalGuesses();
                userInterface.DisplayProgress(gameplay.PlayerProgress);
            }

        }
        while (gameState == GameState.Ongoing);
    }
}
