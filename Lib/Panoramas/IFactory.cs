using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public interface IFactory {
    IImage Image(String name, System.Drawing.Bitmap bitmap);
    IImageTransformed Segment(IImage image, ITransformation transformation);
    ITransformation Transformation();

    IPanoramaImages PanoramaSegments(IImage[] images);
    IPanoramaRelations PanoramaRelations(IPanoramaImages panorama_segments, List<IImagesRelation> relations);
    IPanoramaTransformations PanoramaComplete(IPanoramaRelations panorama_relations, IImageTransformed[] segments);

    IStitcher Stitcher(IImage[] images);
    IAnalyzer Analyzer();
    IBuilder Builder();
    IResultPresenter ResultPresenter();
  }
}
