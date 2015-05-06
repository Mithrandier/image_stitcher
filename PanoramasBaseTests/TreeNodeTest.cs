using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panoramas;

namespace PanoramasBaseTests {
  [TestClass]
  public class TreeNodeTest {
    [TestMethod]
    public void ItCanBeCreatedWithASegment() {
      Factory.ATreeNode();
    }

    [TestMethod]
    public void ItProvidesItsChildrenAndParent() {
      var root = Factory.ATreeNode();
      Assert.IsNull(root.Parent);
      Assert.IsTrue(root.Children.Count == 0);
    }

    [TestMethod]
    public void ItAllowsToAddChildren() {
      var root = Factory.ATreeNode();
      var leaf = root.AddChild(Factory.ASegment());
      Assert.AreEqual(leaf.Parent, root);
      Assert.IsTrue(root.Children.Contains(leaf));
    }

    [TestMethod]
    public void ItAllowsToSearchForANode() {
      var root_content = Factory.ASegment();
      var root = new TreeNode(root_content);
      Assert.AreEqual(root.FindNode(root_content), root);
      var leaf_content = Factory.ASegment();
      var leaf = root.AddChild(leaf_content);
      Assert.AreEqual(root.FindNode(leaf_content), leaf);
    }

    [TestMethod]
    public void ItAllowsToSerializeTree() {
      List<Segment> segments = new List<Segment>();
      var root_content = Factory.ASegment();
      var root = new TreeNode(root_content);
      var child1 = Factory.ASegment();
      root.AddChild(child1);
      segments.Add(child1);
      var child2 = Factory.ASegment();
      root.AddChild(child2);
      segments.Add(child2);
      var child11 = Factory.ASegment();
      root.FindNode(child1).AddChild(child11);
      segments.Add(child11);
      Assert.IsTrue(segments.Intersect(root.CollectSegments()).Count() == segments.Count);
    }
  }
}
