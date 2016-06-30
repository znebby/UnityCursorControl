using UnityEngine;
using System.Runtime.InteropServices;

/// <summary>
/// Implements the ICursorControl interface for the Windows platform
/// </summary>
internal class CursorControlWindows: ICursorControl {

    /// <summary>
    /// Point struct needed to get the cursor position from the user32.dll
    /// </summary>
    private struct Point
    {
        public int X;
        public int Y;
    }

    /// <summary>
    /// Sets the global cursor position using the windows user32.dll
    /// </summary>
    /// <param name="X">Global cursor X position</param>
    /// <param name="Y">Global cursor Y position</param>
    [DllImport("user32.dll")]
    private static extern bool SetCursorPos(int X, int Y);
    /// <summary>
    /// Gets the global cursor position using the windows user32.dll
    /// </summary>
    /// <param name="pos">The Point object to save the position into</param>
    [DllImport("user32.dll")]
    private static extern bool GetCursorPos(out Point pos);

    /// <summary>
    /// Converts a local cursor position to a global cursor position
    /// </summary>
    private Vector2 LocalToGlobal(Vector2 pos)
    {
        Vector2 localPos = Input.mousePosition;
        Vector2 globalPos = GetGlobalCursorPos();
        int xOffset = (int)globalPos.x - (int)localPos.x;
        // Unity calculates cursor position from the bottom left corner, whereas windows uses the top left corner
        localPos.y = Screen.height - localPos.y;
        int yOffset = (int)globalPos.y - (int)localPos.y;

        return new Vector2(pos.x + xOffset, Screen.height - pos.y + yOffset);
    }

    public Vector2 GetGlobalCursorPos()
    {
        Point pos;
        GetCursorPos(out pos);
        return new Vector2(pos.X, pos.Y);
    }

    public void SetGlobalCursorPos(Vector2 pos)
    {
        SetCursorPos((int)pos.x, (int)pos.y);
    }

    public void SetLocalCursorPos(Vector2 pos)
    {
        pos = LocalToGlobal(pos);
        SetCursorPos((int)pos.x, (int)pos.y);
    }

}
