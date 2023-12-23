using Mastermind.Game;
using System.Diagnostics;
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
DateTime now = DateTime.Now;
var solutions = game.Solve(hints);

foreach (ushort[] solution in solutions)
    Console.WriteLine(string.Concat(solution.Select(x => x.ToString())));
var elapsedTime = DateTime.Now - now;
Console.WriteLine("Calculation Time:" + elapsedTime.TotalMilliseconds);
Console.WriteLine("");

