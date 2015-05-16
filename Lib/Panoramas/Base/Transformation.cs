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
      this.homography_matrix = newHomography();
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
      TransformOn(image, formatted_result);
      return formatted_result.ToBitmap();
    }

    public void TransformOn(Bitmap image, Emgu.CV.Image<Bgr, int> template) {
      var formatted_segment = new Emgu.CV.Image<Bgr, int>(image);
      Emgu.CV.CvInvoke.cvWarpPerspective(
        formatted_segment.Ptr, 
        template.Ptr, 
        homography_matrix.Ptr, 
        (int)Emgu.CV.CvEnum.INTER.CV_INTER_NN, 
        new MCvScalar(0, 0, 0));
    }

    public void Move(int x_diff, int y_diff) {
      homography_matrix[0, 2] += x_diff;
      homography_matrix[1, 2] += y_diff;
    }

    public Transformation Clone() {
      var clone = new Transformation();
      clone.homography_matrix = this.homography_matrix.Clone();
      return clone;
    }

    public static Transformation Generate(PointF[] points_dst, PointF[] points_src) {
      var matrix = Emgu.CV.CameraCalibration.FindHomography(
        points_src,
        points_dst,
        Emgu.CV.CvEnum.HOMOGRAPHY_METHOD.RANSAC,
        2 // RANSAC reprojection error
        );
      var transformation = new Transformation();
      transformation.homography_matrix = matrix;
      return transformation;
    }

    Emgu.CV.HomographyMatrix newHomography() {
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
