using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public interface ISegmentsRelation : IRelationControl {
    Segment BaseSegment { get; }
    Segment QuerySegment { get; }
    Segment[] Segments { get; }
    ISegmentsRelation ReversePair { get; set; }
    Transformation GenerateTransformation();
    bool Includes(Segment segment);
    Segment PairOf(Segment segment);
  }
}
