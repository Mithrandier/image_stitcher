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
using Panoramas.Logger;
using Panoramas.Matching;
using Panoramas.Morphing;
using FormTools;

namespace TransformatorExample {
  public partial class TransformatorForm : BaseForm {
    MatrixPresenter matrix_presenter;
    BrowseablePicture picturebox_matching, picturebox_merging;
    Segment[] segments;

    public TransformatorForm() {
      Logger.Info(String.Format("\n\n****************Application started at {0}*************\n\n", DateTime.Now));
      InitializeComponent();
      picturebox_matching = new BrowseablePicture(this, this.pictureMatches);
      picturebox_merging = new BrowseablePicture(this, this.pictureMerged);
      return;
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
      listFiles.Items.Clear();
      foreach (var filename in filenames)
        listFiles.Items.Add(filename);
      this.stitcher = null;
      this.segments = filenames.Select((f) => new Segment(f)).ToArray();
      InitializeSegmentsList();
      InitStitcher();
      SetLimit(scrollLimit.Value);
      RenderMatches();
      scrollLimit.Enabled = true;
    }

    void InitializeSegmentsList() {
      listSegmentsMatchLeft.Items.Clear();
      foreach (var segment in segments) {
        listSegmentsMatchLeft.Items.Add(segment);
      }
      listSegmentsMatchLeft.SelectedIndex = 0;
    }

    Segment CurrentSegment {
      get { return (Segment)listSegmentsMatchLeft.SelectedItem; }
    }

    Segment MatchedSegment {
      get { return (Segment)listSegmentsMatchRight.SelectedItem; }
    }

    private void listSegmentsMatchLeft_SelectedIndexChanged(object sender, EventArgs e) {
      listSegmentsMatchRight.Items.Clear();
      for (var i_item = 0; i_item < listSegmentsMatchLeft.Items.Count; i_item++)
        if (i_item != listSegmentsMatchLeft.SelectedIndex)
          listSegmentsMatchRight.Items.Add(listSegmentsMatchLeft.Items[i_item]);
      listSegmentsMatchRight.SelectedIndex = 0;
      UpdateCurrentMatch();
    }

    private void listSegmentsMatchRight_SelectedIndexChanged(object sender, EventArgs e) {
      UpdateCurrentMatch();
    }

    void UpdateCurrentMatch() {
      if (!StitcherReady())
        return;
      RenderMatches();
      OutputMatchDistance();
    }

    private void buttonGotoMatching_Click(object sender, EventArgs e) {
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
      MergeImages();
      tabControlMain.SelectedTab = tabPageMerging;
    }

    //
    // MERGING
    //

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
      LogTime("InitStitcher", () => {
        this.stitcher = new Stitcher(segments);
      });
    }

    bool StitcherReady() {
      return stitcher != null;
    }

    void RenderMatches() {
      LogTime("RenderMatches", () => {
        picturebox_matching.Image = stitcher.MatchTwo(CurrentSegment, MatchedSegment);
      });
    }

    void SetLimit(int percent) {
      stitcher.SetLimit(CurrentSegment, MatchedSegment, percent);      
    }

    void OutputMatchDistance() {
      LogTime("OutputMatchDistance", () => {
        textMatchDistance.Text = stitcher.DistanceBetween(CurrentSegment, MatchedSegment).ToString();
      });
    }

    void MergeImages() {
      LogTime("MergeImages", () => {
        picturebox_merging.Image = stitcher.StitchAll();
      });
    }
  }
}
