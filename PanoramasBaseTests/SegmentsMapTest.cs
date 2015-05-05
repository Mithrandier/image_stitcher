using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panoramas;

namespace PanoramasBaseTests {
  [TestClass]
  public class SegmentsMapTest {
    [TestMethod]
    public void ItCanBeCreatedWithSegments() {
      Factory.ASegmentsMap();
    }

    [TestMethod]
    public void ItCanBeCreatedWithNoSegments() {
      new SegmentsMap(new Segment[0]);
    }

    [TestMethod]
    public void ItDefinesCoreSegment() {
      var core = Factory.ASegmentsMap().CoreSegment();
      Assert.IsNotNull(core);
      Assert.IsInstanceOfType(core, typeof(Segment));
    }

    [TestMethod]
    public void ItProvidesMatchBetweenSegments() {
      var segment1 = Factory.ASegment();
      var segment2 = Factory.ASegment();
      var map = new SegmentsMap(new Segment[] { segment1, segment2 });
      Assert.IsNotNull(map.MatchBetween(segment1, segment2));
      Assert.IsNotNull(map.MatchBetween(segment2, segment1));
    }
  }
}
