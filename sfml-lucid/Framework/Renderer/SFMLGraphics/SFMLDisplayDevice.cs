using SFML.Graphics;
using System.Drawing;
using LucidTexture = Lucid.Framework.Graphics.Texture;
using SDColor = System.Drawing.Color;

namespace Lucid.Framework.Renderer.SFMLGraphics
{
    /// <summary>
    /// The display provider for sfml windows.
    /// </summary>
    internal class SFMLDisplayDevice
        : IDisplayDevice
    {
        private RenderWindow window;
        private ITextureProvider textureProvider;
        
        /// <summary>
        /// Instead of alloc-ing a new sprite every time we draw something..
        /// </summary>
        private Sprite sprite;

        public Size ViewportSize
        {
            get { return new Size((int)window.Size.X, (int)window.Size.Y); } 
        }

        public SFMLDisplayDevice(RenderWindow window)
        {
            this.window = window;
            this.textureProvider = new SFMLTextureProvider();
            sprite = new Sprite();
        }

        public ITextureProvider GetTextureProvider()
        {
            return textureProvider;
        }

        public void DrawTexture(LucidTexture texture, Rectangle sourceRect, Rectangle destRect, SDColor color)
        {
            //We can cast this.
            Texture tex = texture.TextureData as Texture;

            sprite.Texture = tex;
            sprite.TextureRect = new IntRect(sourceRect.Left, sourceRect.Top, sourceRect.Width, sourceRect.Height);
            sprite.Scale = new SFML.Window.Vector2f((float)destRect.X / (float)sourceRect.X,
                                                    (float)destRect.Y / (float)sourceRect.Y);
            sprite.Color = SFML.Graphics.Color.White; //FIXME: Map S.D.Colors to SF.G.Colors.
            sprite.Position = new SFML.Window.Vector2f(destRect.X, destRect.Y);

            window.Draw(sprite);
        }
    }
}
