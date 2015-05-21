using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panoramas;
using Panoramas.FeaturesAnalyzer;

namespace PanoramasBaseTests {
  [TestClass]
  public class AnalyzerTest {
    [TestMethod]
    public void ItCanBeCreatedWithAFactory() {
      Analyzer();
    }

    [TestMethod]
    public void ItReturnesRelationsAfterAnalysis() {
      var pan_images = TestFactory.PanoramaImages();
      var pan_relations = Analyzer().Analyze(pan_images);
      Assert.IsNotNull(pan_relations);
      Assert.IsTrue(pan_relations is IPanoramaRelations);
      Assert.IsTrue(pan_relations.Images == pan_images.Images);
      Assert.IsTrue(pan_relations.Relations.Count == factorial(pan_images.Images.Length));        
      var neighbours = pan_relations.NeighboursOf(pan_images.Images[0]);
      Assert.IsTrue(neighbours.Length == 1 && neighbours[0] == pan_images.Images[1]);
      Assert.IsNotNull(pan_relations.MatchBetween(pan_images.Images[0], pan_images.Images[1]));
    }

    Analyzer Analyzer() {
      return new Analyzer(TestFactory.PanoramasFactory());
    }

    int factorial(int basis) {
      if (basis > 1)
        return basis * factorial(basis - 1);
      else
        return basis;
    }
  }
}
