
using Lucid.Framework;
using Lucid.Framework.Graphics;
using Lucid.Framework.Resource;

namespace TestGame
{
    internal class TGame
        : Lucid.Framework.Game
    {
        protected override void Initialize()
        {
            //This is a lil verbose but our api is definitely changing.
            Entities.TestEntity e = new Entities.TestEntity(screenManager.CurrentScreen.Entities);
            screenManager.CurrentScreen.Entities.Add(e);
        }

    }
}
