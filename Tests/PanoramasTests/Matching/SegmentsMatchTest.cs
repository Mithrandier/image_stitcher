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
      Assert.IsInstanceOfType(matches, typeof(ImagesMatching.KeyPointsPair[]));
      Assert.AreEqual(matches.Length, SegmentsMatch.MIN_MATCHES_COUNT);
    }

    [TestMethod]
    public void ItProvidesTransformationBetweenSegments() {
      var transformation = Factory.ASegmentsMatch().GenerateTransformation();
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

    [TestMethod]
    public void ItAllowsToCheckSegmentPresence() {
      var present_segment = Factory.ASegment();
      var match = new SegmentsMatch(present_segment, Factory.ASegment());
      var not_present_segment = Factory.ASegment();
      Assert.IsTrue(match.Includes(present_segment));
      Assert.IsFalse(match.Includes(not_present_segment));
      var both_segment = new Segment[] { present_segment, not_present_segment };
      Assert.IsTrue(match.IncludesAnyOf(both_segment));
    }

    [TestMethod]
    public void ItProvidesOpponentSegment() {
      var segment_query = Factory.ASegment();
      var segment_pair = Factory.ASegment();
      var match = new SegmentsMatch(segment_query, segment_pair);
      Assert.AreEqual(match.PairOf(segment_query), segment_pair);
      Assert.AreEqual(match.PairOf(segment_pair), segment_query);
    }
  }
}
