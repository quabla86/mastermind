using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind.Game
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
            int hintsCount = hints.Count;
            ushort[] guessPhrase = new ushort[hintsCount];
            for (int i = 0; i < Math.Pow(10, hintsCount); i++)
            {
                
                if (hints.Matches(guessPhrase))
                    yield return guessPhrase;
                Increment(guessPhrase);
            }
        }


        bool Increment(ushort[] current)
        {
            for (int i = current.Length - 1; i >= 0; i--)
            {
                if (current[i] < 9)
                {
                    current[i]++;
                    return true;
                }
                current[i] = 0;
            }
            return false;
        }
    }
}
