using UnityEngine;

/// <summary>
/// Interface that should be implemented when adding CursorControl functionality to a new platform
/// </summary>
internal interface ICursorControl
{

    /// <summary>
    /// Gets the global cursor position, relative to the OS
    /// </summary>
    Vector2 GetGlobalCursorPos();

    /// <summary>
    /// Sets the global cursor position, relative to the OS
    /// </summary>
    void SetGlobalCursorPos(Vector2 pos);

    /// <summary>
    /// Sets the local cursor position, relative to the Unity game window
    /// </summary>
    void SetLocalCursorPos(Vector2 pos);

}
