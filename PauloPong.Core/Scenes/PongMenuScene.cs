using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameGum;
using PauloPong.Library;
using PauloPong.Library.Scenes;
using PauloPong_Core.Screens;

namespace PauloPong.Core.Scenes
{
    /// <summary>
    /// Game Menu Scene
    /// </summary>
    public class PongMenuScene : Scene
    {
        private PongMenuScreen _screen;

        public override void LoadContent()
        {
            base.LoadContent();

            //Add Content Here
        }

        public override void Initialize()
        {
            base.Initialize();

            //Initialize UI screen
            _screen = new PongMenuScreen();
            _screen.AddToRoot();

            _screen.btnPvC.Click += (s, e) => BaseGame.ChangeScene(new MainScene(false));
            _screen.btnPvP.Click += (s, e) => BaseGame.ChangeScene(new MainScene(true));
            _screen.btnExit.Click += (s, e) => BaseGame.ExitGame();
        }

        public override void Update(GameTime gameTime)
        {
            //Update Game logic here

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            //Draw Sprites
            BaseGame.GraphicsDevice.Clear(new Color(34, 34, 34));

            BaseGame.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
            BaseGame.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
