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

    public TreePresenter(TreeNode tree) {
      this.tree = tree;      
    }

    public Bitmap Render() {
      var template = GenerateTemplate(tree.Segment.Bitmap);
      var result = new Emgu.CV.Image<Emgu.CV.Structure.Bgr, int>((Bitmap)template.Clone());
      var offset = new Transformation();
      offset.Move(tree.Segment.Bitmap.Width, tree.Segment.Bitmap.Height);
      RenderNode(tree, offset, result);
      var result_bitmap = result.ToBitmap();
      result_bitmap = new Cropper(result_bitmap).AutoCrop();
      return result_bitmap;
    }

    void RenderNode(TreeNode node, Transformation context, Emgu.CV.Image<Emgu.CV.Structure.Bgr, int> template) {
      var transformation = node.Transformation(context);
      transformation.TransformOn(node.Segment.Bitmap, template);
      foreach (var child in node.Children)
        RenderNode(child, context, template);
    }

    Bitmap GenerateTemplate(Bitmap core_image) {
      int width = core_image.Width * 3;
      int height = core_image.Height * 3;
      var template = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
      return template;
    }

    Size Offset {
      get { return tree.Segment.Bitmap.Size; }
    }
  }
}
