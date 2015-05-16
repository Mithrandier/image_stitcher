using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panoramas.FeaturedTree.Matching;

namespace Panoramas.FeaturedTree {
  public class TreeBuilder : IBuilder {
    public TreeBuilder() {
    }

    public IPanoramaSegments Generate(IPanoramaMatches panorama_matches) {
      panorama_matches.ResetSegmentsPositions();
      var loose_segments = panorama_matches.Segments.ToList();
      var root = addNodeToTree(panorama_matches.Core());
      while (loose_segments.Count > 0) {
        Segment closest_loose_segment, closest_tree_segment;
        var registered = panorama.Segments.Except(loose_segments);
        panorama_matches.ClosestTo(registered.ToArray(), loose_segments.ToArray(), out closest_loose_segment, out closest_tree_segment);
        var closest_tree_node = root.FindNode(closest_tree_segment);
        addNodeToTree(closest_loose_segment, closest_tree_node);
      }
      return panorama;
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
  }
}
