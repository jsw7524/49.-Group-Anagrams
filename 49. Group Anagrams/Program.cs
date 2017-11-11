using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _49.Group_Anagrams
{
    public class Solution
    {
        //public IList<IList<string>> GroupAnagrams(string[] strs)
        //{
        //    var tmp = strs
        //    .Where(s => string.Empty != s)
        //    .GroupBy(s => s.Select(c => c.ToString()).OrderBy(c => c).Aggregate((all, cur) => all + cur))
        //    .Select(g => g.ToList())
        //    .ToList<IList<string>>();

        //    IList<string> t2 = strs.Where(s => string.Empty == s).ToList<string>();
        //    if (t2.Count > 0)
        //    {
        //        tmp.Add(t2);
        //    }
        //    return tmp;
        //}

        List<int> PrimeNumber = new List<int>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101 };
        public IList<IList<string>> GroupAnagrams(string[] strs) 
        {
            //Unique Prime Factorization
            var alphabetMapper = "abcdefghijklmnopqrstuvwxyz"
                .Select(c => c.ToString())
                .Zip(PrimeNumber, (a, b) => new  KeyValuePair<string, int>(a,b))
                .ToDictionary(x=>x.Key);

            var tmp = strs
            .Where(s => string.Empty != s)
            .Select(s => new KeyValuePair<string, int>(s, s.Select(c => c.ToString())
            .Aggregate(1, (all, cur) => all * alphabetMapper[cur].Value)))
            .ToLookup(k => k.Value, k => k.Key)
            .Select(g => g.ToList())
            .ToList<IList<string>>();

            IList<string> t2 = strs.Where(s => string.Empty == s).ToList<string>();
            if (t2.Count > 0)
            {
                tmp.Add(t2);
            }

            return tmp;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            (new Solution()).GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });
            //(new Solution()).GroupAnagrams(new string[] { "" });
        }
    }
}
