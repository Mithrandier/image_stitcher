using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panoramas.FeaturedTrees.Matching;

namespace Panoramas.FeaturedTrees.Trees {
  public class TreeBuilder : IBuilder {
    IFactory factory;

    public TreeBuilder(IFactory factory) {
      this.factory = factory;
    }

    public IPanoramaComplete Generate(IPanoramaRelations panorama) {
      panorama.ResetSegmentsPositions();
      List<Segment> loose_segments = panorama.Segments.ToList();
      var root = addNodeToTree(panorama, loose_segments, panorama.Core());
      while (loose_segments.Count > 0) {
        Segment closest_loose_segment, closest_tree_segment;
        var registered = panorama.Segments.Except(loose_segments);
        panorama.ClosestTo(registered.ToArray(), loose_segments.ToArray(), out closest_loose_segment, out closest_tree_segment);
        var closest_tree_node = root.FindNode(closest_tree_segment);
        addNodeToTree(panorama, loose_segments, closest_loose_segment, closest_tree_node);
      }
      return new PanoramaComplete(panorama);
    }

    TreeNode addNodeToTree(IPanoramaRelations panorama, List<Segment> loose_segments, Segment segment, TreeNode parent = null) {
      TreeNode node = null;
      if (parent != null) {
        segment.Transformation.Distort(panorama.MatchBetween(parent.Segment, segment).GenerateTransformation());
        node = parent.AddChild(segment);
      } else {
        node = new TreeNode(segment);
      }
      loose_segments.Remove(segment);
      var neighbours = panorama.NeighboursOf(segment, loose_segments.ToArray());
      foreach (var neighbour in neighbours) {
        addNodeToTree(panorama, loose_segments, neighbour, node);
      }
      return node;
    }
  }
}
