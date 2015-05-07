using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panoramas.Tree;

namespace PanoramasBaseTests {
  [TestClass]
  public class TreeBuilderTest {
    [TestMethod]
    public void ItCanBeCreatedWithAMap() {
      new TreeBuilder(Factory.AMatchingController());
    }

    [TestMethod]
    public void ItGeneratesATree() {
      var tree = new TreeBuilder(Factory.AMatchingController()).Generate();
      Assert.IsNotNull(tree);
      Assert.IsInstanceOfType(tree, typeof(TreeNode));
      Assert.IsNull(tree.Parent);
      Assert.IsTrue(tree.Children.Count > 0);
    }
  }
}
