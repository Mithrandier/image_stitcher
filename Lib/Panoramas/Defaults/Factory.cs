using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.Defaults {
  public abstract class Factory : IFactory {
    public IImage Image(string name, System.Drawing.Bitmap bitmap) {
      return new Segment(name, bitmap);
    }

    public ISegment Segment(IImage image, ITransformation transformation) {
      return new Segment(image.Name, image.Bitmap);
    }

    public ITransformation Transformation() {
      return new Transformation();
    }

    public IPanoramaSegments PanoramaSegments(IImage[] images) {
      return new PanoramaSegments(images);
    }

    public IPanoramaRelations PanoramaRelations(IPanoramaSegments panorama, List<ISegmentsRelation> relations) {
      return new PanoramaRelations(panorama, relations);
    }

    public IPanoramaComplete PanoramaComplete(IPanoramaRelations panorama, ISegment[] segments) {
      return new PanoramaComplete(panorama, segments);
    }

    public IStitcher Stitcher(IImage[] images) {
      return new Stitcher(this, images);
    }

    public abstract IAnalyzer Analyzer();
    public abstract IBuilder Builder();
    public abstract IResultPresenter ResultPresenter();
  }
}
