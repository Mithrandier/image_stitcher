using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.TreeBuilder {
  public class TreeNode {
    public IImage Image { get; private set; }
    public List<TreeNode> Children { get; private set; }
    public TreeNode Parent { get; private set; }
    public ITransformation Transformation { get; private set; }

    public TreeNode(IImage image, ITransformation transformation, TreeNode parent = null) {
      this.Image = image;
      this.Transformation = transformation;
      this.Parent = parent;
      this.Children = new List<TreeNode>();
      updateTransformation();
    }

    public TreeNode AddChild(IImage image, ITransformation transformation) {
      var child = new TreeNode(image, transformation, this);
      Children.Add(child);
      return child;
    }

    public TreeNode FindNode(IImage image) {
      if (Image == image)
        return this;
      else
        foreach (var child in Children) {
          var match = child.FindNode(image);
          if (match != null)
            return match;
        }
      return null;
    }

    public IImage[] CollectSegments(List<IImage> images = null) {
      if (images == null)
        images = new List<IImage>();
      images.Add(Image);
      foreach (var child in Children)
        child.CollectSegments(images);
      return images.ToArray();
    }

    void updateTransformation() {
      if (Parent != null)
        this.Transformation.Distort(Parent.Transformation);      
    }
  }
}
