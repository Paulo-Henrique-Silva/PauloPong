using Microsoft.Xna.Framework.Input;

namespace PauloPong_Core.Components.Controls
{
    partial class ButtonStandard
    {
        partial void CustomInitialize()
        {
            Visual.HoverOver += (s, e) => Mouse.SetCursor(MouseCursor.Hand);
        }
    }
}
