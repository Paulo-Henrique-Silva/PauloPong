using Microsoft.Xna.Framework;
using PauloPong.Library;
using PauloPong.Library.GameObjects;
using PauloPong.Library.Graphics;

namespace PauloPong.Core.GameObjects
{
    /// <summary>
    /// Represents a player character
    /// </summary>
    public class Player : BaseGameObject
    {
        private const float MOVEMENT_SPEED = 11.0f;

        public Player(Sprite sprite, Vector2 position) : base(sprite, position)
        {
        }

        public override void Update(GameTime time)
        {
            MovePlayer();
            PreventCollision();
        }

        /// <summary>
        /// Move the players, up and down.
        /// </summary>
        private void MovePlayer()
        {
            if (GameController.IsMoveUp())
            {
                position.Y -= MOVEMENT_SPEED;
            }

            if (GameController.IsMoveDown())
            {
                position.Y += MOVEMENT_SPEED;
            }
        }

        /// <summary>
        /// Prevent the player to be out the bounds.
        /// </summary>
        private void PreventCollision()
        {
            if (Top <= BaseGame.ScreenBounds.Top)
            {
                position.Y = BaseGame.ScreenBounds.Top;
            }

            //The real bottom position of the player is Y + height of the sprite
            if (Bottom >= BaseGame.ScreenBounds.Bottom)
            {
                position.Y = BaseGame.ScreenBounds.Bottom - sprite.Height;
            }
        }
    }
}
