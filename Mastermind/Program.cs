using Mastermind.Game;
using System.Text;

Console.WriteLine("Enter Hints:");
string line;
StringBuilder inputBuilder = new StringBuilder();
while( (line = Console.ReadLine()) != String.Empty)
{
    inputBuilder.AppendLine(line);
}

var parseService = new InputParseService();
Hints hints = parseService.ParseHints(inputBuilder.ToString());

Game game = new Game();
var solutions = game.Solve(hints);

foreach (ushort[] solution in solutions)
    Console.WriteLine(string.Concat(solution.Select(x => x.ToString())));

Console.WriteLine("");
