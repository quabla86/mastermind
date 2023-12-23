using Mastermind.Game;

namespace Mastermind.Solver
{
    public interface ISolver
    {
        IEnumerable<ushort[]> Solve(Hints hints);
    }
}