using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panoramas.Processors;

namespace Panoramas.FeaturesAnalyzer {
  public class Analyzer : IAnalyzer {
    IFactory factory;

    public Analyzer(IFactory factory) {
      this.factory = factory;
    }

    public IPanoramaRelations Analyze(IPanoramaImages panorama_segment) {
      var relations = generateMatches(panorama_segment.Images.ToArray());
      return factory.PanoramaRelations(panorama_segment, relations);
    }

    static List<IImagesRelation> generateMatches(IImage[] segments) {
      var featured_segments = segments.Select((s) => s.Bitmap).ToArray();
      var matches = new List<IImagesRelation>();
      var matched_segments = new List<IImage>();
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
          }
          matches.Add(match);
        }
        matched_segments.Add(base_segment);
      }
      foreach (var match in matches) {
        if (match.ReversePair == null)
          throw new NullReferenceException("Cannot find a reverse pair");
      }
      return matches;
    }


    public bool AddImage(IPanoramaRelations panorama_relations, IImage image) {
      if (panorama_relations.Images.Contains(image))
        return false;
      var new_relations = new List<SegmentsPair>();
      foreach (var old_image in panorama_relations.Images) {
        var match = new SegmentsPair(image, old_image);
        var reverse_match = new SegmentsPair(old_image, image);
        match.ReversePair = reverse_match;
        new_relations.Add(match);
        new_relations.Add(reverse_match);
      }
      foreach (var match in new_relations) {
        if (match.ReversePair == null)
          throw new NullReferenceException("Cannot find a reverse pair");
      }
      panorama_relations.Images.Add(image);
      panorama_relations.Relations.AddRange(new_relations);
      return true;
    }

    public bool RemoveImage(IPanoramaRelations panorama_relations, IImage image) {
      var toremove_relations = panorama_relations.Relations.Where((r) => r.Includes(image));
      if (toremove_relations.Count() < 1)
        return false;
      foreach (var relation in toremove_relations)
        panorama_relations.Relations.Remove(relation);
      panorama_relations.Images.Remove(image);
      return true;
    }
  }
}
