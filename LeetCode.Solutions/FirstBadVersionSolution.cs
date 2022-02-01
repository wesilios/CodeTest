namespace LeetCode.Solutions
{
    public class FirstBadVersionSolution : VersionControl
    {
        public FirstBadVersionSolution(int firstBadVersion) : base(firstBadVersion)
        {
        }

        public int FirstBadVersion(int versions)
        {
            var start = 0;
            var end = versions;

            while (end - start > 1)
            {
                var middle = (end - start) / 2 + start;
                if (IsBadVersion(middle))
                {
                    end = middle;
                    continue;
                }

                start = middle;
            }

            return end;
        }
    }

    public class VersionControl
    {
        private readonly int _firstBadVersion;

        protected VersionControl(int firstBadVersion)
        {
            _firstBadVersion = firstBadVersion;
        }

        protected bool IsBadVersion(int version)
        {
            return version >= _firstBadVersion;
        }
    }
}