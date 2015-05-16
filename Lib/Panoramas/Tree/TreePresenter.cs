using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panoramas.Tree;
using Rendering;

namespace Panoramas.Tree {
  public class TreePresenter {
    TreeNode tree;
    Size offset {
      get { return tree.Segment.Bitmap.Size; }
    }

    public TreePresenter(TreeNode tree) {
      this.tree = tree;      
    }

    public Bitmap Render() {
      var template = generateTemplate(tree.Segment.Bitmap);
      var result = new Emgu.CV.Image<Emgu.CV.Structure.Bgr, int>((Bitmap)template.Clone());
      var offset = new Transformation();
      offset.Move(tree.Segment.Bitmap.Width, tree.Segment.Bitmap.Height);
      renderNode(tree, offset, result);
      var result_bitmap = result.ToBitmap();
      return result_bitmap;
    }

    void renderNode(TreeNode node, Transformation context, Emgu.CV.Image<Emgu.CV.Structure.Bgr, int> template) {
      var transformation = context.Multiply(node.Segment.Transformation);//.UpdateTransformation());
      transformation.TransformOn(node.Segment.Bitmap, template);
      foreach (var child in node.Children)
        renderNode(child, context, template);
    }

    Bitmap generateTemplate(Bitmap core_image) {
      int width = core_image.Width * 3;
      int height = core_image.Height * 3;
      var template = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
      return template;
    }
  }
}
