﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panoramas;
using Panoramas.Matching;
using Panoramas.Tree;

namespace PanoramasBaseTests {
  class Factory {
    public const string VALID_FILE_NAME = "..\\..\\Resources\\2.jpg";
    public const string VALID_FILE_NAME_2 = "..\\..\\Resources\\1.jpg";
    public const string INVALID_FILE_NAME = "..\\..\\Resources\\?.jpg";

    public static Bitmap ABitmap() {
      return new Bitmap(VALID_FILE_NAME);
    }

    public static Segment ASegment() {
      return new Segment(VALID_FILE_NAME);
    }

    public static SegmentsPair ASegmentsMatch() {
      return new SegmentsPair(ASegment(), ASegment());
    }

    public static Transformation ATransformation() {
      return new Transformation();
    }

    public static MatchingController AMatchingController() {
      var segments = new Segment[] { ASegment(), ASegment() };
      return new MatchingController(segments);
    }

    public static TreeNode ATreeNode() {
      return new TreeNode(Factory.ASegment());
    }
  }
}
