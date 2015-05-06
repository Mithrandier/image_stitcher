using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panoramas;

namespace PanoramasBaseTests {
  [TestClass]
  public class TreeBuilderTest {
    [TestMethod]
    public void ItCanBeCreatedWithAMap() {
      new TreeBuilder(Factory.ASegmentsMap());
    }

    [TestMethod]
    public void ItGeneratesATree() {
      var tree = new TreeBuilder(Factory.ASegmentsMap()).Generate();
      Assert.IsNotNull(tree);
      Assert.IsInstanceOfType(tree, typeof(TreeNode));
      Assert.IsNull(tree.Parent);
      Assert.IsTrue(tree.Children.Count > 0);
    }
  }
}
