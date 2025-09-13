using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PauloPong.Library.Graphics
{
    /// <summary>
    /// This class is used to create simple colored rectagles to test sprite position and size.
    /// </summary>
    public class SimplifiedSprite : Sprite
    {
        public SimplifiedSprite(Color color, int width, int height) 
        {
            Texture2D texture2D = new Texture2D(BaseGame.GraphicsDevice, 1, 1);
            texture2D.SetData([color]);

            Region = new TextureRegion(texture2D, 0, 0, width, height);
        }
    }
}
