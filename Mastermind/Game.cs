using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    public class Game
    {
        /// <summary>
        /// finds all solutions
        /// </summary>
        /// <param name="hints"></param>
        /// <returns></returns>
        public IEnumerable<ushort[]> Solve(Hints hints)
        {
            int rowDigitCount = hints.RowDigitCount;
            ushort[] guessPhrase = new ushort[rowDigitCount];
            for (int i = 0; i < Math.Pow(10,rowDigitCount); i++)
            {
                int number = i;
                for (int j = rowDigitCount - 1; j >= 0; j--)
                {
                    guessPhrase[j] = (ushort) (number % 10);
                    number /= 10;
                }
                if(hints.Matches(guessPhrase))
                    yield return guessPhrase;                   
            }
            
        }



    }
}
