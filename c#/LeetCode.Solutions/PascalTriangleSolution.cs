using System.Collections.Generic;

namespace LeetCode.Solutions
{
    public class PascalTriangleSolution
    {
        public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> result = new List<IList<int>>
            {
                new List<int> { 1 }
            };

            for (var i = 1; i < numRows; i++)
            {
                var row = new List<int>();
                for (var j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i)
                    {
                        row.Add(result[i - 1][0]);
                        continue;
                    }

                    row.Add(result[i - 1][j-1] + result[i - 1][j]);
                }

                result.Add(row);
            }

            return result;
        }
    }
}