using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind.Game
{
    public class Hint
    {

        /// <summary>
        /// 0-9
        /// </summary>
        public readonly ushort[] Digits;

        /// <summary>
        /// Count of Digits that are at the correct Position in the Guessphrase
        /// </summary>
        public readonly int CorrectCount;

        /// <summary>
        /// Count of Digits that are not at the correct Position but exist in the Guessphrase
        /// One digit can at max contribute as the occurence count in the guessphase
        /// </summary>
        public readonly int Correctoccurence;
        public Hint(ushort[] digits, int correctCount, int correctoccurence)
        {
            Digits = digits;
            CorrectCount = correctCount;
            Correctoccurence = correctoccurence;
        }

        ///<summary>
        /// if the phrase is 12203
        /// 29934 -> (0,2)
        /// 29904 -> (1,1)
        /// 29922 -> (0,2)
        /// 22024 -> (1,2) 
        /// 12203 -> (5,0) 
        /// </summary>
        public bool DoesPhraseMatch(ushort[] guessPhrase)
        {
            int digitCount = Digits.Length;
            if (digitCount != guessPhrase.Length)
                throw new ArgumentException("the phrase length must math the digits length");

            bool[] isDigitPositionEvaluated = new bool[digitCount];
            bool[] isPhrasePositionEvaluated = new bool[digitCount];
            
            int correctCount = 0;
            int correctoccurence = 0;

            for (int iPhrase = 0; iPhrase < digitCount; iPhrase++)
            {
                ushort currPhraseDigit = guessPhrase[iPhrase];
                if (currPhraseDigit == Digits[iPhrase])
                {
                    correctCount++;
                    isDigitPositionEvaluated[iPhrase] = true;
                    isPhrasePositionEvaluated[iPhrase] = true;
                }
            }

            IEnumerable<int> notEvaluatedPhrasePositions = Enumerable.Range(0, digitCount)
                .Where(iPhrase => !isPhrasePositionEvaluated[iPhrase]);
            
            foreach (var iPhrase in notEvaluatedPhrasePositions)
            {
                ushort currPhraseDigit = guessPhrase[iPhrase];
                IEnumerable<int> notEvaluatedDigitPositions = Enumerable.Range(0, digitCount).Where(iDigit => !isDigitPositionEvaluated[iDigit]);
                
                foreach (var iDigit in notEvaluatedDigitPositions)
                {
                    ushort currDigit = Digits[iDigit];

                    if (currPhraseDigit != currDigit)
                        continue;

                    isDigitPositionEvaluated[iDigit] = true;
                    correctoccurence++;
                    break;
                }
            }
            return correctCount == CorrectCount && correctoccurence == Correctoccurence;
        }
    }

}
