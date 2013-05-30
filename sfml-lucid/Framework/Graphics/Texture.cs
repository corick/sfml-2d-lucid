using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lucid.Framework.Graphics
{
    public class Texture
    {
        /// <summary>
        /// The texture that this wraps.
        /// </summary>
        public Object TextureData
        {
            get;
            private set;
        }

        public TextureInfo Info //I don't like "info" maybe settings?
        {
            get;
            private set;
        }

        public Texture(TextureInfo textureInfo, Object textureData)
        {
            this.Info = textureInfo;
            this.TextureData = textureData;
        }
    }
}
