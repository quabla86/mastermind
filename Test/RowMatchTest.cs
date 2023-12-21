using Mastermind;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Mastermind.Game;
namespace Test
{
    [TestClass]
    ///<summary>
    /// if the Guesspharase is 12203
    /// 29934 -> (0,2)
    /// 29904 -> (1,1)
    /// 29922 -> (0,2)
    /// 22024 -> (1,2) 
    /// 12203 -> (5,0) 
    /// </summary>

    public class HintMatchTest
    {
        [TestMethod]
        public void HintMatchTest12203()
        {

            var Hint = new Hint(new ushort[] { 1,2, 2, 0, 3 }, 5, 0);
            Assert.IsTrue(Hint.DoesPhraseMatch(_guess12203));
        }

        [TestMethod]
        public void HintMatchTest29934()
        {

            var Hint = new Hint(new ushort[] { 2, 9, 9, 3, 4 }, 0, 2);
            Assert.IsTrue(Hint.DoesPhraseMatch(_guess12203));
        }
        [TestMethod]
        public void HintMatchTest29904()
        {

            var Hint = new Hint(new ushort[] { 2, 9, 9, 0, 4 }, 1, 1);
            Assert.IsTrue(Hint.DoesPhraseMatch(_guess12203));
        }
        [TestMethod]
        public void HintMatchTest29922()
        {

            var Hint = new Hint(new ushort[] { 2, 9, 9, 2, 2 }, 0, 2);
            Assert.IsTrue(Hint.DoesPhraseMatch(_guess12203));
        }
        [TestMethod]
        public void HintMatchTest22024()
        {

            var Hint = new Hint(new ushort[] { 2, 2, 0, 2, 4 }, 1, 2);
            Assert.IsTrue(Hint.DoesPhraseMatch(_guess12203));
        }
        ushort[] _guess12203 = new ushort[] { 1, 2, 2, 0, 3 };

    }
}