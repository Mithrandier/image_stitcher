using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panoramas;

namespace PanoramasBaseTests {
  class Factory {
    public const string VALID_FILE_NAME = "..\\..\\Resources\\2.jpg";
    public const string INVALID_FILE_NAME = "..\\..\\Resources\\?.jpg";

    public static Bitmap ABitmap() {
      return new Bitmap(VALID_FILE_NAME);
    }

    public static Segment ASegment() {
      return new Segment(VALID_FILE_NAME);
    }

    public static SegmentsMatch ASegmentsMatch() {
      return new SegmentsMatch(ASegment(), ASegment());
    }

    public static Transformation ATransformation() {
      return new Transformation();
    }

    public static SegmentsMap ASegmentsMap() {
      var segments = new Segment[] { ASegment(), ASegment() };
      return new SegmentsMap(segments);
    }

    public static TreeNode ATreeNode() {
      return new TreeNode(Factory.ASegment());
    }
  }
}
