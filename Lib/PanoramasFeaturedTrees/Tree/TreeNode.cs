using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.FeaturedTrees.Trees {
  public class TreeNode {
    public Segment Segment { get; private set; }
    public List<TreeNode> Children { get; private set; }
    public TreeNode Parent { get; private set; }

    public TreeNode(Segment segment, TreeNode parent = null) {
      this.Segment = segment;
      this.Parent = parent;
      this.Children = new List<TreeNode>();
      updateTransformation();
    }

    public TreeNode AddChild(Segment segment) {
      var child = new TreeNode(segment, this);
      Children.Add(child);
      return child;
    }

    public TreeNode FindNode(Segment segment) {
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

    public Segment[] CollectSegments(List<Segment> segments = null) {
      if (segments == null)
        segments = new List<Panoramas.Segment>();
      segments.Add(Segment);
      foreach (var child in Children)
        child.CollectSegments(segments);
      return segments.ToArray();
    }

    void updateTransformation() {
      if (Parent != null)
        this.Segment.Transformation.Distort(Parent.Segment.Transformation);      
    }
  }
}
