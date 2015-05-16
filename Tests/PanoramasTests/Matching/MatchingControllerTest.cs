using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panoramas;
using Panoramas.Matching;

namespace PanoramasBaseTests {
  [TestClass]
  public class MatchingControllerTest {
    [TestMethod]
    public void ItCanBeCreatedWithSegments() {
      Factory.AMatchingController();
    }

    [TestMethod]
    public void ItCanBeCreatedWithNoSegments() {
      new MatchingController(new Segment[0]);
    }

    [TestMethod]
    public void ItProvidesMatchBetweenSegments() {
      var segment1 = Factory.ASegment();
      var segment2 = Factory.ASegment();
      var map = new MatchingController(new Segment[] { segment1, segment2 });
      Assert.IsNotNull(map.MatchBetween(segment1, segment2));
      Assert.IsNotNull(map.MatchBetween(segment2, segment1));
    }

    [TestMethod]
    public void ItProvidesClosestSegment() {
      var segment_query = Factory.ASegment();
      var segment2 = Factory.ASegment();
      var segment3 = Factory.ASegment();
      var map = new MatchingController(new Segment[] { segment_query, segment2, segment3 });
      var domain = new Segment[] {segment2, segment3};
      var closest = map.ClosestTo(segment_query);
      Assert.IsTrue(domain.Contains(closest));
      Assert.IsTrue(map.ClosestTo(segment_query, domain) == closest);
    }
  }
}
