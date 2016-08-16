using UnityEngine;

namespace UnityCursorControl
{

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

        /// <summary>
        /// Simulates a left mouse down event, immediately followed by a left mouse up event
        /// </summary>
        void SimulateLeftClick();

        /// <summary>
        /// Simulates a middle mouse down event, immediately followed by a middle mouse up event
        /// </summary>
        void SimulateMiddleClick();

        /// <summary>
        /// Simulates a right mouse down event, immediately followed by a right mouse up event
        /// </summary>
        void SimulateRightClick();

    }

}
