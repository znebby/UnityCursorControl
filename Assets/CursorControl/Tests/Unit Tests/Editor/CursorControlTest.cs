using UnityEngine;
using NUnit.Framework;

namespace UnityCursorControl
{

    /// <summary>
    /// Unit tests for CursorControl class
    /// </summary>
    [TestFixture]
    public class CursorControlTest
    {

        /// <summary>
        /// Stores the initial cursor position
        /// </summary>
        private Vector2 _cursorPos;

        /// <summary>
        /// Remembers the cursor position before the tests are run
        /// </summary>
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _cursorPos = CursorControl.GetGlobalCursorPos();
        }

        /// <summary>
        /// Sets the cursor position back to its original position after the tests are run
        /// </summary>
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            CursorControl.SetGlobalCursorPos(_cursorPos);
        }

        /// <summary>
        /// Tests GetGlobalCursorPos() and SetGlobalCursorPos()
        /// </summary>
        [Test]
        public void GlobalPosTest()
        {
            Vector2 pos = new Vector2(100, 200);
            CursorControl.SetGlobalCursorPos(pos);
            Assert.AreEqual(pos, CursorControl.GetGlobalCursorPos());
        }

        /// <summary>
        /// Tests SetLocalCursorPos()
        /// </summary>
        /// <remarks>
        /// This test should pass in theory. However, when using the Unity editor test runner,
        /// the game window is not in focus and therefore Input.mousePosition does not update.
        /// Therefore, I have left the test in but commented it out.
        /// </remarks>
        //[Test]
        //public void LocalPosTest()
        //{
        //    Vector2 pos = new Vector2(100, 200);
        //    CursorControl.SetLocalCursorPos(pos);
        //    Assert.AreEqual(pos, (Vector2)Input.mousePosition);
        //}
    }

}
