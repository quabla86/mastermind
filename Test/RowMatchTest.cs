using Mastermind;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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

    public class RowMatchTest
    {
        [TestMethod]
        public void RowMatchTest12203()
        {

            var row = new Row(new ushort[] { 1,2, 2, 0, 3 }, 5, 0);
            Assert.IsTrue(row.DoesPhraseMath(_guess12203));
        }

        [TestMethod]
        public void RowMatchTest29934()
        {

            var row = new Row(new ushort[] { 2, 9, 9, 3, 4 }, 0, 2);
            Assert.IsTrue(row.DoesPhraseMath(_guess12203));
        }
        [TestMethod]
        public void RowMatchTest29904()
        {

            var row = new Row(new ushort[] { 2, 9, 9, 0, 4 }, 1, 1);
            Assert.IsTrue(row.DoesPhraseMath(_guess12203));
        }
        [TestMethod]
        public void RowMatchTest29922()
        {

            var row = new Row(new ushort[] { 2, 9, 9, 2, 2 }, 0, 2);
            Assert.IsTrue(row.DoesPhraseMath(_guess12203));
        }
        [TestMethod]
        public void RowMatchTest22024()
        {

            var row = new Row(new ushort[] { 2, 2, 0, 2, 4 }, 1, 2);
            Assert.IsTrue(row.DoesPhraseMath(_guess12203));
        }
        ushort[] _guess12203 = new ushort[] { 1, 2, 2, 0, 3 };

    }
}