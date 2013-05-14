using System;
using System.IO;

using Lucid.Framework.Graphics;

namespace Lucid.Framework
{
    public interface ITextureProvider
    {
        Texture Load(Stream stream); //Find a sensible way to deserialize this.
        Texture Load(string filePath); 
    }
}
