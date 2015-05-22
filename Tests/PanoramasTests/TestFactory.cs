using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panoramas;
using Panoramas.Defaults;

namespace PanoramasBaseTests {
  public class TestFactory {
    public const string VALID_FILE_NAME = "..\\..\\Resources\\2.jpg";
    public const string VALID_FILE_NAME_2 = "..\\..\\Resources\\1.jpg";
    public const string INVALID_FILE_NAME = "..\\..\\Resources\\nonexistent.jpg";

    public static IFactory PanoramasFactory() {
      return new Panoramas.FeaturedTrees.PrivateFactory();
    }

    public static Bitmap Bitmap() {
      return new Bitmap(VALID_FILE_NAME);
    }

    public static Segment Segment() {
      return new Segment(Image(), Transformation());
    }

    public static IImage Image() {
      return PanoramasFactory().Image(VALID_FILE_NAME, Bitmap());
    }

    public static List<IImage> Images() {
      var images = new List<IImage>() { Image() };
      images.Add(PanoramasFactory().Image(VALID_FILE_NAME_2, Bitmap()));
      return images;
    }

    public static List<IImagesRelation> ImagesRelations(List<IImage> images = null) {
      if (images == null)
        images = Images();
      var pan_images = PanoramaImages(images);
      var relations = new List<IImagesRelation>();
      relations.Add(new Panoramas.FeaturesAnalyzer.SegmentsPair(pan_images.Images[0], pan_images.Images[1]));
      relations.Add(new Panoramas.FeaturesAnalyzer.SegmentsPair(pan_images.Images[1], pan_images.Images[0]));
      return relations;
    }

    public static IImageTransformed ImageTransformed() {
      return Segment();
    }

    public static ITransformation Transformation() {
      return PanoramasFactory().Transformation();
    }

    public static IPanoramaImages PanoramaImages(List<IImage> images = null) {
      if (images == null)
        images = Images();
      return PanoramasFactory().PanoramaImages(images.ToArray());
    }

    public static IPanoramaRelations PanoramaRelations(List<IImage> images = null) {
      if (images == null)
        images = Images();
      var  pan_images = PanoramaImages(images);
      var relations = ImagesRelations(images);
      return PanoramasFactory().PanoramaRelations(PanoramaImages(), relations);
    }

    public static IPanoramaTransformations PanoramaTransformations(IPanoramaRelations pan_relations = null) {
      if (pan_relations == null)
        pan_relations = TestFactory.PanoramaRelations();
      var transformations = new IImageTransformed[] { TestFactory.ImageTransformed(), TestFactory.ImageTransformed() };
      return PanoramasFactory().PanoramaTransformations(pan_relations, transformations);
    }

    public static Panoramas.Processors.IAnalyzer Analyzer() {
      return new Panoramas.FeaturesAnalyzer.Analyzer(PanoramasFactory());
    }
  }
}
