using System;
using Lucidity.Core.Project.Resources;
using Lucidity.Core.Project.Resources.TreeModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LucidityTests
{
    [TestClass]
    public class ResourceTreeTests
    {
        private ResourceTree tree;

        [TestInitialize]
        public void Init()
        {
            tree = new ResourceTree();
            var n1 = new FolderNode(tree, "asdffdsa");
            tree.Children.Add(n1);
            n1.Children.Add(new ResourceNode(n1, new DesignerResource("C:/herp/derp.hurf", typeof(string))));
        }

        [TestMethod]
        public void TestFindByPathName()
        {
            DesignerResource expected = ((tree.Children[0] as FolderNode).Children[0] as ResourceNode).Resource;
            DesignerResource actual = tree.Find("C:/herp/derp.hurf");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFindByPathNameNoFileExists()
        {
            DesignerResource expected = null;
            DesignerResource actual = tree.Find("C:/asdf/dfdfa.poop");
            Assert.AreEqual(expected, actual);
        }
    }
}
