using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public class TreeBuilder {
    SegmentsMap map;
    List<Segment> loose_segments;

    public TreeBuilder(SegmentsMap map) {
      this.map = map;
    }

    public TreeNode Generate() {
      this.loose_segments = map.AllSegments.ToList();
      ResetSegments();
      var root = AddNodeToTree(map.CoreSegment());
      while (loose_segments.Count > 0) {
        Segment closest_loose_segment, closest_tree_segment;
        map.ClosestTo(TreeNodes, loose_segments.ToArray(), out closest_loose_segment, out closest_tree_segment);
        var closest_tree_node = root.FindNode(closest_tree_segment);
        AddNodeToTree(closest_loose_segment, closest_tree_node);
      }
      return root;
    }

    TreeNode AddNodeToTree(Segment segment, TreeNode parent = null) {
      TreeNode node = null;
      if (parent != null) {
        segment.Transformation.Distort(parent.Segment.Transformation);
        segment.Transformation.Distort(map.MatchBetween(parent.Segment, segment).GenerateTransformation());
        node = parent.AddChild(segment);
      } else {
        node = new TreeNode(segment);
      }
      loose_segments.Remove(segment);
      var neighbours = map.NeighboursOf(segment, loose_segments.ToArray());
      foreach (var neighbour in neighbours) {
        AddNodeToTree(neighbour, node);
      }
      return node;
    }

    Segment[] TreeNodes {
      get {
        return map.AllSegments.Except(loose_segments).ToArray();
      }
    }

    void ResetSegments() {
      foreach (var segment in map.AllSegments) {
        segment.ResetTransformation();
      }
    }
  }
}
