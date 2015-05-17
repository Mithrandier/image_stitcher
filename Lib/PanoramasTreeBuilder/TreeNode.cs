using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.TreeBuilder {
  public class TreeNode {
    public IImage Segment { get; private set; }
    public List<TreeNode> Children { get; private set; }
    public TreeNode Parent { get; private set; }
    public ITransformation Transformation { get; private set; }

    public TreeNode(IImage segment, ITransformation transformation = null, TreeNode parent = null) {
      this.Segment = segment;
      this.Transformation = transformation;
      this.Parent = parent;
      this.Children = new List<TreeNode>();
      updateTransformation();
    }

    public TreeNode AddChild(IImage segment, ITransformation transformation) {
      var child = new TreeNode(segment, transformation, this);
      Children.Add(child);
      return child;
    }

    public TreeNode FindNode(IImage segment) {
      if (Segment == segment)
        return this;
      else
        foreach (var child in Children) {
          var match = child.FindNode(segment);
          if (match != null)
            return match;
        }
      return null;
    }

    public IImage[] CollectSegments(List<IImage> segments = null) {
      if (segments == null)
        segments = new List<IImage>();
      segments.Add(Segment);
      foreach (var child in Children)
        child.CollectSegments(segments);
      return segments.ToArray();
    }

    void updateTransformation() {
      if (Parent != null)
        this.Transformation.Distort(Parent.Transformation);      
    }
  }
}
