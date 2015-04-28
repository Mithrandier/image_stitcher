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
    FeaturedImage image_left, image_right;
    MatchesPresenter matches_presenter;
    KeyPointsPair[] last_matches;
    Emgu.CV.HomographyMatrix transform;

    public TransformatorForm() {
      InitializeComponent();
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

    private void buttonMerge_Click(object sender, EventArgs e) {
      if (transform == null)
        return;
      UseTimer(() => {
        var result = new Morpher(image_left.Image, image_right.Image, transform).Transform(CurrentMatrix());
        pictureMerged.Image = result;
      });
    }

    void DisplayTransformMatrix() {
      if (transform == null)
        return;
      textMatrix00.Text = transform[0, 0].ToString();
      textMatrix10.Text = transform[1, 0].ToString();
      textMatrix20.Text = transform[2, 0].ToString();

      textMatrix01.Text = transform[0, 1].ToString();
      textMatrix11.Text = transform[1, 1].ToString();
      textMatrix21.Text = transform[2, 1].ToString();

      textMatrix02.Text = transform[0, 2].ToString();
      textMatrix12.Text = transform[1, 2].ToString();
      textMatrix22.Text = transform[2, 2].ToString();      
    }

    Emgu.CV.HomographyMatrix CurrentMatrix() {
      if (transform == null)
        return null;
      var matrix = this.transform.Clone();
      matrix[0, 0] = Double.Parse(textMatrix00.Text);
      matrix[1, 0] = Double.Parse(textMatrix10.Text);
      matrix[2, 0] = Double.Parse(textMatrix20.Text);

      matrix[0, 1] = Double.Parse(textMatrix01.Text);
      matrix[1, 1] = Double.Parse(textMatrix11.Text);
      matrix[2, 1] = Double.Parse(textMatrix21.Text);

      matrix[0, 2] = Double.Parse(textMatrix02.Text);
      matrix[1, 2] = Double.Parse(textMatrix12.Text);
      matrix[2, 2] = Double.Parse(textMatrix22.Text);
      return matrix;
    }

    private void buttonRestore_Click(object sender, EventArgs e) {
      DisplayTransformMatrix();
    }

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
        Matchers.FlannMatcher matcher = new Matchers.FlannMatcher(image_left, image_right);
        this.last_matches = matcher.Match().OrderBy((pair) => { return pair.Distance; }).ToArray();
        this.transform = matcher.DefineHomography();
        scrollLimit.Enabled = true;
        this.matches_presenter = new MatchesPresenter(image_left, image_right, pictureMatches);
        RenderMatches();
      });
      if (transform != null)
        DisplayTransformMatrix();
      tabControlMain.SelectedTab = tabPageMatching;
    }

    private void scrollLimit_Scroll(object sender, ScrollEventArgs e) {
      if (last_matches == null)
        return;
      RenderMatches();
    }

    void RenderMatches() {
      matches_presenter.Render(currentMatches());
    }

    KeyPointsPair[] currentMatches() {
      int limit = last_matches.Length * scrollLimit.Value / 100;
      return last_matches.Take(limit).ToArray();
    }

    private void buttonUseMatches_Click(object sender, EventArgs e) {
      tabControlMain.SelectedTab = tabPageMerging;
    }
  }
}
