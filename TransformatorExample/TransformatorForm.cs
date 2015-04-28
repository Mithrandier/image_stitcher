using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Matcher;
using Morpher;

namespace TransformatorExample {
  public partial class TransformatorForm : Form {
    FeaturedImage image_left, image_right;
    FlannMatcher matcher;
    MatchesPresenter matches_presenter;
    Emgu.CV.HomographyMatrix transform;
    MatrixPresenter matrix_presenter;

    public TransformatorForm() {
      InitializeComponent();
      matrix_presenter = new MatrixPresenter(panelHomoMatrix);
    }

    delegate void Procedure();
    void UseTimer(Procedure proc) {
      this.Cursor = Cursors.WaitCursor;
      var timer = System.Diagnostics.Stopwatch.StartNew();
      proc.Invoke();
      timer.Stop();
      textTimer.Text = timer.ElapsedMilliseconds.ToString();
      this.Cursor = Cursors.Default;
    }

    //
    // SEGMENTS
    //

    private void buttonSavePan_Click(object sender, EventArgs e) {
      if (pictureMerged.Image == null)
        return;
      if (savePanDialog.ShowDialog() != DialogResult.OK)
        return;
      pictureMerged.Image.Save(savePanDialog.FileName);
    }

    private void buttonAddSegments_Click(object sender, EventArgs e) {
      String[] filenames = new String[2];
      for (int iFile = 0; iFile < filenames.Length; iFile++) {
        if (loadImagesDialog.ShowDialog() != DialogResult.OK)
          return;
        else
          filenames[iFile] = loadImagesDialog.FileName;
      }
      image_left = new FeaturedImage(filenames[0]);
      textFeaturesNum1.Text = image_left.Features.Length.ToString();
      image_right = new FeaturedImage(filenames[1]);
      textFeaturesNum2.Text = image_right.Features.Length.ToString();

      UseTimer(() => {
        matcher = new FlannMatcher(image_left, image_right);
        matcher.Match();
        scrollLimit.Enabled = true;
        this.matches_presenter = new MatchesPresenter(image_left, image_right, pictureMatches);
        RenderMatches();
      });
      tabControlMain.SelectedTab = tabPageMatching;
    }

    //
    // MATCHING
    //

    void RenderMatches() {
      matches_presenter.Render(CurrentMatches());
    }

    private void scrollLimit_Scroll(object sender, ScrollEventArgs e) {
      if (!matcher.Matched)
        return;
      RenderMatches();
    }

    KeyPointsPair[] CurrentMatches() {
      int limit = Math.Max(matcher.Matches.Length * scrollLimit.Value / 100, 10);
      return matcher.Matches.Take(limit).ToArray();
    }

    private void buttonUseMatches_Click(object sender, EventArgs e) {
      tabControlMain.SelectedTab = tabPageMerging;
      this.transform = matcher.DefineHomography(CurrentMatches().Length);
      matrix_presenter.Display(transform);
      MergeImages();
    }

    //
    // MERGING
    //

    private void buttonMerge_Click(object sender, EventArgs e) {
      if (transform == null)
        return;
      MergeImages();
    }

    void MergeImages() {
      UseTimer(() => {
        var current_matrix = matrix_presenter.FixCurrentMatrix(transform);
        var result = new Morpher.Morpher(image_left.Image, image_right.Image, transform).Transform(current_matrix);
        pictureMerged.Image = result;
      });
    }

    private void buttonRestore_Click(object sender, EventArgs e) {
      matrix_presenter.Display(transform);
    }

    private void scrollFeaturesLimitForMerging_Scroll(object sender, ScrollEventArgs e) {
      if (!matcher.Matched)
        return;
      scrollLimit.Value = scrollFeaturesLimitForMerging.Value;
      this.transform = matcher.DefineHomography(CurrentMatches().Length);
      matrix_presenter.Display(transform);
      MergeImages();
    }
  }
}
