using Xunit;

namespace CodeTest
{
    public class CheckStringTests
    {
        [Theory]
        [InlineData("aba", true)]
        [InlineData("abxa", true)]
        [InlineData("axba", true)]
        [InlineData("abxza", false)]
        [InlineData("abxz", false)]
        [InlineData("abcbca", true)]
        [InlineData("babababa", true)]
        [InlineData("baba", true)]
        [InlineData("abbxa", true)]
        [InlineData("axbaa", false)]
        [InlineData("abxzba", true)]
        [InlineData("abyba", true)]
        [InlineData("abcdydcba", true)]
        [InlineData("axbcdydcbax", false)]
        public void CheckString_ExpectSuccess(string input, bool expectedResult)
        {
            var solution = new Solution();
            Assert.Equal(expectedResult, solution.CheckString(input));
        }
        
        [Theory]
        [InlineData("aba", 0)]
        [InlineData("abxa", 1)]
        [InlineData("axba", 1)]
        [InlineData("abxza", 2)]
        [InlineData("abxz", 4)]
        [InlineData("abcbca", 1)]
        [InlineData("babababa", 1)]
        [InlineData("baba", 1)]
        [InlineData("abbxa", 1)]
        [InlineData("axbaa", 2)]
        [InlineData("abxzba", 1)]
        [InlineData("abyba", 0)]
        [InlineData("abcdydcba", 0)]
        [InlineData("axbcdydcbax", 2)]
        [InlineData("dcxbcdydcbaxd", 4)]
        public void CountRemoveIndex(string input, int expectedResult)
        {
            var solution = new Solution();
            Assert.Equal(expectedResult, solution.CountRemoveCharacter(input));
        }

        private class Solution
        {
            public int CountRemoveCharacter(string input)
            {
                var countLeft = 0;
                var countRight = 0;
                var left = 0;
                var right = input.Length - 1;
                while (right > left)
                {
                    if (input[left] == input[right])
                    {
                        left++;
                        right--;
                        continue;
                    }

                    if (input[left] == input[right - 1] && input[left + 1] == input[right - 2])
                    {
                        countLeft++;
                        right--;
                        continue;
                    }

                    if (input[left + 1] == input[right] && input[left + 2] == input[right - 1])
                    {
                        countRight++;
                        left++;
                        continue;
                    }

                    if (right - 1 > left + 1)
                    {
                        countLeft++;
                        countRight++;
                    }
                    
                    left++;
                    right--;
                }
                
                return countLeft + countRight;
            }

            public bool CheckString(string input)
            {
                const int allowRemovingNumber = 1;
                return CountRemoveCharacter(input) <= allowRemovingNumber;
            }
        }
    }
}