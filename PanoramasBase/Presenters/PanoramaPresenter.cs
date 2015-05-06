using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.Presenters {
  public class PanoramaPresenter {
    Panorama pan;
    TreeNode tree;    

    public PanoramaPresenter(Panorama pan, TreeNode tree) {
      this.pan = pan;
      this.tree = tree;      
    }

    public Bitmap Render() {
      var template = GenerateTemplate(tree.Segment.Bitmap);
      var result = new Emgu.CV.Image<Emgu.CV.Structure.Bgr, int>((Bitmap)template.Clone());
      var rest_segments = pan.segments.Where((s) => s != tree.Segment);
      foreach (var segment in rest_segments) {
        segment.Transformation.TransformOn(segment.Bitmap, result);
      }
      tree.Segment.Transformation.TransformOn(tree.Segment.Bitmap, result);
      return result.ToBitmap();
    }

    Bitmap GenerateTemplate(Bitmap core_image) {
      int width = core_image.Width * 3;
      int height = core_image.Height * 3;
      var template = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
      return template;
    }
  }
}
