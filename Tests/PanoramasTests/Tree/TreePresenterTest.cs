using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panoramas.Tree;

namespace PanoramasBaseTests.Tree {
  [TestClass]
  public class TreePresenterTest {
    [TestMethod]
    public void ItCanBeCreatedWithANode() {
      new TreePresenter(Factory.ATreeNode());
    }

    [TestMethod]
    public void ItRendersTreeAsBitmap() {
      var root = Factory.ATreeNode();
      var presenter = new TreePresenter(root);
      var result = presenter.Render();
      Assert.IsNotNull(result);
      Assert.IsInstanceOfType(result, typeof(Bitmap));
      root.AddChild(Factory.ASegment());
      presenter = new TreePresenter(root);
      result = presenter.Render();
      Assert.IsNotNull(result);
      Assert.IsInstanceOfType(result, typeof(Bitmap));
    }
  }
}
