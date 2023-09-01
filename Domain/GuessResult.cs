namespace Models
{
    public class GuessResult
    {
        public int Bulls { get; }
        public int Cows { get; }
        public GuessResult(int bulls = 0, int cows = 0)
        {
            if (bulls > 4 || cows > 4) throw new Exception("Max 4 bulls and cows is allowed");
            Bulls = bulls;
            Cows = cows;
        }
    }
}