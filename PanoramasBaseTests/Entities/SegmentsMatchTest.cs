using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panoramas;
using Panoramas.Matching;

namespace PanoramasBaseTests {
  /// <summary>
  /// Summary description for SegmentsMatchTest
  /// </summary>
  [TestClass]
  public class SegmentsMatchTest {
    public SegmentsMatchTest() {
    }

    [TestMethod]
    public void ItCanBeCreatedWithTwoSegments() {
      Factory.ASegmentsMatch();
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void ItRequiresSegmentsToBePresent() {
      new SegmentsMatch(Factory.ASegment(), null);
    }

    [TestMethod]
    public void ItProvidesDistanceBetweenSegments() {
      Assert.IsTrue(Factory.ASegmentsMatch().Distance() >= 0);
    }

    [TestMethod]
    public void ItProvidesMatchesBetweenSegments() {
      var matches = Factory.ASegmentsMatch().Matches();
      Assert.IsInstanceOfType(matches, typeof(KeyPointsPair[]));
      Assert.AreEqual(matches.Length, SegmentsMatch.MIN_MATCHES_COUNT);
    }

    [TestMethod]
    public void ItProvidesTransformationBetweenSegments() {
      var transformation = Factory.ASegmentsMatch().Transformation();
      Assert.IsNotNull(transformation);
      Assert.IsInstanceOfType(transformation, typeof(Transformation));
    }

    [TestMethod]
    public void ItAllowsToUseMoreMatches() {
      var match = Factory.ASegmentsMatch();
      var first_matches = match.Matches();
      match.LimitMatchesBy(100);
      var more_matches = match.Matches();
      Assert.IsTrue(first_matches.Length < more_matches.Length);
    }
  }
}
