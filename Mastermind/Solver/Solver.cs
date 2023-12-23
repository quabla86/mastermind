using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mastermind.Game;

namespace Mastermind.Solver
{
    public class Solver : ISolver
    {
        /// <summary>
        /// finds all solutions
        /// </summary>
        /// <param name="hints"></param>
        /// <returns></returns>
        public IEnumerable<ushort[]> Solve(Hints hints)
        {
            int hintsCount = hints.DigitCount;
            ushort[] guessPhrase = new ushort[hintsCount];

            int v = (int)Math.Pow(10, hintsCount);
            for (int i = 0; i < v; i++)
            {

                if (hints.Matches(guessPhrase))
                    yield return guessPhrase.ToArray();

                Increment(guessPhrase);
            }
        }
        void Increment(ushort[] current)
        {
            for (int i = current.Length - 1; i >= 0; i--)
            {
                if (current[i] != 9)
                {
                    current[i]++;
                    return;
                }
                current[i] = 0;
            }

        }
    }
}
