using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucid.Framework.Graphics.Sheet;

namespace Lucid.Framework.Resource.Texture
{
    public class SpriteSheetReader
        : IResourceReader
    {

        public Type ResourceType
        {
            get { return typeof(Lucid.Framework.Graphics.Sheet.SpriteSheet); }
        }

        /// <summary>
        /// Load a spritesheet from a bss.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resources"></param>
        /// <param name="from"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public T LoadResource<T>(ResourceManager resources, ZipPack from, string path)
        {
            using (ResourceHandle rh = from.GetFile(path))
            { 
                //Load the spritesheet using a binaryreader.
                using (BinaryReader reader = new BinaryReader(rh.ResourceStream))
                {
                    if (typeof(T) == rh.ResourceType)
                    {
                        try
                        {
                            object x = LoadSheet(resources, reader);
                            return (T)x;
                        }
                        catch (Exception e)
                        {
                            throw new InvalidOperationException("SpriteSheetWriter: Something went wrong when loading the sprite sheet.", e);
                        }
                    }
                    else throw new Exception("SpriteSheetReader: Attempted to load the wrong resource type from this reader. Check your manifest!");
                }
            }
        }

        private SpriteSheet LoadSheet(ResourceManager resources, BinaryReader reader)
        {
            //FIXME: This is horrible and you should feel bad. Fix it up!!
            string s = reader.ReadString();
            if (!s.Equals("bss1")) throw new InvalidOperationException("SpriteSheetReader: Header is invalid.");
            string path = reader.ReadString();

            Lucid.Framework.Graphics.Texture sheetTexture = resources.Load<Lucid.Framework.Graphics.Texture>(path);

            System.Drawing.Size sz = new System.Drawing.Size(reader.ReadInt32(), reader.ReadInt32());

            int anims = reader.ReadInt32();

            List<Animation> animations = new List<Animation>();
            for (int i = 0; i < anims; i++)
                animations.Add(LoadAnimation(reader));

            return new SpriteSheet(sheetTexture, path, sz, animations);
        }

        private Animation LoadAnimation(BinaryReader reader)
        {
            string key = reader.ReadString();
            int len = reader.ReadInt32();

            List<Frame> frames = new List<Frame>();
            for (int i = 0; i < len; i++)
                frames.Add(LoadFrame(reader));

            Animation anim = new Animation(frames, key);
            return anim;
        }

        private Frame LoadFrame(BinaryReader reader)
        {
            int x = reader.ReadInt32();
            int y = reader.ReadInt32();
            float delay = reader.ReadSingle();

            if (delay < 0.16f) delay = 0.16f; //Make sure it's not too small!
                                              //Since we can get stuck if we dont!

            return new Frame(delay, new System.Drawing.Point(x, y));
        }

    }

}
