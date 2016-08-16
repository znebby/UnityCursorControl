using UnityEngine;
using UnityEngine.UI;

namespace UnityCursorControl
{

    /// <summary>
    /// An example script that accompanies the CursorControlExample scene
    /// </summary>
    public class CursorControlExample : MonoBehaviour
    {

        [SerializeField]
        private Text _globalPosText;
        [SerializeField]
        private Text _localPosText;
        [SerializeField]
        private InputField _xPos;
        [SerializeField]
        private InputField _yPos;

        private int _x, _y;
        private Vector2 _pos;

        private void Update()
        {
            UpdatePositionText();
            SimulateMouseClicks();
        }

        /// <summary>
        /// Updates the text fields with the current global and local cursor positions
        /// </summary>
        private void UpdatePositionText()
        {
            _globalPosText.text = "Global Cursor Position: " + CursorControl.GetGlobalCursorPos().ToString();
            _localPosText.text = "Local Cursor Position: " + ((Vector2)Input.mousePosition).ToString();
        }

        /// <summary>
        /// Simulates mouse clicks when keyboard buttons are pressed
        /// </summary>
        private void SimulateMouseClicks()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                CursorControl.SimulateLeftClick();
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                CursorControl.SimulateMiddleClick();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                CursorControl.SimulateRightClick();
            }
        }

        /// <summary>
        /// Attempts to parse the x and y position input fields as integers
        /// </summary>
        private bool TryParsePos()
        {
            if (int.TryParse(_xPos.text, out _x) && int.TryParse(_yPos.text, out _y))
            {
                _pos = new Vector2(_x, _y);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Sets the glocal cursor position to the current x and y position input fields
        /// </summary>
        public void SetGlocalCursorPos()
        {
            if (TryParsePos())
            {
                CursorControl.SetGlobalCursorPos(_pos);
            }
        }

        /// <summary>
        /// Sets the local cursor position to the current x and y position input fields
        /// </summary>
        public void SetLocalCursorPos()
        {
            if (TryParsePos())
            {
                CursorControl.SetLocalCursorPos(_pos);
            }
        }

    }

}
