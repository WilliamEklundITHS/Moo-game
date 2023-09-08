
namespace Presentation;
using Application;

class Play
{
    static void Main(string[] args)
    {
        IUserInterface userInterface = new ConsoleUI();
        GameController game = new GameController(userInterface);
        game.Play();
    }
}


