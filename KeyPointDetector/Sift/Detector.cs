using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphic;

namespace KeyPointDetector.Sift {
  public class Detector : IDetector {
    IPicture picture;
    public Detector(IPicture picture) {
      this.picture = picture;
    }

    public CorePoint[] DetectPoints() {
      var initial_set = AnalyzePyramid();
      var precised_set = PrecisePoints(initial_set);
      return precised_set;
    }

    public KeyPoint[] ExtractKeyPoints() {
      var precised_set = DetectPoints();
      var described_set = GenerateDescriptors(precised_set);
      return described_set;
    }

    CorePoint[] AnalyzePyramid() {
      return Dogs.FindExtrems();
    }

    CorePoint[] PrecisePoints(CorePoint[] initial_set) {
      return initial_set;
    }

    KeyPoint[] GenerateDescriptors(CorePoint[] precised_set) {
      return precised_set.Select((point) => new Descriptor(point).Apply()).ToArray();
    }

    DogPyramid _dogs;
    DogPyramid Dogs {
      get {
        if (_dogs == null) {
          var gauss = new GaussPyramid(picture);
          _dogs = new DogPyramid(gauss);
        }
        return _dogs;
      }
    }
  }
}
