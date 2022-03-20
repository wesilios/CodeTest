namespace LeetCode.Solutions
{
    public class LengthOfLastWordSolution
    {
        public int LengthOfLastWord(string s)
        {
            var stringArray = s.Split();

            if (stringArray.Length == 0) return 0;

            var lastWord = string.Empty;

            for (var i = stringArray.Length - 1; i >= 0; i--)
            {
                if(string.IsNullOrEmpty(stringArray[i])) continue;
                lastWord = stringArray[i];
                break;
            }

            return lastWord.Length;
        }
    }
}