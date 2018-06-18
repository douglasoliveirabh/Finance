using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Scrappers.Tasks.Scrappers.Providers
{
    public class AlphabetProvider
    {
        public static IEnumerable<char> GetAlphabet()
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                yield return c;
            }
        }
    }
}
