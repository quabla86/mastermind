using Mastermind;

namespace Test
{
    [TestClass]
    public class HintMatchTest
    {
        [TestMethod]
        public void Test1()
        {
            Row[] rows = new[]
            {
                new Row(new ushort[] { 6, 8, 2 }, 1, 0),
                new Row(new ushort[] { 6, 1, 4 }, 0, 1),
                new Row(new ushort[] { 2, 0, 6 }, 0, 2),
                new Row(new ushort[] { 7, 3, 8 }, 0, 0),
                new Row(new ushort[] { 3, 8, 0 }, 0, 1),
            };
            Hints hints = new Hints(rows);
            Assert.IsTrue(hints.Matches(new ushort[] { 0, 4, 2 }));
        }
        [TestMethod]
        public void Test2()
        {
            Row[] rows = new Row[]
            {
                new Row(new ushort[] { 7, 3, 2, 5 }, 0, 2),
                new Row(new ushort[] { 1, 9, 7, 3 }, 0, 1),
                new Row(new ushort[] { 8, 2, 4,7 }, 0, 1),
                new Row(new ushort[] { 3, 8, 5,0 }, 1, 1),
                new Row(new ushort[] { 2, 0, 3,0 }, 0, 2),
            };


            Hints hints = new Hints(rows);
            Assert.IsTrue(hints.Matches(new ushort[] { 0, 1,5, 2 }));
        }
    }
}