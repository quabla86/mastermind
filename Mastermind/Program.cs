using Mastermind;
using System.ComponentModel.Design.Serialization;


Row[] rows = new Row[]
{
    new Row(new ushort[] { 0, 1, 2, 3 }, 1, 1),
    new Row(new ushort[] { 4, 5, 6, 7 }, 0, 1),
    new Row(new ushort[] { 8, 9, 0,1 }, 0, 1),
    new Row(new ushort[] { 5, 4, 0,3 }, 0, 2)
};


Game game = new Game();

Hints hint = new Hints(rows.ToArray());
var solutions = game.Solve(hint);

foreach (ushort[] solution in solutions)
    Console.WriteLine(string.Concat(solution.Select(x => x.ToString())));

Console.WriteLine("");