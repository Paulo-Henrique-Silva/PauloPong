using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PauloPong.Library;
using PauloPong.Library.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PauloPong.Core
{
    /// <summary>
    /// Encapsulates the game controller logic
    /// </summary>
    public class GameController
    {
        private static KeyboardInfo Keyboard => BaseGame.Input.Keyboard;

        /// <summary>
        /// Returns true if the player has triggered the "move up" action.
        /// </summary>
        public static bool IsWPressed()
        {
            return Keyboard.IsKeyDown(Keys.W);
        }

        /// <summary>
        /// Returns true if the player has triggered the "move up" action with arrow.
        /// </summary>
        public static bool IsArrowUp()
        {
            return Keyboard.IsKeyDown(Keys.Up);
        }

        /// <summary>
        /// Returns true if the player has triggered the "move down" action.
        /// </summary>
        public static bool IsSPressed()
        {
            return Keyboard.IsKeyDown(Keys.S);
        }

        /// <summary>
        /// Returns true if the player has triggered the "move down" action with arrow.
        /// </summary>
        public static bool IsArrowDown()
        {
            return Keyboard.IsKeyDown(Keys.Down);
        }

        /// <summary>
        /// Returns true if the player has triggered the "pause" action.
        /// </summary>
        public static bool IsPause()
        {
            return Keyboard.WasKeyJustPressed(Keys.Escape);
        }
    }
}
