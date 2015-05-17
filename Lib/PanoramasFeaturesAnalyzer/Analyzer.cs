using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.FeaturesAnalyzer {
  public class Analyzer : IAnalyzer {
    IFactory factory;

    public Analyzer(IFactory factory) {
      this.factory = factory;
    }

    public IPanoramaRelations Analyze(IPanoramaImages panorama_segment) {
      var relations = generateMatches(panorama_segment.Images);
      return factory.PanoramaRelations(panorama_segment, relations);
    }

    static List<IImagesRelation> generateMatches(IImage[] segments) {
      var featured_segments = segments.Select((s) => s.Bitmap).ToArray();
      var matches = new List<IImagesRelation>();
      var matched_segments = new List<IImage>();
      int pairs_count = 0;
      for (int iBase = 0; iBase < segments.Length; iBase++) {
        var base_segment = segments[iBase];
        for (int iQuery = 0; iQuery < segments.Length; iQuery++) {
          if (iBase == iQuery)
            continue;
          var matched_segment = segments[iQuery];
          var match = new SegmentsPair(base_segment, matched_segment);
          if (matched_segments.Contains(matched_segment)) {
            var prev_match = matches.Find((m) => m.BaseSegment == matched_segment && m.QuerySegment == base_segment);
            match.ReversePair = prev_match;
            pairs_count += 1;
          } else {
            pairs_count -= 1;
          }
          matches.Add(match);
        }
        matched_segments.Add(base_segment);
      }
      if (pairs_count != 0)
        throw new Exception("Matches generator error!");
      return matches;
    }
  }
}
