using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public class Panorama {
    List<Segment> segments;

    public Panorama() {
      this.segments = new List<Segment>();
    }

    public bool HasSegment(Segment segment) {
      return segments.Contains(segment);
    }

    public bool AddSegment(Segment segment) {
      if (HasSegment(segment))
        return false;
      segments.Add(segment);
      return true;
    }

    public Bitmap Draw() {
      return null;
    }
  }
}
