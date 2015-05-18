using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.Defaults {
  public abstract class DefaultsFactory : IFactory, IPublicFactory {

    public IImageTransformed ImageTransformed(IImage image, ITransformation transformation) {
      return new Segment(image.Name, image.Bitmap, transformation);
    }

    public IPanoramaImages PanoramaImages(IImage[] images) {
      return new PanoramaImages(images);
    }

    public IPanoramaRelations PanoramaRelations(IPanoramaImages panorama, List<IImagesRelation> relations) {
      return new PanoramaRelations(panorama, relations);
    }

    public IPanoramaTransformations PanoramaTransformations(IPanoramaRelations panorama, IImageTransformed[] segments) {
      return new PanoramaTransformations(panorama, segments);
    }

    public IStitcher Stitcher(IImage[] images) {
      return new Stitcher(this, images);
    }

    public IImage Image(string name, System.Drawing.Bitmap bitmap) {
      return new Segment(name, bitmap);
    }

    public IStitcher Stitcher(String[] files, System.Drawing.Bitmap[] bitmaps = null) {
      if (files.Length < 2 || files.Length != bitmaps.Length)
        throw new ArgumentException("Not enough images");
      var images = new List<IImage>();
      for (int i = 0; i < files.Length; i++)
        images.Add(Image(files[i], bitmaps[i]));
      return Stitcher(images.ToArray());
    }

    public abstract IAnalyzer Analyzer();
    public abstract IBuilder Builder();
    public abstract IPresenter Presenter();
    public abstract ITransformation Transformation();
  }
}
