using Mastermind.Game;

namespace Test
{
    [TestClass]
    public class HintsMatchTest
    {
        [TestMethod]
        public void Test1()
        {
            Hint[] rows = new[]
            {
                new Hint(new ushort[] { 6, 8, 2 }, 1, 0),
                new Hint(new ushort[] { 6, 1, 4 }, 0, 1),
                new Hint(new ushort[] { 2, 0, 6 }, 0, 2),
                new Hint(new ushort[] { 7, 3, 8 }, 0, 0),
                new Hint(new ushort[] { 3, 8, 0 }, 0, 1),
            };
            Hints hints = new Hints(rows);
            Assert.IsTrue(hints.Matches(new ushort[] { 0, 4, 2 }));
        }
        [TestMethod]
        public void Test2()
        {
            Hint[] rows = new Hint[]
            {
                new Hint(new ushort[] { 7, 3, 2, 5 }, 0, 2),
                new Hint(new ushort[] { 1, 9, 7, 3 }, 0, 1),
                new Hint(new ushort[] { 8, 2, 4,7 }, 0, 1),
                new Hint(new ushort[] { 3, 8, 5,0 }, 1, 1),
                new Hint(new ushort[] { 2, 0, 3,0 }, 0, 2),
            };


            Hints hints = new Hints(rows);
            Assert.IsTrue(hints.Matches(new ushort[] { 0, 1,5, 2 }));
        }
    }
}