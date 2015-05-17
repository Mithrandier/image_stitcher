using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public interface IFactory {
    IImage Image(String name, System.Drawing.Bitmap bitmap);
    ISegment Segment(IImage image, ITransformation transformation);
    ITransformation Transformation();

    IPanoramaSegments PanoramaSegments(IImage[] images);
    IPanoramaRelations PanoramaRelations(IPanoramaSegments panorama, List<ISegmentsRelation> relations);
    IPanoramaComplete PanoramaComplete(IPanoramaRelations panorama, ISegment[] segments);

    IStitcher Stitcher(IImage[] images);
    IAnalyzer Analyzer();
    IBuilder Builder();
    IResultPresenter ResultPresenter();
  }
}
