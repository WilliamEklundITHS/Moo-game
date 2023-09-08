namespace Models
{
    public class PlayerGuess
    {
        public int Cows { get; }
        public int Bulls { get; }

        public PlayerGuess(int cows = 0, int bulls = 0)
        {
            if (bulls > 4 || cows > 4) throw new Exception("Max 4 bulls and cows is allowed");
            Cows = cows;
            Bulls = bulls;
        }
    }

}
