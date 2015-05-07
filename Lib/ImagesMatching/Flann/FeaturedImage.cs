using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;

namespace ImagesMatching.Flann {
  public class FeaturedImage {
    public Bitmap Image { get; protected set; }
    public int Width { get; private set; }
    public int Height { get; private set; }

    public FeaturedImage(Bitmap image) {
      this.Image = image;
      this.Width = Image.Width;
      this.Height = Image.Height;
      var detector = new Emgu.CV.Features2D.SIFTDetector();
      _features = detector.DetectFeatures(new Emgu.CV.Image<Gray, byte>(Image), null);
    }
    public FeaturedImage(String filename) : this(new Bitmap(filename)) { }

    Emgu.CV.Features2D.ImageFeature<float>[] _features;
    public Emgu.CV.Features2D.ImageFeature<float>[] Features {
      get { return _features; }
    }
  }
}
