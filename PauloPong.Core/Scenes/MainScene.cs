using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PauloPong.Core.GameObjects;
using PauloPong.Library;
using PauloPong.Library.Graphics;
using PauloPong.Library.Scenes;

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

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Initialize()
        {
            base.Initialize();

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
            _ball.Update(gameTime);
            MovePlayer2();

            CollisionChecks();

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

        private void CollisionChecks()
        {
            Rectangle ballBounds = _ball.GetRectagleBounds();
            Rectangle player1Bounds = _player1.GetRectagleBounds();
            Rectangle player2Bounds = _player2.GetRectagleBounds();

            if (ballBounds.Intersects(player1Bounds))
            {
                _ball.SetNewDirection(new Vector2(1, 0));
            }

            if (ballBounds.Intersects(player2Bounds))
            {
                _ball.SetNewDirection(new Vector2(-1, 0));
            }
        }

        private void MovePlayer2()
        {

        }

        private void GameOver()
        {

        }
    }
}
