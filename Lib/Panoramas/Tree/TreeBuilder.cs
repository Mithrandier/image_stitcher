using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panoramas.Matching;

namespace Panoramas.Tree {
  public class TreeBuilder {
    Segment[] all_segments;
    IAnalyzer map;
    List<Segment> loose_segments;
    Segment[] treeNodes {
      get { return all_segments.Except(loose_segments).ToArray(); }
    }

    public TreeBuilder(IPanorama panorama, IAnalyzer map) {
      this.map = map;
      this.all_segments = panorama.Segments;
    }

    public TreeNode Generate() {
      this.loose_segments = all_segments.ToList();
      resetSegments();
      var root = addNodeToTree(map.CoreSegment());
      while (loose_segments.Count > 0) {
        Segment closest_loose_segment, closest_tree_segment;
        map.ClosestTo(treeNodes, loose_segments.ToArray(), out closest_loose_segment, out closest_tree_segment);
        var closest_tree_node = root.FindNode(closest_tree_segment);
        addNodeToTree(closest_loose_segment, closest_tree_node);
      }
      return root;
    }

    TreeNode addNodeToTree(Segment segment, TreeNode parent = null) {
      TreeNode node = null;
      if (parent != null) {
        segment.Transformation.Distort(map.MatchBetween(parent.Segment, segment).GenerateTransformation());
        node = parent.AddChild(segment);
      } else {
        node = new TreeNode(segment);
      }
      loose_segments.Remove(segment);
      var neighbours = map.NeighboursOf(segment, loose_segments.ToArray());
      foreach (var neighbour in neighbours) {
        addNodeToTree(neighbour, node);
      }
      return node;
    }

    void resetSegments() {
      foreach (var segment in all_segments) {
        segment.ResetTransformation();
      }
    }
  }
}
