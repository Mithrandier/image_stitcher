using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.TreeBuilder {
  public class Builder : IBuilder {
    IFactory factory;
    List<IImage> loose_images;
    List<ISegment> segments;

    public Builder(IFactory factory) {
      this.factory = factory;
      this.segments = new List<ISegment>();
    }

    public IPanoramaComplete Generate(IPanoramaRelations panorama) {
      this.segments.Clear();
      this.loose_images = panorama.Images.ToList();
      List<IImage> loose_images = panorama.Images.ToList();
      var root = addNodeToTree(panorama, panorama.Core());
      while (loose_images.Count > 0) {
        IImage closest_loose_segment, closest_tree_segment;
        var registered = panorama.Images.Except(loose_images);
        panorama.ClosestTo(registered.ToArray(), loose_images.ToArray(), out closest_loose_segment, out closest_tree_segment);
        var closest_tree_node = root.FindNode(closest_tree_segment);
        addNodeToTree(panorama, closest_loose_segment, closest_tree_node);
      }
      return factory.PanoramaComplete(panorama, segments.ToArray());
    }

    TreeNode addNodeToTree(IPanoramaRelations panorama, IImage image, TreeNode parent = null) {
      TreeNode node = null;
      if (parent != null) {
        var transformation = panorama.MatchBetween(parent.Segment, image).GenerateTransformation();
        node = parent.AddChild(image, transformation);
      } else {
        node = new TreeNode(image);
      }
      loose_images.Remove(image);
      var segment = factory.Segment(node.Segment, node.Transformation); 
      segments.Add(segment);
      var neighbours = panorama.NeighboursOf(image, loose_images.ToArray());
      foreach (var neighbour in neighbours) {
        addNodeToTree(panorama, neighbour, node);
      }
      return node;
    }
  }
}
