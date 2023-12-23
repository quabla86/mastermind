using Mastermind.Game;
using Mastermind.Solver;
using System.Diagnostics;
using System.Text;

internal class Program
{
    private static InputParseService _parseService = new InputParseService();
    private static ISolver _solver = new ParallelSolver();

    private static void Main(string[] args)
    {
        Console.WriteLine("Enter Hints:");
        string input = ReadConsoleInput();

        Hints hints = _parseService.ParseHints(input);

        DateTime now = DateTime.Now;

        foreach (ushort[] solution in _solver.Solve(hints))
            Console.WriteLine(string.Concat(solution.Select(x => x.ToString())));

        var elapsedTime = DateTime.Now - now;
        Console.WriteLine("Calculation Time:" + elapsedTime.TotalMilliseconds);
        Console.Read();
    }

    private static string ReadConsoleInput()
    {
        string line;
        StringBuilder inputBuilder = new StringBuilder();
        while ((line = Console.ReadLine()) != string.Empty)
        {
            inputBuilder.AppendLine(line);
        }

        return inputBuilder.ToString();
    }
}