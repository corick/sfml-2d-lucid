
using Lucid.Framework;
using Lucid.Framework.Graphics;
using Lucid.Framework.Resource;
using TestGame.Entities;

namespace TestGame
{
    internal class TGame
        : Lucid.Framework.Game
    {

        protected override void Initialize()
        {
            
            //This is a lil verbose but our api is definitely changing.
            //Entities.TestEntity e = new Entities.TestEntity(screenManager.CurrentScreen.Entities);
            //screenManager.CurrentScreen.Entities.Add(e);
            TestXform1 xform = new TestXform1(screenManager.CurrentScreen.Entities);
            screenManager.CurrentScreen.Entities.Add(xform);
            TestXform2 xf2 = new TestXform2(screenManager.CurrentScreen.Entities, xform);
            screenManager.CurrentScreen.Entities.Add(xf2);
        }

    }
}
