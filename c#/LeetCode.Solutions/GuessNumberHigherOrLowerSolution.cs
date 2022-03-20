namespace LeetCode.Solutions
{
    public class GuessNumberHigherOrLowerSolution : GuessGame
    {
        public GuessNumberHigherOrLowerSolution(int pick) : base(pick)
        {
        }

        public int GuessNumber(int n)
        {
            var start = 1;
            var end = int.MaxValue;
            var guess = n;
            var guessResult = Guess(guess);

            while (guessResult != 0)
            {
                if (guessResult == -1)
                {
                    end = guess - 1;
                }
                else
                {
                    start = guess + 1;
                }

                guess = start + (end - start) / 2;
                guessResult = Guess(guess);
            }

            return guess;
        }
    }

    public class GuessGame
    {
        private readonly int _pick;

        protected GuessGame(int pick)
        {
            _pick = pick;
        }

        protected int Guess(int n)
        {
            if (_pick < n) return -1;
            if (_pick > n) return 1;
            return 0;
        }
    }
}