using Microsoft.Xna.Framework.Media;
using PauloPong.Core.Scenes;
using PauloPong.Library;

namespace PauloPong
{
    public class Game1 : BaseGame
    {
        private Song _themeSong;

        public Game1() : base("Paulo's Pong", 1280, 720, false)
        {

        }

        protected override void LoadContent()
        {
           // _themeSong = Content.Load<Song>("audios/theme");

            base.LoadContent();
        }

        protected override void Initialize()
        {
            //At the end, the initialize execute LoadContent
            base.Initialize();

            //Audio.PlaySong(_themeSong);
            ChangeScene(new MainScene());
        }
    }
}
