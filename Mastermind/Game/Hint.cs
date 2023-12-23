using System;
using System.Collections;
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

        public int DigitCount { get; }

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
            DigitCount = Digits.Length;
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
            if (DigitCount != guessPhrase.Length)
                throw new ArgumentException("The phrase length must match the digits length");

            ushort isDigitPositionEvaluated = 0;
            ushort isPhrasePositionEvaluated = 0;

            int correctCount = 0;
            int correctoccurence = 0;

            for (int iPhrase = 0; iPhrase < DigitCount; iPhrase++)
            {
                ushort currPhraseDigit = guessPhrase[iPhrase];
                if (currPhraseDigit == Digits[iPhrase])
                {
                    correctCount++;
                    isDigitPositionEvaluated |= (ushort)(1 << iPhrase);
                    isPhrasePositionEvaluated |= (ushort)(1 << iPhrase);
                }
            }
            if (correctCount != CorrectCount)
                return false;

            for (int iPhrase = 0; iPhrase < DigitCount; iPhrase++)
            {
                if ((isPhrasePositionEvaluated & (1 << iPhrase)) != 0)
                    continue;

                ushort currPhraseDigit = guessPhrase[iPhrase];
                for (int iDigit = 0; iDigit < DigitCount; iDigit++)
                {
                    if ((isDigitPositionEvaluated & (1 << iDigit)) != 0)
                        continue;

                    ushort currDigit = Digits[iDigit];

                    if (currPhraseDigit != currDigit)
                        continue;

                    isDigitPositionEvaluated |= (ushort)(1 << iDigit);
                    correctoccurence++;
                    break;
                }
                if (correctoccurence > Correctoccurence)
                    return false;
            }
            return correctoccurence == Correctoccurence;
        }
    }

}
