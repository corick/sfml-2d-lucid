using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Lucid.Types;

namespace Tests
{
    [TestClass]
    public class TransformTests
    {
        ///Changed stuff up. No longer accurate.
        ///Transform Position etc are relative to it.
        
        //[TestMethod]
        //public void TestEverythingWorksWithNullParent()
        //{
        //    //No throw? Good.
        //    Transform tx = new Transform();
        //    tx.Rotation = 0f;
        //    tx.Origin = Vector.Zero;
        //    tx.Position = Vector.Zero;
        //    tx.Scale = Vector.Zero;
        //}

        //[TestMethod]
        //public void TestTransformChildRotationSetCorrect()
        //{
        //    Transform parent = new Transform();
        //    parent.Rotation = 1.0f;
        //    Transform child = new Transform(parent);
        //    child.Rotation = 3.0f;
        //    parent.Rotation = 2.0f;

        //    Assert.AreEqual(child.Rotation, 4.0f);
        //}

        //[TestMethod]
        //public void TestTransformChildScaleSetCorrect()
        //{
        //    Transform parent = new Transform();
        //}
    }
}
