using System;

namespace CodeTest.CountingElements;

public class MaxCountersTests
{
    [Fact]
    public void MaxCounters()
    {
        var a = new[] { 3, 4, 4, 6, 1, 4, 4 };
        var expected = new[] { 3, 2, 2, 4, 2 };
        var solution = new Solution();
        var result = solution.ReturnSolution(5, a);
        for (var i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], result[i]);
        }
    }

    private class Solution
    {
        private int[] _counters;
        private int _greaterValueInCounter;
        private int _currentEquilibratedScore;

        public int[] ReturnSolution(int n, int[] a)
        {
            _counters = new int[n];
            foreach (var t in a)
            {
                if (t < 1 || t > n + 1)
                    throw new InvalidOperationException();
                if (t <= n)
                {
                    IncreaseCounter(t);
                    continue;
                }

                MaxCounter();
            }

            return ReturnCounters();
        }

        private void IncreaseCounter(int x)
        {
            var counterPosition = x - 1;
            if (_counters[counterPosition] < _currentEquilibratedScore)
            {
                _counters[counterPosition] = _currentEquilibratedScore + 1;
            }
            else
            {
                _counters[counterPosition] += 1;
            }

            if (_counters[counterPosition] > _greaterValueInCounter)
            {
                _greaterValueInCounter = _counters[counterPosition];
            }
        }

        private int[] ReturnCounters()
        {
            for (var i = 0; i < _counters.Length; i++)
            {
                if (_counters[i] < _currentEquilibratedScore)
                {
                    _counters[i] = _currentEquilibratedScore;
                }
            }

            return _counters;
        }

        private void MaxCounter()
        {
            _currentEquilibratedScore = _greaterValueInCounter;
        }
    }
}