namespace Models
{
    public class PlayerGuess
    {
        public int Cows { get; }
        public int Bulls { get; }

        public PlayerGuess(int cows = 0, int bulls = 0)
        {
            Cows = cows;
            Bulls = bulls;
        }
    }

}
