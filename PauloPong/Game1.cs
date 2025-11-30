using Microsoft.Xna.Framework;
using MonoGameGum;
using PauloPong.Core.Scenes;
using PauloPong.Library;

namespace PauloPong
{
    public class Game1 : BaseGame
    {
        public Game1() : base("Paulo's Pong", 1280, 720, false)
        {

        }

        protected override void LoadContent()
        {
            //_themeSong = Content.Load<Song>("audios/theme-music");

            base.LoadContent();
        }

        protected override void Initialize()
        {
            //At the end, the initialize execute LoadContent
            base.Initialize();

            GumService.Default.Initialize(this, "GumProject/PongGumProject.gumx");
            ChangeScene(new MainScene());
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            GumService.Default.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GumService.Default.Draw();
        }
    }
}
