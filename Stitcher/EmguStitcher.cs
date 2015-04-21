using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Structure;

namespace Stitcher {
  public class EmguStitcher : IStitcher {
    Emgu.CV.Stitching.Stitcher _stitcher;

    public EmguStitcher() {
      _stitcher = new Emgu.CV.Stitching.Stitcher(false);
    }

    public System.Drawing.Image Stitch(System.Drawing.Image[] segments) {
      var result_emgu = _stitcher.Stitch(ConvertImagesToEmgu(segments));
      return result_emgu.ToBitmap();
    }

    Emgu.CV.Image<Bgr, Byte>[] ConvertImagesToEmgu(System.Drawing.Image[] images) {
      return images.Select((image) => new Emgu.CV.Image<Bgr, Byte>(image as System.Drawing.Bitmap)).ToArray();
    }
  }
}
