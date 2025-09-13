using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PauloPong.Core.GameObjects;
using PauloPong.Library;
using PauloPong.Library.GameObjects;
using PauloPong.Library.Graphics;
using PauloPong.Library.Scenes;
using System.Net;

namespace PauloPong.Core.Scenes
{
    /// <summary>
    /// Where the game occurs.
    /// </summary>
    public class MainScene : Scene
    {
        private Player _player1;

        private Player _player2;

        private Ball _ball;

        //MainScene default attributes
        private const int DISTANCE_FROM_BOUND = 200;
        private const int PLAYER_HEIGHT = 100;
        private const int PLAYER_WIDTH = 25;
        private const int BALL_SIZE = 15;
        private const float PLAYER2_SPEED = 6.5f;

        /*
         * TODO
         *  - Add a Score System and a straight vertical line in the middle of the field 
         *  - Do not set random direction every time the ball hits the horizontal walls. It Should bounce foward the opposite side of the last player who hit it.
         *  - Add a custom logic every time a ball hits the superior and bottom bounds of the player.
         *  - Add soundeffects.
         *  - Add PvP and PvC modes.
         *  - Add difficulty modes for PvC.
         *  - Add a Custom Menu with GUM
         *  - Release.
         */

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Initialize()
        {
            base.Initialize();

            BaseGame.ExitOnEscape = true;

            //the Y coordinate of the screen center is half of the screen height minus half of the sprite height.
            float playerCenterOfTheScreen = BaseGame.GetYCenterRelativeToSprite(PLAYER_HEIGHT);
            Vector2 ballPosition = BaseGame.GetScreenCenterRelativeToSprite(BALL_SIZE, BALL_SIZE);

            SimplifiedSprite playerSprite = new SimplifiedSprite(Color.White, PLAYER_WIDTH, PLAYER_HEIGHT);
            SimplifiedSprite ballSprite = new SimplifiedSprite(Color.White, BALL_SIZE, BALL_SIZE);

            _player1 = new Player(playerSprite, new Vector2(DISTANCE_FROM_BOUND, playerCenterOfTheScreen));
            _player2 = new Player(playerSprite, new Vector2(BaseGame.ScreenWidth - DISTANCE_FROM_BOUND, playerCenterOfTheScreen));
            _ball = new Ball(ballSprite, ballPosition);
        }

        public override void Update(GameTime gameTime)
        {
            _player1.Update(gameTime);
            MovePlayer2(gameTime);
            _ball.Update(gameTime);

            CollisionChecks();
            ValidateGameOver();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            BaseGame.GraphicsDevice.Clear(new Color(34, 34, 34));

            BaseGame.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _player1.Draw();
            _player2.Draw();
            _ball.Draw();
            BaseGame.SpriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// If the ball hits a players, set a new direction pointing to the oposite side (bounce).
        /// </summary>
        private void CollisionChecks()
        {
            Rectangle ballBounds = _ball.GetRectagleBounds();
            Rectangle player1Bounds = _player1.GetRectagleBounds();
            Rectangle player2Bounds = _player2.GetRectagleBounds();

            if (ballBounds.Intersects(player1Bounds))
            {
                _ball.Bounce(Vector2Helper.Right, true);
            }

            if (ballBounds.Intersects(player2Bounds))
            {
                _ball.Bounce(Vector2Helper.Left, true);
            }
        }

        /// <summary>
        /// Validate if it a game over to the game
        /// </summary>
        private void ValidateGameOver()
        {
            if (_ball.Left <= BaseGame.ScreenBounds.Left || _ball.Right >= BaseGame.ScreenBounds.Right)
            {
                GameOver();
            }
        }
        
        /// <summary>
        /// Sets the sprites in the default positions.
        /// </summary>
        private void GameOver()
        {
            float playerCenterOfTheScreen = BaseGame.GetYCenterRelativeToSprite(PLAYER_HEIGHT);

            _player1.position.Y = playerCenterOfTheScreen;
            _player2.position.Y = playerCenterOfTheScreen;
            _ball.position = BaseGame.GetScreenCenterRelativeToSprite(BALL_SIZE, BALL_SIZE);

            _ball.ResetBall();
        }

        /// <summary>
        /// Moves player 2 - Player 2 AI.
        /// </summary>
        private void MovePlayer2(GameTime gameTime)
        {
            float targetYPosition = _ball.position.Y - _player2.sprite.Height * 0.5f;

            //Moves the player 2 fowards the ball based in a velocity.
            if (targetYPosition < _player2.position.Y)
            {
                //Avoid flickering by no reducing or adding more than needed.
                if ((_player2.position.Y - targetYPosition) < PLAYER2_SPEED)
                {
                    _player2.position.Y = targetYPosition;
                }
                else
                {
                    _player2.position.Y -= PLAYER2_SPEED;
                }
            }

            if (targetYPosition > _player2.position.Y)
            {
                if ((_player2.position.Y + targetYPosition) > PLAYER2_SPEED)
                {
                    _player2.position.Y = targetYPosition;
                }
                else
                {
                    _player2.position.Y += PLAYER2_SPEED;
                }
            }

            //Bounds - Avoid Collision
            if (_player2.Top <= BaseGame.ScreenBounds.Top)
            {
                _player2.position.Y = BaseGame.ScreenBounds.Top;
            }

            //The real bottom position of the player is Y + height of the sprite
            if (_player2.Bottom >= BaseGame.ScreenBounds.Bottom)
            {
                _player2.position.Y = BaseGame.ScreenBounds.Bottom - _player2.sprite.Height;
            }
        }
    }
}
