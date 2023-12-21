using Mastermind.Game;

public class InputParseService
{
    /// <summary>
    /// Parses the hint from sgtring
    /// </summary>
    /// <param name="input">in each line: digits, correctCount, occurenceCount
    /// 0123 1 1
    /// 4567 0 1
    /// 8901 0 1
    /// 5403 0 2;
    /// </param>
    /// <returns></returns>
    public Hints ParseHints(string input)
    {
        string[] lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        Hint[] hints = new Hint[lines.Length];

        for (int iHint = 0; iHint < lines.Length; iHint++)
        {
            string? line = lines[iHint];
            Hint hint = ParseHint(line);
            hints[iHint] = hint;
        }

        return new Hints(hints);
    }

    private Hint ParseHint(string line)
    {
        string[] parts = line.Split(new[] { ' ' });
        string digitString = parts[0];

        ushort[] digits = new ushort[digitString.Length];
        for (int i = 0; i < digitString.Length; i++)
            digits[i] = ushort.Parse(digitString.Substring(i, 1));

        int correctCount = int.Parse(parts[parts.Length - 2]);
        int occurenceCount = int.Parse(parts[parts.Length - 1]);

        Hint row = new(digits, correctCount, occurenceCount);
        return row;
    }
}