using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Panoramas;
using Panoramas.Matching;
using Panoramas.Morphing;
using FormTools;

namespace TransformatorExample {
  public partial class TransformatorForm : BaseForm {
    MatrixPresenter matrix_presenter;
    BrowseablePicture picturebox_matching, picturebox_merging;
    Segment[] segments;

    public TransformatorForm() {
      InitializeComponent();
      matrix_presenter = new MatrixPresenter(this.panelHomoMatrix);
      picturebox_matching = new BrowseablePicture(this, this.pictureMatches);
      picturebox_merging = new BrowseablePicture(this, this.pictureMerged);
    }

    //
    // SEGMENTS
    //

    const int MINIMUM_SEGMENTS = 2;
    private void buttonAddSegments_Click(object sender, EventArgs e) {
      var dialog = addSegmentsDialog;
      if (dialog.ShowDialog() != DialogResult.OK)
        return;
      var filenames = dialog.FileNames;
      if (filenames.Length < MINIMUM_SEGMENTS)
        return;
      this.segments = filenames.Select((f) => new Segment(f)).ToArray();
      InitStitcher();
      SetLimit(scrollLimit.Value);
      RenderMatches();
      scrollLimit.Enabled = true;
      tabControlMain.SelectedTab = tabPageMatching;
    }

    //
    // MATCHING
    //

    private void scrollLimit_Scroll(object sender, ScrollEventArgs e) {
      if (!StitcherReady())
        return;
      SetLimit(scrollLimit.Value);
      RenderMatches();
    }

    private void buttonUseMatches_Click(object sender, EventArgs e) {
      if (!StitcherReady())
        return;
      RenderMatrix();
      MergeImages();
      tabControlMain.SelectedTab = tabPageMerging;
    }

    //
    // MERGING
    //

    private void buttonMerge_Click(object sender, EventArgs e) {
      if (!StitcherReady())
        return;
      SetLimit(scrollFeaturesLimitForMerging.Value);
      MergeImages();
    }

    private void buttonRestore_Click(object sender, EventArgs e) {
      RenderMatrix();
    }

    private void buttonSavePan_Click(object sender, EventArgs e) {
      if (pictureMerged.Image == null)
        return;
      if (savePanDialog.ShowDialog() != DialogResult.OK)
        return;
      pictureMerged.Image.Save(savePanDialog.FileName);
    }

    //
    // STITCHER STUFF
    //

    Stitcher stitcher;
    void InitStitcher() {
      this.stitcher = new Stitcher(segments);
    }

    bool StitcherReady() {
      return stitcher != null;
    }

    void RenderMatches() {
      picturebox_matching.Image = stitcher.MatchTwo(segments[0], segments[1]);
    }

    void SetLimit(int percent) {
      stitcher.SetLimit(segments[0], segments[1], percent);
    }

    void MergeImages() {
      picturebox_merging.Image = stitcher.StitchTwo(segments[0], segments[1]);
    }

    void RenderMatrix() {
      matrix_presenter.Display(stitcher.GetTransformation(segments[0], segments[1]));
    }
  }
}
