using UnityEngine;
using NUnit.Framework;

/// <summary>
/// Unit tests for CursorControl class
/// </summary>
public class CursorControlTest
{

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
