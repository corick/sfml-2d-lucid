using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucid.Framework.Resource;

using Lucid.Models.Sheet;

namespace Lucid.Framework.Graphics.Sheet
{
    //FIXME: Can't load the same sheet multiple times, the cached version will be the one loaded,
    //strip the animation logic out into the Sprite class, or make a nocache attribute for Iresources?
    [ImportExtension("bss")]
    [ImportDefaultFolder("spritesheet")]
    public class SpriteSheet //Possibly actually change this to S.S.Handle, and have a dumb container object for SpriteSheets or something.
        : IResource
    {
        private string sheetPath;
        private Dictionary<string, Animation> spriteFrames;
        public Texture SheetTexture
        {
            get;
            private set;
        }

        private Size size;

        public SpriteSheet(Texture tex, string texturePath)
        {
            spriteFrames = new Dictionary<string, Animation>();
            Animation anim = new Animation();
            spriteFrames.Add(anim.Key, anim);
            this.size = new Size(tex.Info.Width, tex.Info.Height);
            sheetPath = texturePath;
            SheetTexture = tex;
        }

        public SpriteSheet(Texture tex, string texturePath, Size size, List<Animation> animations)
        {
            SheetTexture = tex;
            this.size = size;

            spriteFrames = new Dictionary<string, Animation>();

            foreach (Animation a in animations)
            {
                spriteFrames.Add(a.Key, a);
            }
            sheetPath = texturePath;
        }

        public Animator CreateAnimator()
        {
            var animator = new Animator(this.size, this.spriteFrames);
            return animator;
        }

        public void OnUnload(ResourceManager rsc)
        {
            rsc.Release<Texture>(sheetPath);
        }
    }
}
