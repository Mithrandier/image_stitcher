using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Structure;
using Panoramas.Matching;

namespace Panoramas {
  public class Transformation {
    Emgu.CV.HomographyMatrix homography_matrix;

    public Transformation() {
      this.homography_matrix = NewHomography();
    }

    public Transformation(Emgu.CV.HomographyMatrix matrix) {
      this.homography_matrix = matrix.Clone();
    }

    public Transformation(Transformation transformation) {
      this.homography_matrix = transformation.homography_matrix.Clone();
    }

    public double[,] Matrix() {
      return (double[,])homography_matrix.Data.Clone();
    }

    public Transformation Invert() {
      return (Transformation)this.MemberwiseClone();
    }

    public void Distort(Transformation outer_transformation) {
      var multiplied = this.homography_matrix.Mul(outer_transformation.homography_matrix);
      this.homography_matrix.Data = multiplied.Data;
    }

    public Transformation Multiply(Transformation transformation) {
      var multiplied = this.homography_matrix.Mul(transformation.homography_matrix);
      var result = new Transformation();
      result.homography_matrix.Data = multiplied.Data;
      return result;
    }

    public Bitmap Transform(Bitmap image) {
      var formatted_result = new Emgu.CV.Image<Bgr, int>(image);
      return TransformOn(image, formatted_result);
    }

    public Bitmap TransformOn(Bitmap image, Emgu.CV.Image<Bgr, int> template) {
      var formatted_segment = new Emgu.CV.Image<Bgr, int>(image);
      Emgu.CV.CvInvoke.cvWarpPerspective(formatted_segment.Ptr, template.Ptr, homography_matrix.Ptr, (int)Emgu.CV.CvEnum.INTER.CV_INTER_NN, new MCvScalar(0, 0, 0));

      return template.ToBitmap();
    }

    public Bitmap TransformWithin(Bitmap image, Emgu.CV.Image<Bgr, int> template, Transformation accum_transform) {
      var self_clone = new Transformation(this);
      self_clone.Distort(accum_transform);
      var formatted_segment = new Emgu.CV.Image<Bgr, int>(image);
      Emgu.CV.CvInvoke.cvWarpPerspective(formatted_segment.Ptr, template.Ptr, self_clone.homography_matrix.Ptr, (int)Emgu.CV.CvEnum.INTER.CV_INTER_NN, new MCvScalar(0, 0, 0));
      return template.ToBitmap();
    }

    public Bitmap TransformWithin(Bitmap image, Emgu.CV.Image<Bgr, int> template, int x_offset, int y_offset) {
      var self_clone = new Transformation(this);
      self_clone.Move(x_offset, y_offset);
      var formatted_segment = new Emgu.CV.Image<Bgr, int>(image);
      Emgu.CV.CvInvoke.cvWarpPerspective(formatted_segment.Ptr, template.Ptr, self_clone.homography_matrix.Ptr, (int)Emgu.CV.CvEnum.INTER.CV_INTER_NN, new MCvScalar(0, 0, 0));
      return template.ToBitmap();
    }

    public void Move(int x_diff, int y_diff) {
      homography_matrix[0, 2] += x_diff;
      homography_matrix[1, 2] += y_diff;
    }

    public override bool Equals(object obj) {
      if (!(obj is Transformation))
        return false;
      for (int x = 0; x < Matrix().GetLength(0); x++)
        for (int y = 0; y < Matrix().GetLength(1); y++)
          if (((Transformation)obj).Matrix()[x, y] != Matrix()[x, y])
            return false;
      return true;
    }

    Emgu.CV.HomographyMatrix NewHomography() {
      var matrix = new Emgu.CV.HomographyMatrix();
      matrix[0, 0] = 1;
      matrix[1, 1] = 1;
      matrix[2, 2] = 1;
      matrix[2, 0] = 0.0;
      matrix[0, 1] = 0.0;
      return matrix;
    }
  }
}
