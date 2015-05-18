using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public interface IImagesRelation : IRelationControl {
    IImage BaseSegment { get; }
    IImage QuerySegment { get; }
    IImage[] Segments { get; }
    IImagesRelation ReversePair { get; set; }
    ITransformation GenerateTransformation();
    bool Includes(IImage image);
    IImage PairOf(IImage image);
  }
}
