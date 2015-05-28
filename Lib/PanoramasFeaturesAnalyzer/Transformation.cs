using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Structure;

namespace Panoramas.HomographyTransformer {
  public class Transformation : ITransformation {
    Emgu.CV.HomographyMatrix homography_matrix;

    public Transformation() {
      this.homography_matrix = newHomography();
    }

    public void Distort(ITransformation transformation) {
      var multiplier = (Transformation)transformation;
      this.homography_matrix.Data = multiplier.homography_matrix.Mul(this.homography_matrix).Data;
    }

    public ITransformation Multiply(ITransformation transformation) {
      var multiplier = (Transformation)transformation;
      var multiplied = this.homography_matrix.Mul(multiplier.homography_matrix);
      var result = new Transformation();
      result.homography_matrix.Data = multiplied.Data;
      return result;
    }

    public Bitmap Transform(Bitmap image) {
      var formatted_result = new Emgu.CV.Image<Bgr, int>(image);
      TransformOn(image, image);
      return formatted_result.ToBitmap();
    }

    public Bitmap TransformOn(Bitmap image, Bitmap template) {
      Emgu.CV.Image<Bgr, int> template_raw = new Emgu.CV.Image<Bgr, int>(template);
      var formatted_segment = new Emgu.CV.Image<Bgr, int>(image);
      Emgu.CV.CvInvoke.cvWarpPerspective(
        formatted_segment.Ptr,
        template_raw.Ptr, 
        homography_matrix.Ptr, 
        (int)Emgu.CV.CvEnum.INTER.CV_INTER_NN, 
        new MCvScalar(0, 0, 0));
      return template_raw.ToBitmap();
    }

    public void Move(int x_diff, int y_diff) {
      homography_matrix[0, 2] += x_diff;
      homography_matrix[1, 2] += y_diff;
    }

    public static ITransformation Generate(PointF[] points_dst, PointF[] points_src) {
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

    public void Reset() {
      this.homography_matrix = newHomography();
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
    
    public PointF Transform(PointF point) {
      var new_point = new PointF();
      var divider = (float)(point.X * homography_matrix[2, 0] + point.Y * homography_matrix[2, 1] + 1);
      new_point.X = (float)(point.X * homography_matrix[0, 0] + point.Y * homography_matrix[0, 1] + homography_matrix[0, 2]) / divider;
      new_point.Y = (float)(point.X * homography_matrix[1, 0] + point.Y * homography_matrix[1, 1] + homography_matrix[1, 2]) / divider;
      return new_point;
    }
  }
}
