﻿using System.Collections.Concurrent;
using Mastermind.Game;

namespace Mastermind.Solver
{
    public class ParallelSolver : ISolver
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

            int v = (int)Math.Pow(10, hintsCount);
            var results = new ConcurrentBag<ushort[]>();

            Parallel.For(0, v, i =>
            {
                // Make a copy of guessPhrase for each task to avoid shared state issues
                ushort[] guessPhrase = GetPhrase(i, hintsCount);
                if (hints.Matches(guessPhrase))
                {
                    results.Add(guessPhrase);
                }
            });

            return results;
        }
        ushort[] GetPhrase(int number, int digitCount)
        {
            ushort[] digits = new ushort[digitCount];

            for (int i = 0; i < digitCount; i++)
            {
                digits[digitCount - 1 - i] = (ushort)(number % 10);
                number /= 10;
            }
            return digits;
        }
    }
}
