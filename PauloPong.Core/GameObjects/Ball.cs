using Microsoft.Xna.Framework;
using PauloPong.Library;
using PauloPong.Library.GameObjects;
using PauloPong.Library.Graphics;
using System;

namespace PauloPong.Core.GameObjects
{
    /// <summary>
    /// Pong game ball object
    /// </summary>
    public class Ball : BaseGameObject
    {
        private float _speed = 6.0f;

        private Vector2 _direction = Vector2Helper.Left;

        public Action OnBallHitWalls;

        public Ball(Sprite sprite, Vector2 position) : base(sprite, position)
        {
        }

        public override void Update(GameTime time)
        {
            MoveBall();
            PreventCollision();
        }

        /// <summary>
        /// Sets the direction of the Ball and optionally increase the speed.
        /// </summary>
        /// <param name="normal"></param>
        public void Bounce(Vector2 normal, bool increaseSpeed)
        {
            //set a random angle to the angle
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

            if (increaseSpeed)
            {
                _speed += 0.5f;
            }
        }

        /// <summary>
        /// Reset ball direction and speed
        /// </summary>
        public void ResetBall()
        {
            _direction = Vector2Helper.Left;
            _speed = 6.0f;
        }

        /// <summary>
        /// Move the ball based in its current direction and speed.
        /// </summary>
        private void MoveBall()
        {
            position += _direction * _speed;
        }

        /// <summary>
        /// Prevent collision with the game walls and set a new direction to ball (bouce).
        /// </summary>
        private void PreventCollision()
        {
            if (Top <= BaseGame.ScreenBounds.Top)
            {
                position.Y = BaseGame.ScreenBounds.Top;
                Bounce(Vector2Helper.Down, false);
                OnBallHitWalls?.Invoke();
            }

            //The real bottom position is Y + height of the sprite
            if (Bottom >= BaseGame.ScreenBounds.Bottom)
            {
                position.Y = BaseGame.ScreenBounds.Bottom - sprite.Height;
                Bounce(Vector2Helper.Up, false);
                OnBallHitWalls?.Invoke();
            }
        }
    }
}
