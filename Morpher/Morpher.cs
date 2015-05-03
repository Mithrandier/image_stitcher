using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Panoramas.Morphing {
  public class Morpher {
    Bitmap image_src, image_dest;

    public Morpher() { }

    public Morpher(Bitmap image_src, Bitmap image_dest) {
      this.image_src = image_src;
      this.image_dest = image_dest;
    }

    public Image Transform(Emgu.CV.HomographyMatrix current_matrix) {
      var img_src = new Emgu.CV.Image<Bgr, int>(image_src);
      var img_dest = new Emgu.CV.Image<Bgr, int>(GenerateTemplate(current_matrix));
      Emgu.CV.CvInvoke.cvWarpPerspective(img_src.Ptr, img_dest.Ptr, current_matrix.Ptr, (int)Emgu.CV.CvEnum.INTER.CV_INTER_NN, new MCvScalar(0, 0, 0));
      var result = img_dest.ToBitmap();
      var cropped_result = AutoCrop(result);
      return cropped_result;      
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

    protected Bitmap AutoCrop(Bitmap image) {
      var integration_matrix = ExtractIntegrationMatrix(image);
      int bottom_y = -1;
      double current_value, down_value;
      do {
        bottom_y += 1;
        current_value = integration_matrix[image.Width - 1, bottom_y];
      } while ((current_value == 0 || Double.IsInfinity(current_value)) && bottom_y < image.Height - 1);
      
      int top_y = image.Height;
      do {
        top_y -= 1;
        current_value = integration_matrix[image.Width - 1, top_y];
        down_value = integration_matrix[image.Width - 1, top_y - 1];
      } while (top_y > bottom_y && (current_value == down_value));

      int bottom_x = -1;
      do {
        bottom_x += 1;
        current_value = integration_matrix[bottom_x, image.Height - 1];
      } while ((current_value == 0 || Double.IsInfinity(current_value)) && bottom_x < image.Width - 1);
      int top_x = image.Width;
      do {
        top_x -= 1;
        current_value = integration_matrix[top_x, image.Height - 1];
        down_value = integration_matrix[top_x - 1, image.Height - 1];
      } while (top_x > bottom_x && (current_value == down_value));

      int width = top_x - bottom_x;
      int height = top_y - bottom_y;
      Bitmap cropped_image = new Bitmap(width, height);
      var g = Graphics.FromImage(cropped_image);
      g.DrawImage(image, new Rectangle(0, 0, width, height), new Rectangle(bottom_x, bottom_y, width, height), GraphicsUnit.Pixel);
      g.Save();
      return cropped_image;
    }

    protected double[,] ExtractIntegrationMatrix(Bitmap image) {
      double[,] intergation_matrix = new double[image.Width, image.Height];
      for (int x = 0; x < image.Width; x++) {
        double column_sum = 0;
        for (int y = 0; y < image.Height; y++) {
          var pixel = image.GetPixel(x, y);
          var intensity = (pixel.R * 0.299 + pixel.G * 0.587 + pixel.B*0.114) / 255;
          intergation_matrix[x, y] = intensity + column_sum;
          column_sum += intensity;
          if (x > 0)
            intergation_matrix[x, y] += intergation_matrix[x - 1, y];
        }
      }
      return intergation_matrix;
    }
  }
}
