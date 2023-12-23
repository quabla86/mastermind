using System.Linq;

namespace Mastermind.Game
{
    public class Hints
    {
        private readonly Hint[] _rows;
        public readonly int Count;

        public IReadOnlyList<Hint> Rows => _rows;

        public Hints(IEnumerable<Hint> rows) : this(rows.ToArray())
        {

        }
        public Hints(IReadOnlyList<Hint> rows)
        {
            _rows = rows.ToArray();
            var rowLength = rows.Select(row => row.Digits.Length).Distinct().ToList();

            if (rowLength.Count > 1)
                throw new ArgumentException("all rows must have the same count of digits");

            Count = rowLength.FirstOrDefault();
        }
        public bool Matches(ushort[] guessPhrase)
        {
            foreach (var hint in _rows)
            {
                if(!hint.DoesPhraseMatch(guessPhrase)) 
                    return false;
            }
            return true;
        }
    }
}