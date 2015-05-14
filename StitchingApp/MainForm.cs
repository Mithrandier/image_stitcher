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
using FormTools;

namespace TransformatorExample {
  public partial class MainForm : BaseForm {
    BrowseablePicture picturebox_matching, picturebox_merging;
    Segment[] segments;

    public MainForm() {
      Logger.Logger.Info(String.Format("\n\n****************Application started at {0}*************\n\n", DateTime.Now));
      InitializeComponent();
      picturebox_matching = new BrowseablePicture(this, this.pictureMatches);
      picturebox_merging = new BrowseablePicture(this, this.pictureMerged);
      initSegmentsLoading();
      if (StitcherReady())
        MergeImages();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
      if (tabControlMain.SelectedTab == tabPageSegments && keyData == OpenFileShortCut)
          initSegmentsLoading();
      else if (tabControlMain.SelectedTab == tabPageMerging && keyData == SaveFileShortCut)
          initPanoramaSaving();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    //
    // SEGMENTS
    //

    private void buttonAddSegments_Click(object sender, EventArgs e) {
      initSegmentsLoading();
    }

    const int MINIMUM_SEGMENTS = 2;
    void initSegmentsLoading() {
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
      buttonGotoMatching.Enabled = true;
      buttonGotoMerge.Enabled = true;
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
      SetLimit(scrollLimit.Value);
      RenderMatches();
    }

    private void buttonUseMatches_Click(object sender, EventArgs e) {
      MergeImages();
    }

    private void buttonGotoFiles_Click(object sender, EventArgs e) {
      tabControlMain.SelectedTab = tabPageSegments;
    }

    //
    // MERGING
    //

    private void buttonSavePan_Click(object sender, EventArgs e) {
      initPanoramaSaving();
    }

    void initPanoramaSaving() {
      if (savePanDialog.ShowDialog() != DialogResult.OK)
        return;
      pictureMerged.Image.Save(savePanDialog.FileName);
    }

    private void buttonBackToMatching_Click(object sender, EventArgs e) {
      tabControlMain.SelectedTab = tabPageMatching;
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
      tabControlMain.SelectedTab = tabPageMerging;
      buttonSavePan.Enabled = true;
    }

    private void TransformatorForm_Load(object sender, EventArgs e) {

    }

    //
    // SHORTCUTS
    //

    Keys OpenFileShortCut {
      get { return Keys.Control | Keys.O; }
    }

    Keys SaveFileShortCut {
      get { return Keys.Control | Keys.S; }
    }
    
  }
}
