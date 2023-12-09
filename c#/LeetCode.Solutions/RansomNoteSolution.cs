using System.Collections.Generic;

namespace LeetCode.Solutions
{
    public class RansomNoteSolution
    {
        public bool CheckRansomNote(string ransomNote, string magazine)
        {
            var dictionary = new Dictionary<char, int>();
            foreach (var magazineChar in magazine)
            {
                if (!dictionary.TryAdd(magazineChar, 1))
                {
                    dictionary[magazineChar]++;
                }
            }

            foreach (var ransomNoteChar in ransomNote)
            {
                if (dictionary.ContainsKey(ransomNoteChar))
                {
                    dictionary[ransomNoteChar]--;
                    if (dictionary[ransomNoteChar] < 0) return false;
                    continue;
                }

                return false;
            }
            
            return true;
        }
    }
}