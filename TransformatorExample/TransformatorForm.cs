using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransformatorExample {
  public partial class TransformatorForm : Form {
    FeaturedImage image1, image2;
    IMatcher matcher = new Matchers.FlannMatcher();
    KeyPointsPair[] last_matches;
    MatchesPresenter matches_presenter;

    public TransformatorForm() {
      InitializeComponent();
    }

    private void buttonLoad_Click(object sender, EventArgs e) {
      if (loadImagesDialog.ShowDialog() != DialogResult.OK)
        return;
      if (loadImagesDialog.FileNames.Length != 2)
        return;
      image1 = new FeaturedImage(loadImagesDialog.FileNames[0]);
      textFeaturesNum1.Text = image1.Features.Length.ToString();
      image2 = new FeaturedImage(loadImagesDialog.FileNames[1]);
      textFeaturesNum2.Text = image2.Features.Length.ToString();
      UseTimer(() => {
        last_matches = matcher.Match(image1, image2);
      });
      scrollLimit.Enabled = true;
      this.matches_presenter = new MatchesPresenter(image1, image2, pictureMatches);
      RenderMatches();
    }

    delegate void Procedure();
    void UseTimer(Procedure proc) {
      var timer = System.Diagnostics.Stopwatch.StartNew();
      proc.Invoke();
      timer.Stop();
      textTimer.Text = timer.ElapsedMilliseconds.ToString();
    }

    private void scrollLimit_Scroll(object sender, ScrollEventArgs e) {
      RenderMatches();
    }

    void RenderMatches() {
      if (last_matches == null)
        return;
      int limit = last_matches.Length * scrollLimit.Value / 100;
      var sorted = last_matches.OrderBy((pair) => { return pair.Distance; }).Take(limit).ToArray();
      matches_presenter.Render(sorted);
    }
  }
}
