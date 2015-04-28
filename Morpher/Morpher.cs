using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Morpher {
  public class Morpher {
    Bitmap image_src, image_dest;
    HomographyMatrix matrix;

    public Morpher(Image image_src, Image image_dest, HomographyMatrix matrix) {
      this.image_src = (Bitmap)image_src;
      this.image_dest = (Bitmap)image_dest;
      this.matrix = matrix;
    }

    public Image Transform(Emgu.CV.HomographyMatrix current_matrix) {
      var img_src = new Emgu.CV.Image<Bgr, int>(image_src);
      var img_dest = new Emgu.CV.Image<Bgr, int>(GenerateTemplate(current_matrix));
      Emgu.CV.CvInvoke.cvWarpPerspective(img_src.Ptr, img_dest.Ptr, current_matrix.Ptr, (int)Emgu.CV.CvEnum.INTER.CV_INTER_NN, new MCvScalar(0, 0, 0));
      return img_dest.ToBitmap();
    }

    Bitmap GenerateTemplate(HomographyMatrix matrix) {
      int width = Math.Max(image_dest.Width, image_src.Width) + (int)Math.Abs(matrix[0,2]);
      int height = Math.Max(image_dest.Height, image_src.Height) + (int)Math.Abs(matrix[1,2]);
      var template = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
      var g = Graphics.FromImage(template);
      int x_base = 0;
      if (matrix[0, 2] < 0) {
        x_base -= (int)matrix[0, 2];
        matrix[0, 2] = 0;
      }
      int y_base = 0;
      if (matrix[1, 2] < 0) {
        y_base -= (int)matrix[1, 2];
        matrix[1, 2] = 0;
      }
      g.DrawImage(image_dest, x_base, y_base, image_dest.Width, image_dest.Height);
      g.Save();
      return template;
    }
  }
}
