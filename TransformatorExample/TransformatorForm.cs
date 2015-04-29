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
  public partial class TransformatorForm : BaseForm {
    FeaturedImage image_left, image_right;
    FlannMatcher matcher;
    MatchesPresenter matches_presenter;
    Emgu.CV.HomographyMatrix transform;
    MatrixPresenter matrix_presenter;

    public TransformatorForm() {
      InitializeComponent();
      matrix_presenter = new MatrixPresenter(panelHomoMatrix);
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
      LogTime("Loading images", () => {
        image_left = new FeaturedImage(filenames[0]);
        image_right = new FeaturedImage(filenames[1]);
      });
      LogTime("Defining features", () => {
        textFeaturesNum1.Text = image_left.Features.Length.ToString();
        textFeaturesNum2.Text = image_right.Features.Length.ToString();
      });
      LogTime("Matching images", () => {
        this.matcher = new FlannMatcher(image_left, image_right);
        matcher.Match();
        scrollLimit.Enabled = true;
      });
      LogTime("Rendering matches", () => {
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
      RedefineHomography();
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
      LogTime("Merging images", () => {
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
      RedefineHomography();
    }

    void RedefineHomography() {
      this.transform = matcher.DefineHomography(CurrentMatches().Length);
      matrix_presenter.Display(transform);
      MergeImages();
    }
  }
}
