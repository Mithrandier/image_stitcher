using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphic;

namespace Sift.Searching {
  public class GaussPyramid {
    IPicture initial_picture;
    List<Octave> Octaves { get; set; }
    public GaussPyramid(IPicture picture) {
      this.initial_picture = picture;
      this.Octaves = new List<Octave>();
    }

    public void Build(uint octave_size, double scale_step, uint octaves_count) {
      Octaves.Clear();
      double scale = 1;
      int sigma = 2;
      Octaves.Add(new Octave(initial_picture, scale, octave_size));
      Octaves.Last().Build(sigma);
      while (Octaves.Count != octaves_count) {
        var last_picture = Octaves.Last().Pictures.Last();
        scale /= scale_step;
        var next_octave = new Octave(last_picture.Scale(scale), scale, octave_size);
        Octaves.Add(next_octave);
        Octaves.Last().Build(sigma);
      }
    }
  }
}
