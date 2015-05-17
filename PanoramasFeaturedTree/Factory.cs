using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.FeaturedTrees {
  public class Factory : Panoramas.Defaults.DefaultsFactory {
    public override ITransformation Transformation() {
      return new Panoramas.HomographyTransformer.Transformation();
    }

    public override IAnalyzer Analyzer() {
      return new Panoramas.FeaturesAnalyzer.Analyzer(this);
    }

    public override IBuilder Builder() {
      return new Panoramas.TreeBuilder.Builder(this);
    }

    public override IResultPresenter ResultPresenter() {
      return new Panoramas.IntegralPresenter.Presenter(this);
    }

    public IStitcher Stitcher(String[] files, System.Drawing.Bitmap[] bitmaps = null) {
      if (files.Length < 2 || files.Length != bitmaps.Length)
        throw new ArgumentException("Not enough images");
      var images = new List<IImage>();
      for (int i = 0; i < files.Length; i++)
        images.Add(Image(files[i], bitmaps[i]));
      return Stitcher(images.ToArray());
    }
  }
}
