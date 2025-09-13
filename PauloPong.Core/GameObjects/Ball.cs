using Microsoft.Xna.Framework;
using PauloPong.Library;
using PauloPong.Library.GameObjects;
using PauloPong.Library.Graphics;
using System;

namespace PauloPong.Core.GameObjects
{
    public class Ball : BaseGameObject
    {
        private float _speed = 6.0f;

        private Vector2 _direction = new Vector2(-1, 0);

        public Ball(Sprite sprite, Vector2 position) : base(sprite, position)
        {
        }

        public override void Update(GameTime time)
        {
            MoveBall();
            PreventCollision();
        }

        /// <summary>
        /// Sets the direction of the Ball and increase the speed.
        /// </summary>
        /// <param name="normal"></param>
        public void SetNewDirection(Vector2 normal)
        {
            Random random = new Random();
            float maxAngle = MathHelper.ToRadians(15); 
            float angleOffset = (float)(random.NextDouble() * 2 - 1) * maxAngle;

            float cos = (float)Math.Cos(angleOffset);
            float sin = (float)Math.Sin(angleOffset);

            Vector2 rotatedNormal = new Vector2(
                normal.X * cos - normal.Y * sin,
                normal.X * sin + normal.Y * cos
            );

            _direction = Vector2.Reflect(_direction, rotatedNormal);
            _speed += 0.5f;
        }

        private void MoveBall()
        {
            position += _direction * _speed;
        }

        private void PreventCollision()
        {
            if (Top <= BaseGame.ScreenBounds.Top)
            {
                position.Y = BaseGame.ScreenBounds.Top;
                SetNewDirection(new Vector2(0, 1));
            }

            //The real bottom position is Y + height of the sprite
            if (Bottom >= BaseGame.ScreenBounds.Bottom)
            {
                position.Y = BaseGame.ScreenBounds.Bottom - sprite.Height;
                SetNewDirection(new Vector2(0, -1));
            }
        }
    }
}
