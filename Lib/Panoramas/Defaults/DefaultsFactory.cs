using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.Defaults {
  public abstract class DefaultsFactory : IFactory {
    public IImage Image(string name, System.Drawing.Bitmap bitmap) {
      return new Segment(name, bitmap);
    }

    public IImageTransformed Segment(IImage image, ITransformation transformation) {
      return new Segment(image.Name, image.Bitmap, transformation);
    }

    public IPanoramaImages PanoramaSegments(IImage[] images) {
      return new PanoramaSegments(images);
    }

    public IPanoramaRelations PanoramaRelations(IPanoramaImages panorama, List<IImagesRelation> relations) {
      return new PanoramaRelations(panorama, relations);
    }

    public IPanoramaTransformations PanoramaComplete(IPanoramaRelations panorama, IImageTransformed[] segments) {
      return new PanoramaComplete(panorama, segments);
    }

    public IStitcher Stitcher(IImage[] images) {
      return new Stitcher(this, images);
    }

    public abstract IAnalyzer Analyzer();
    public abstract IBuilder Builder();
    public abstract IResultPresenter ResultPresenter();
    public abstract ITransformation Transformation();
  }
}
