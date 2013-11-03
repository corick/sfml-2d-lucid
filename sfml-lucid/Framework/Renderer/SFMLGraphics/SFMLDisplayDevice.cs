using System.Collections.Generic;
using System.Drawing;
using Lucid.Types;
using SFML.Graphics;
using SFML.Window;
using LucidPrimitive = Lucid.Framework.Graphics.PrimitiveType;
using LucidTexture = Lucid.Framework.Graphics.Texture;
using SDColor = System.Drawing.Color;
using SFColor = SFML.Graphics.Color;
using SFPrimitive = SFML.Graphics.PrimitiveType;

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
            //sprite.Scale = new SFML.Window.Vector2f((float)destRect.X / (float)sourceRect.X,
            //                                     (float)destRect.Y / (float)sourceRect.Y);
            sprite.Scale = new SFML.Window.Vector2f(1, 1);
            sprite.Color = SFML.Graphics.Color.White; //FIXME: Map S.D.Colors to SF.G.Colors.
            sprite.Position = new SFML.Window.Vector2f(destRect.X, destRect.Y);

            window.Draw(sprite);
        }

        public void DrawPrimitives(LucidPrimitive type, List<Vector> vertices, SDColor color)
        { //Assume points in screen space until later.
            SFColor sfcolor = new SFColor(color.R, color.G, color.B, color.A);
            VertexArray v = new VertexArray(SFPrimitive.Lines, (uint)vertices.Count);
            foreach (var vertex in vertices)
            {
                var sfvec2 = new Vector2f(vertex.X, vertex.Y);
                var sfvertex = new Vertex(sfvec2, sfcolor);
            }
            v.Draw(window, RenderStates.Default);
        }

        SFML.Graphics.Font defaultFont = new SFML.Graphics.Font("segoeui-mono.ttf");
        public void DrawText(string text, object font, Vector position, SDColor color)
        {
            Text drawObj = new Text(text, defaultFont, 16);
            //FIXME: Creates Garbage each frame!!!
            drawObj.Position = new SFML.Window.Vector2f(position.X, position.Y);
            drawObj.Color = SFColor.White; //FIXME: As above.

            window.Draw(drawObj);
        }


        public void DrawTexture(LucidTexture texture, Types.Transform transform, Rectangle source, SDColor color)
        {
            Texture sfTexture = texture.TextureData as Texture;
            sprite.Texture = sfTexture;
            sprite.TextureRect = new IntRect(source.Left, source.Top, source.Width, source.Height);
            sprite.Position = new Vector2f(transform.WorldPosition.X, transform.WorldPosition.Y);
            sprite.Origin = new Vector2f(transform.Origin.X, transform.Origin.Y);
            sprite.Rotation = transform.AbsoluteRotation;
            sprite.Scale = new Vector2f(transform.AbsoluteScale.X, transform.AbsoluteScale.Y);
            sprite.Color = new SFColor(color.R, color.G, color.B, color.A);

            window.Draw(sprite);
        }
    }
}
