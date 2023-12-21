using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{

    public class Row
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
        /// One digit can at max contribute as the occurance count in the guessphase
        /// </summary>
        public readonly int CorrectOccurance;
        public Row(ushort[] digits, int correctCount, int correctOccurance)
        {
            Digits = digits;
            CorrectCount = correctCount;
            CorrectOccurance = correctOccurance;
        }

        ///<summary>
        /// if the phrase is 12203
        /// 29934 -> (0,2)
        /// 29904 -> (1,1)
        /// 29922 -> (0,2)
        /// 22024 -> (1,2) 
        /// 12203 -> (5,0) 
        /// </summary>
        public bool DoesPhraseMath(ushort[] phrase)
        {
            int digitCount = Digits.Length;
            if (digitCount != phrase.Length)
                throw new ArgumentException("the phrase length must math the digits length");

            bool[] isPositionEvaluated = new bool[digitCount];
            bool[] isPhrasePositionEvaluated = new bool[digitCount];
            int correctCount = 0;
            int correctOccurance = 0;
            for (int iPhrase = 0; iPhrase < digitCount; iPhrase++)
            {
                ushort currPhraseDigit = phrase[iPhrase];
                if (currPhraseDigit == Digits[iPhrase])
                {
                    correctCount++;
                    isPositionEvaluated[iPhrase] = true;
                    isPhrasePositionEvaluated[iPhrase] = true;
                }
            }
            foreach (var iPhrase in Enumerable.Range(0, digitCount).Where(iPhrase => !isPhrasePositionEvaluated[iPhrase]))
            {
                ushort currPhraseDigit = phrase[iPhrase];
                foreach (var iDigit in Enumerable.Range(0, digitCount).Where(iDigit => !isPositionEvaluated[iDigit]))
                {
                    ushort currDigit = Digits[iDigit];

                    if (currPhraseDigit != currDigit)
                        continue;

                    isPositionEvaluated[iDigit] = true;
                    correctOccurance++;
                    break;
                }
            }
            return (correctCount == CorrectCount && correctOccurance == CorrectOccurance);
        }

    }

}
