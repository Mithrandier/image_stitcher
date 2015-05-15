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

namespace TransformatorExample {
  public partial class MainForm : BaseForm {
    Stitcher stitcher;
    ImageEditor.Editor picturebox_matching, picturebox_merging;
    ImageFilesManager.Manager images_manager;
    ImageFilesManager.ISelectableControl segments_thumbnails;
    ImageFilesManager.ISelectableControl segments_pair_list;
    IImagesMatch current_match;

    public MainForm() {
      InitializeComponent();
      picturebox_matching = new ImageEditor.Editor(this, this.pictureMatches);
      picturebox_merging = new ImageEditor.Editor(this, this.pictureMerged);
      picturebox_merging.BackgroundColor = Color.Black;
      images_manager = new ImageFilesManager.Manager();
      this.segments_thumbnails = images_manager.PresentAsListView(imagesContainer);
      this.segments_pair_list = images_manager.PresentAsPairsList(listSegmentsMatchLeft, listSegmentsMatchRight);
      this.segments_pair_list.AddSelectionChangeHandler(new EventHandler(this.currentMatch_Change));
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
      if (tabControlMain.SelectedTab == tabPageSegments && keyData == openFileShortCut)
          addSegments();
      else if (tabControlMain.SelectedTab == tabPageMerging && keyData == saveFileShortCut)
          savePanorama();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    //
    // SEGMENTS
    //

    private void buttonAddSegments_Click(object sender, EventArgs e) {
      addSegments();
    }

    void addSegments() {
      images_manager.LoadMore((filenames, bitmaps) => {
        this.stitcher = new Stitcher(images_manager.FileNames.ToArray(), images_manager.Images.ToArray());
        resetCurrentMatch();        
        scrollLimit.Enabled = true;
        buttonGotoMatching.Enabled = true;
        buttonGotoMerge.Enabled = true;
      });
    }

    private void buttonGotoMatching_Click(object sender, EventArgs e) {
      tabControlMain.SelectedTab = tabPageMatching;
    }

    private void buttonClearSegment_Click(object sender, EventArgs e) {
      images_manager.ClearAll();
    }

    private void buttonClearFiles_Click(object sender, EventArgs e) {
      removeSelectedSegments();
    }

    private void imagesContainer_KeyDown(object sender, KeyEventArgs e) {
      if (e.KeyData == Keys.Delete) {
        removeSelectedSegments();
      }
    }

    void removeSelectedSegments() {
      var selection = segments_thumbnails.SelectedItems();
      images_manager.RemoveImages(selection);
    }

    //
    // MATCHING
    //

    private void scrollLimit_Scroll(object sender, ScrollEventArgs e) {
      if (current_match == null)
        return;
      current_match.SetLimit(scrollLimit.Value);
      drawCurrentMatch();
    }

    private void buttonUseMatches_Click(object sender, EventArgs e) {
      generatePanoram();
    }

    private void buttonGotoFiles_Click(object sender, EventArgs e) {
      tabControlMain.SelectedTab = tabPageSegments;
    }

    private void buttonResetMathPicture_Click(object sender, EventArgs e) {
      picturebox_matching.ResetState();
    }

    private void checkBoxActiveMatch_CheckedChanged(object sender, EventArgs e) {
      current_match.IsActive = checkBoxActiveMatch.Checked;
      drawCurrentMatch();
    }

    void currentMatch_Change(object sender, EventArgs e) {
      resetCurrentMatch();
    }

    void resetCurrentMatch() {
      if (stitcher == null)
        return;
      var selection = segments_pair_list.SelectedItems();
      current_match = stitcher.MatchBetween(selection[0], selection[1]);
      drawCurrentMatch();
    }

    void drawCurrentMatch() {
      picturebox_matching.Image = current_match.ToImage();
      textMatchDistance.Text = current_match.Distance().ToString("F2");
      scrollLimit.Value = current_match.CurrentLimit();
      checkBoxActiveMatch.Checked = current_match.IsActive;
    }

    //
    // MERGING
    //

    private void buttonSavePan_Click(object sender, EventArgs e) {
      savePanorama();
    }

    private void buttonBackToMatching_Click(object sender, EventArgs e) {
      tabControlMain.SelectedTab = tabPageMatching;
    }

    private void buttonResetPanoramaPicture_Click(object sender, EventArgs e) {
      picturebox_merging.ResetState();
    }

    private void buttonGeneratePanoram_Click(object sender, EventArgs e) {
      generatePanoram();
    }

    void savePanorama() {
      images_manager.SaveImage((Bitmap)pictureMerged.Image);
    }

    void generatePanoram() {
      picturebox_merging.Image = stitcher.StitchAll();
      tabControlMain.SelectedTab = tabPageMerging;
      buttonSavePan.Enabled = true;
    }

    //
    // SHORTCUTS
    //

    Keys openFileShortCut {
      get { return Keys.Control | Keys.O; }
    }

    Keys saveFileShortCut {
      get { return Keys.Control | Keys.S; }
    }
    
  }
}
