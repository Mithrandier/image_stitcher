using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.TreeBuilder {
  public class Builder : IBuilder {
    IFactory factory;
    List<IImage> loose_images;
    List<IImageTransformed> segments;

    public Builder(IFactory factory) {
      this.factory = factory;
      this.segments = new List<IImageTransformed>();
    }

    public IPanoramaTransformations Generate(IPanoramaRelations panorama) {
      this.segments.Clear();
      this.loose_images = panorama.Images.ToList();
      var root = addNodeToTree(panorama, panorama.Core());
      while (loose_images.Count > 0) {
        IImage closest_loose_image, closest_tree_image;
        var registered = panorama.Images.Except(loose_images);
        panorama.ClosestBetween(registered.ToArray(), loose_images.ToArray(), out closest_loose_image, out closest_tree_image);
        var closest_tree_node = root.FindNode(closest_tree_image);
        addNodeToTree(panorama, closest_loose_image, closest_tree_node);
      }
      return factory.PanoramaComplete(panorama, segments.ToArray());
    }

    TreeNode addNodeToTree(IPanoramaRelations panorama, IImage image, TreeNode parent = null) {
      TreeNode node = null;
      if (parent != null) {
        var transformation = panorama.MatchBetween(parent.Image, image).GenerateTransformation();
        node = parent.AddChild(image, transformation);
      } else {
        node = new TreeNode(image, factory.Transformation());
      }
      loose_images.Remove(image);
      segments.Add(factory.Segment(node.Image, node.Transformation));
      var neighbours = panorama.NeighboursOf(image, loose_images.ToArray());
      foreach (var neighbour in neighbours) {
        addNodeToTree(panorama, neighbour, node);
      }
      return node;
    }
  }
}
