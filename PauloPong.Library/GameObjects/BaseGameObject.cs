using Microsoft.Xna.Framework;
using PauloPong.Library.Graphics;

namespace PauloPong.Library.GameObjects
{
    /// <summary>
    /// Base game object class to represent players, enimies, houses, constructions etc...
    /// </summary>
    public abstract class BaseGameObject
    {
        /// <summary>
        /// Sprite used to represent visual of the entity.
        /// </summary>
        public Sprite sprite;

        /// <summary>
        /// The current position of the object in the screen bounds.
        /// </summary>
        public Vector2 position;

        #region Object Position attributes

        /// <summary>
        /// Returns Y coordiante of the object's position.
        /// </summary>
        public float Top => position.Y;

        /// <summary>
        /// Returns X coordiante of the object's position.
        /// </summary>
        public float Left => position.X;

        /// <summary>
        /// Returns Y coordiante of the object's position plus the sprite height.
        /// </summary>
        public float Bottom => position.Y + sprite.Height;

        /// <summary>
        /// Returns X coordiante of the object's position plus the sprite width.
        /// </summary>
        public float Right => position.X + sprite.Width;

        #endregion

        protected BaseGameObject(Sprite sprite, Vector2 position)
        {
            this.sprite = sprite;
            this.position = position;
        }

        /// <summary>
        /// Update logic for the game object. You must implement this method and create your own logic.
        /// </summary>
        /// <param name="time"></param>
        public abstract void Update(GameTime time);

        /// <summary>
        /// Basic method to draw the sprite in the GameObject current position. You may override this method if needed.
        /// </summary>
        public virtual void Draw()
        {
            sprite.Draw(BaseGame.SpriteBatch, position);
        }

        /// <summary>
        /// Returns a Circle value that represents collision bounds of the object.
        /// </summary>
        /// <returns>A Circle value.</returns>
        public Circle GetCircleBounds()
        {
            int x = (int)(position.X + sprite.Width * 0.5f);
            int y = (int)(position.Y + sprite.Height * 0.5f);
            int radius = (int)(sprite.Width * 0.25f);

            return new Circle(x, y, radius);
        }

        /// <summary>
        /// Returns a Rectagle value that represents collision bounds of the object.
        /// </summary>
        /// <returns>A Circle value.</returns>
        public Rectangle GetRectagleBounds()
        {
            int x = (int)position.X;
            int y = (int)position.Y;
            int width = (int)sprite.Width;
            int height = (int)sprite.Height;

            return new Rectangle(x, y, width, height);
        }
    }
}
