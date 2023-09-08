using Application;
using GameStatistics;
using GameStatistics.FileHandler;
using Models;
using Models.Enums;

public class GameController
{
    private readonly PlayerManager _playerManager;
    private readonly LeaderboardManager _leaderboardManager;
    private readonly IUserInterface _userInterface;
    private readonly Player _player;
    private GameState _gameState;
    private readonly IGameFactory _gameFactory;
    public GameController(IUserInterface userInterface)
    {
        // Initialize game components
        _gameFactory = new GameFactory();
        _player = new Player(userInterface.GetGameVariant(), userInterface.GetUsername());
        IFileHandler fileHandler = new FileHandler("FileSettings:FilePath");
        _playerManager = new(fileHandler, _player.GameVariant);
        _leaderboardManager = new(fileHandler, _player.GameVariant);
        _userInterface = userInterface;
    }

    public void Play()
    {
        bool playAgain = true;
        while (playAgain)
        {
            //create new game for everytime the player wants to play again
            GameBase gameBase = _gameFactory.CreateGame(_player.GameVariant, _player);
            do
            {
                Console.WriteLine(gameBase.SecretCode);
                string guess = _userInterface.GetGuess();
                if (string.IsNullOrWhiteSpace(guess)) { continue; }
                _gameState = gameBase.ProcessGuess(guess);
                if (_gameState == GameState.Won)
                {
                    _userInterface.DisplayGameOutcome(_gameState, gameBase.SecretCode);
                    _playerManager.UpdatePlayer(_player);
                    _leaderboardManager.InitializeLeaderboard();
                    _leaderboardManager.DisplayLeaderboard();
                    playAgain = _userInterface.AskForPlayAgain();
                }
                else
                {
                    _userInterface.DisplayProgress(gameBase.PlayerProgress);
                }

            }
            while (_gameState == GameState.Ongoing);
        }
    }
}
