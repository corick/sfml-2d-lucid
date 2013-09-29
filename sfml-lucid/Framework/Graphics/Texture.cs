using System;
using Lucid.Framework.Resource;


namespace Lucid.Framework.Graphics
{
    [ImportExtension("png")]
    [ImportDefaultFolder("textures")]
    public class Texture
        : IResource 
    {
        private Action<Object> disposeCallback;
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

        public Texture(TextureInfo textureInfo, Object textureData, Action<Object> disposeCallback)
        {
            this.Info = textureInfo;
            this.TextureData = textureData;
            this.disposeCallback = disposeCallback;
        }

        public void OnUnload(ResourceManager rsc)
        {
            disposeCallback.Invoke(TextureData);
            Debug.Trace("Unloading texture.");
        }
    }
}
