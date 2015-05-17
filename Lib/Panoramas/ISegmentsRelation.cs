using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public interface ISegmentsRelation : IRelationControl {
    IImage BaseSegment { get; }
    IImage QuerySegment { get; }
    IImage[] Segments { get; }
    ISegmentsRelation ReversePair { get; set; }
    ITransformation GenerateTransformation();
    bool Includes(IImage segment);
    IImage PairOf(IImage segment);
  }
}
