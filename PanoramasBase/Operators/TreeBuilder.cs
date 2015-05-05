using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public class TreeBuilder {
    SegmentsMap map;

    public TreeBuilder(SegmentsMap map) {
      this.map = map;
    }

    public void Generate() {
      ResetSegments();
      List<Segment> tree = new List<Segment>();
      var root = map.CoreSegment();
      tree.Add(root);
      root.BelongsToPan = true;
      var new_nodes = map.DomainOf(root);
      foreach (var node in new_nodes) {
        var match = map.MatchBetween(root, node);
        node.Transformation.Distort(match.GenerateTransformation());
        tree.Add(node);
        node.BelongsToPan = true;
      }
    }

    void ResetSegments() {
      foreach (var segment in map.Segments) {
        segment.ResetTransformation();
      }
    }
  }
}
