namespace Mastermind
{
    public class Hints
    {
        public readonly Row[] Rows;
        public readonly int RowDigitCount;

        public Hints(Row[] rows)
        {
            var rowLength = rows.Select(row => row.Digits.Length).Distinct().ToList();
            
            if (rowLength.Count > 1)
                throw new ArgumentException("all rows must have the same count of digits");
            Rows = rows;
            RowDigitCount = rowLength.FirstOrDefault();
        }
        public bool Matches(ushort[] guessPhrase)
        {
            return Rows.All(row => row.DoesPhraseMath(guessPhrase));
        }
    }
}
