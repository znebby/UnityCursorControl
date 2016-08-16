using UnityEngine;
using System;
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
    /// Enum of mouse event flags, used by the mouse_event function
    /// </summary>
    [Flags]
    private enum MouseEventFlags
    {
        MOUSEEVENTF_ABSOLUTE = 0x8000,
        MOUSEEVENTF_LEFTDOWN = 0x0002,
        MOUSEEVENTF_LEFTUP = 0x0004,
        MOUSEEVENTF_MIDDLEDOWN = 0x0020,
        MOUSEEVENTF_MIDDLEUP = 0x0040,
        MOUSEEVENTF_MOVE = 0x0001,
        MOUSEEVENTF_RIGHTDOWN = 0x0008,
        MOUSEEVENTF_RIGHTUP = 0x0010,
        MOUSEEVENTF_XDOWN = 0x0080,
        MOUSEEVENTF_XUP = 0x0100,
        MOUSEEVENTF_WHEEL = 0x0800,
        MOUSEEVENTF_HWHEEL = 0x01000
    }

    /// <summary>
    /// Sets the global cursor position using the windows user32.dll
    /// </summary>
    /// <param name="X">Global cursor X position</param>
    /// <param name="Y">Global cursor Y position</param>
    /// <remarks>
    /// see https://msdn.microsoft.com/en-us/library/windows/desktop/ms648394(v=vs.85).aspx
    /// </remarks>
    [DllImport("user32.dll")]
    private static extern bool SetCursorPos(int X, int Y);

    /// <summary>
    /// Gets the global cursor position using the windows user32.dll
    /// </summary>
    /// <param name="pos">The Point object to save the position into</param>
    /// <remarks>
    /// see https://msdn.microsoft.com/en-us/library/windows/desktop/ms648390(v=vs.85).aspx
    /// </remarks>
    [DllImport("user32.dll")]
    private static extern bool GetCursorPos(out Point pos);

    /// <summary>
    /// Sends a mouse event using the windows user32.dll
    /// </summary>
    /// <param name="dwFlags">A flag to indicate the event type, see MouseEventFlags enum</param>
    /// <param name="dx">The x position of the mouse event</param>
    /// <param name="dy">The y position of the mouse event</param>
    /// <param name="dwData">Data for mouse wheel and X button events</param>
    /// <param name="dwExtraInfo">Any additional value associated with mouse event</param>
    /// <remarks>
    /// see https://msdn.microsoft.com/en-us/library/windows/desktop/ms646260(v=vs.85).aspx
    /// </remarks>
    [DllImport("user32.dll")]
    private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

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

    public void SimulateLeftClick()
    {
        mouse_event((uint)MouseEventFlags.MOUSEEVENTF_LEFTDOWN,
         (uint)GetGlobalCursorPos().x, (uint)GetGlobalCursorPos().y, 0, UIntPtr.Zero);
        mouse_event((uint)MouseEventFlags.MOUSEEVENTF_LEFTUP,
         (uint)GetGlobalCursorPos().x, (uint)GetGlobalCursorPos().y, 0, UIntPtr.Zero);
    }

    public void SimulateMiddleClick()
    {
        mouse_event((uint)MouseEventFlags.MOUSEEVENTF_MIDDLEDOWN,
         (uint)GetGlobalCursorPos().x, (uint)GetGlobalCursorPos().y, 0, UIntPtr.Zero);
        mouse_event((uint)MouseEventFlags.MOUSEEVENTF_MIDDLEUP,
         (uint)GetGlobalCursorPos().x, (uint)GetGlobalCursorPos().y, 0, UIntPtr.Zero);
    }

    public void SimulateRightClick()
    {
        mouse_event((uint)MouseEventFlags.MOUSEEVENTF_RIGHTDOWN,
         (uint)GetGlobalCursorPos().x, (uint)GetGlobalCursorPos().y, 0, UIntPtr.Zero);
        mouse_event((uint)MouseEventFlags.MOUSEEVENTF_RIGHTUP,
         (uint)GetGlobalCursorPos().x, (uint)GetGlobalCursorPos().y, 0, UIntPtr.Zero);
    }

}
