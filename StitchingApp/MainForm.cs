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
  public partial class MainForm : BaseForm {
    Panoramas.IPublicFactory panoramas_factory;
    Panoramas.IStitcher stitcher;
    Panoramas.IRelationControl current_match;
    ImageEditor.Editor picturebox_matching, picturebox_merging;
    ImageFilesManager.CollectionManager images_manager;
    ImageFilesManager.ISelectableControl segments_thumbnails;
    ImageFilesManager.ISelectableControl segments_pair_list;
    ImageFilesManager.Dialog save_dialog;
    bool stitched = false;

    public MainForm(Panoramas.IPublicFactory factory) {
      InitializeComponent();
      this.panoramas_factory = factory;
      initFilesControls();
      initToolTips();
      tabControlMain.TabPages.Remove(tabPageMatching);
      tabControlMain.TabPages.Remove(tabPageMerging);
      updateLoadingPageStatus();
    }

    void initFilesControls() {
      picturebox_matching = new ImageEditor.Editor(this, this.pictureMatches);
      picturebox_merging = new ImageEditor.Editor(this, this.pictureMerged, true);
      images_manager = new ImageFilesManager.CollectionManager();
      this.segments_thumbnails = images_manager.PresentAsListView(imagesContainer);
      this.segments_thumbnails.AddSelectionChangeHandler(new EventHandler(this.currentFilesSelection_Change));
      this.segments_pair_list = images_manager.PresentAsPairsList(listSegmentsMatchLeft, listSegmentsMatchRight);
      this.segments_pair_list.AddSelectionChangeHandler(new EventHandler(this.currentMatch_Change));
      this.save_dialog = new ImageFilesManager.Dialog();
      save_dialog.SaveDialog.Filter = "JPEG Files|*.jpeg;*.jpg";
    }

    void initToolTips() {
      setToolTip(this.buttonAddSegments, "Open (Ctrl+O)", "Add more images to stitch them into a panoram");
      setToolTip(this.buttonRemoveSelectedFiles, "Remove (Del)", "Remove selected images");
      setToolTip(this.buttonClearSegment, "Remove images", "Clear images list");
      setToolTip(this.buttonSavePan, "Save (Ctrl+S)", "Save current panorama image");
    }

    const int TOOLTIP_DELAY = 1500;
    void setToolTip(Control control, String title, String text = null) {
      ToolTip tooltip = new ToolTip();
      tooltip.InitialDelay = TOOLTIP_DELAY;
      tooltip.IsBalloon = true;
      tooltip.ToolTipTitle = title;
      tooltip.SetToolTip(control, text);
    }

    delegate void a_process();
    void waitForProcessComplete(a_process process) {
      this.Cursor = Cursors.WaitCursor;
      process.Invoke();
      this.Cursor = Cursors.Default;
    }

    //
    // LOADING IMAGES
    //

    private void buttonAddSegments_Click(object sender, EventArgs e) {
      addSegments();
    }

    private void buttonClearSegment_Click(object sender, EventArgs e) {
      this.stitcher = null;
      images_manager.ClearAll();
      updateLoadingPageStatus();
    }

    private void buttonClearFiles_Click(object sender, EventArgs e) {
      removeSelectedSegments();
    }

    private void imagesContainer_KeyDown(object sender, KeyEventArgs e) {
      if (e.KeyData == Keys.Delete) {
        removeSelectedSegments();
      }
    }

    private void buttonGotoMatching_Click(object sender, EventArgs e) {
      updateStitcher();
      resetCurrentMatch();
      if (stitched) {
        tabControlMain.SelectedTab = tabPageMatching;
      } else {
        generatePanoram();
        tabControlMain.TabPages.Add(tabPageMatching);
        tabControlMain.TabPages.Add(tabPageMerging);
        tabControlMain.SelectedTab = tabPageMerging;
        stitched = true;
      }
    }

    void addSegments() {
      try {
        images_manager.LoadMore();
      } catch (Exception ex) {
        Logger.Logger.Info(ex.ToString());
        MessageBox.Show("Cannot load files!");
      }
      updateLoadingPageStatus();
    }

    void removeSelectedSegments() {
      this.stitcher = null;
      var selection = segments_thumbnails.SelectedItems();
      images_manager.Remove(selection);
      updateLoadingPageStatus();
    }

    void updateLoadingPageStatus() {
      bool images_present = images_manager.Images.Count > 0;
      buttonClearSegment.Enabled = images_present;
      bool can_stitch = images_manager.Images.Count >= 2;
      scrollLimit.Enabled = can_stitch;
      buttonGotoMatching.Enabled = can_stitch;
      if (!can_stitch) {
        unmarkButton(buttonGotoMatching);
        markButton(buttonAddSegments);
      } else {
        markButton(buttonGotoMatching);
        unmarkButton(buttonAddSegments);
      }
      updateFileSelectionStatus();
    }

    void updateStitcher() {
      waitForProcessComplete(() => {
        try {
          this.stitcher = panoramas_factory.Stitcher(
            images_manager.Images.Select((i) => i.FileName).ToArray(),
            images_manager.Images.Select((i) => i.Bitmap).ToArray());
          buttonGotoMerge.Enabled = true;
        } catch (Exception ex) {
          Logger.Logger.Info(ex.ToString());
          MessageBox.Show("Cannot use that files!");
        }
      });
    }

    void currentFilesSelection_Change(object sender, EventArgs e) {
      updateFileSelectionStatus();
    }

    void updateFileSelectionStatus() {
      bool selection_present = segments_thumbnails.SelectedItems().Length > 0;
      buttonRemoveSelectedFiles.Enabled = selection_present;
    }

    //
    // MATCHING
    //

    private void scrollLimit_Scroll(object sender, ScrollEventArgs e) {
      current_match.LimitPercent = scrollLimit.Value;
      drawCurrentMatch();
    }

    private void buttonResetMathPicture_Click(object sender, EventArgs e) {
      picturebox_matching.ResetState();
    }

    private void checkBoxActiveMatch_CheckedChanged(object sender, EventArgs e) {
      current_match.Active = checkBoxActiveMatch.Checked;
      drawCurrentMatch();
    }

    void currentMatch_Change(object sender, EventArgs e) {
      resetCurrentMatch();
    }

    private void buttonBackToFiles_Click(object sender, EventArgs e) {
      tabControlMain.SelectedTab = tabPageSegments;
    }

    private void buttonGotoMerge_Click(object sender, EventArgs e) {
      generatePanoram();
    }

    void resetCurrentMatch() {
      var selection = segments_pair_list.SelectedItems();
      if (stitcher == null || selection.Any((i) => i == null))
        return;
      try {
        current_match = stitcher.MatchBetween(selection[0], selection[1]);
        drawCurrentMatch();
      } catch (Exception ex) {
        Logger.Logger.Info(ex.ToString());
        MessageBox.Show("Cannot analyze images!");
      }
    }

    void drawCurrentMatch() {
      picturebox_matching.Image = current_match.ToImage();
      textMatchDistance.Text = current_match.Similarity().ToString("F2");
      scrollLimit.Value = current_match.LimitPercent;
      checkBoxActiveMatch.Checked = current_match.Active;
    }

    void generatePanoram() {
      waitForProcessComplete(() => {
        try {
          picturebox_merging.Image = stitcher.StitchAll();
          tabControlMain.SelectedTab = tabPageMerging;
          buttonSavePan.Enabled = true;
          markButton(buttonSavePan);
        } catch (Exception ex) {
          Logger.Logger.Info(ex.ToString());
          MessageBox.Show("Cannot generate!");
        }
      });
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

    void savePanorama() {
      save_dialog.SaveToFile((filename) => {
        picturebox_merging.Image.Save(filename);
      });
    }

    //
    // HOTKEYS
    //
    
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
      if (tabControlMain.SelectedTab == tabPageSegments && keyData == openFileShortCut)
        addSegments();
      else if (tabControlMain.SelectedTab == tabPageMerging && keyData == saveFileShortCut)
        savePanorama();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    Keys openFileShortCut {
      get { return Keys.Control | Keys.O; }
    }

    Keys saveFileShortCut {
      get { return Keys.Control | Keys.S; }
    }

    //
    // BUTTONS
    //

    void markButton(Button button) {
      button.Font = new Font(button.Font, FontStyle.Bold);
      button.Focus();
    }

    void unmarkButton(Button button) {
      button.Font = new Font(button.Font, FontStyle.Regular);
    }
  }
}
