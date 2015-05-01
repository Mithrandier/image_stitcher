namespace TransformatorExample {
  partial class TransformatorForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.textFeaturesNum1 = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.loadImagesDialog = new System.Windows.Forms.OpenFileDialog();
      this.scrollLimit = new System.Windows.Forms.HScrollBar();
      this.label3 = new System.Windows.Forms.Label();
      this.textTimer = new System.Windows.Forms.TextBox();
      this.panelHomoMatrix = new System.Windows.Forms.Panel();
      this.buttonRestore = new System.Windows.Forms.Button();
      this.buttonMerge = new System.Windows.Forms.Button();
      this.savePanDialog = new System.Windows.Forms.SaveFileDialog();
      this.pictureMerged = new System.Windows.Forms.PictureBox();
      this.pictureMatches = new System.Windows.Forms.PictureBox();
      this.tabControlMain = new System.Windows.Forms.TabControl();
      this.tabPageSegments = new System.Windows.Forms.TabPage();
      this.buttonAddSeg = new System.Windows.Forms.Button();
      this.buttonAddSegments = new System.Windows.Forms.Button();
      this.tabPageMatching = new System.Windows.Forms.TabPage();
      this.splitContainerMatching = new System.Windows.Forms.SplitContainer();
      this.textDistanceX = new System.Windows.Forms.Label();
      this.buttonUseMatches = new System.Windows.Forms.Button();
      this.textFeaturesNum2 = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.splitContainerDisplay = new System.Windows.Forms.SplitContainer();
      this.tabPageMerging = new System.Windows.Forms.TabPage();
      this.scrollFeaturesLimitForMerging = new System.Windows.Forms.HScrollBar();
      this.buttonSavePan = new System.Windows.Forms.Button();
      this.addSegmentsDialog = new System.Windows.Forms.OpenFileDialog();
      this.panelHomoMatrix.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureMerged)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureMatches)).BeginInit();
      this.tabControlMain.SuspendLayout();
      this.tabPageSegments.SuspendLayout();
      this.tabPageMatching.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerMatching)).BeginInit();
      this.splitContainerMatching.Panel1.SuspendLayout();
      this.splitContainerMatching.Panel2.SuspendLayout();
      this.splitContainerMatching.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerDisplay)).BeginInit();
      this.splitContainerDisplay.Panel1.SuspendLayout();
      this.splitContainerDisplay.Panel2.SuspendLayout();
      this.splitContainerDisplay.SuspendLayout();
      this.tabPageMerging.SuspendLayout();
      this.SuspendLayout();
      // 
      // textFeaturesNum1
      // 
      this.textFeaturesNum1.Location = new System.Drawing.Point(18, 26);
      this.textFeaturesNum1.Name = "textFeaturesNum1";
      this.textFeaturesNum1.Size = new System.Drawing.Size(100, 20);
      this.textFeaturesNum1.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(15, 12);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(61, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "features #1";
      // 
      // loadImagesDialog
      // 
      this.loadImagesDialog.FileName = "openFileDialog1";
      this.loadImagesDialog.Filter = "Images |*.jpeg;*.png;*.jpg;*.gif";
      // 
      // scrollLimit
      // 
      this.scrollLimit.Dock = System.Windows.Forms.DockStyle.Fill;
      this.scrollLimit.Enabled = false;
      this.scrollLimit.Location = new System.Drawing.Point(0, 0);
      this.scrollLimit.Name = "scrollLimit";
      this.scrollLimit.Size = new System.Drawing.Size(658, 27);
      this.scrollLimit.TabIndex = 9;
      this.scrollLimit.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollLimit_Scroll);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(396, 18);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(20, 13);
      this.label3.TabIndex = 8;
      this.label3.Text = "ms";
      // 
      // textTimer
      // 
      this.textTimer.Location = new System.Drawing.Point(323, 15);
      this.textTimer.Name = "textTimer";
      this.textTimer.Size = new System.Drawing.Size(67, 20);
      this.textTimer.TabIndex = 4;
      // 
      // panelHomoMatrix
      // 
      this.panelHomoMatrix.BackColor = System.Drawing.Color.CadetBlue;
      this.panelHomoMatrix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panelHomoMatrix.Controls.Add(this.buttonRestore);
      this.panelHomoMatrix.Controls.Add(this.buttonMerge);
      this.panelHomoMatrix.Location = new System.Drawing.Point(219, 6);
      this.panelHomoMatrix.Name = "panelHomoMatrix";
      this.panelHomoMatrix.Size = new System.Drawing.Size(167, 113);
      this.panelHomoMatrix.TabIndex = 11;
      // 
      // buttonRestore
      // 
      this.buttonRestore.Location = new System.Drawing.Point(89, 81);
      this.buttonRestore.Name = "buttonRestore";
      this.buttonRestore.Size = new System.Drawing.Size(60, 23);
      this.buttonRestore.TabIndex = 23;
      this.buttonRestore.Text = "Restore";
      this.buttonRestore.UseVisualStyleBackColor = true;
      this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
      // 
      // buttonMerge
      // 
      this.buttonMerge.Location = new System.Drawing.Point(23, 81);
      this.buttonMerge.Name = "buttonMerge";
      this.buttonMerge.Size = new System.Drawing.Size(60, 23);
      this.buttonMerge.TabIndex = 11;
      this.buttonMerge.Text = "Merge";
      this.buttonMerge.UseVisualStyleBackColor = true;
      this.buttonMerge.Click += new System.EventHandler(this.buttonMerge_Click);
      // 
      // pictureMerged
      // 
      this.pictureMerged.BackColor = System.Drawing.SystemColors.Control;
      this.pictureMerged.Location = new System.Drawing.Point(8, 125);
      this.pictureMerged.Name = "pictureMerged";
      this.pictureMerged.Size = new System.Drawing.Size(650, 361);
      this.pictureMerged.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureMerged.TabIndex = 10;
      this.pictureMerged.TabStop = false;
      // 
      // pictureMatches
      // 
      this.pictureMatches.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureMatches.Location = new System.Drawing.Point(0, 0);
      this.pictureMatches.Name = "pictureMatches";
      this.pictureMatches.Size = new System.Drawing.Size(658, 413);
      this.pictureMatches.TabIndex = 4;
      this.pictureMatches.TabStop = false;
      // 
      // tabControlMain
      // 
      this.tabControlMain.Controls.Add(this.tabPageSegments);
      this.tabControlMain.Controls.Add(this.tabPageMatching);
      this.tabControlMain.Controls.Add(this.tabPageMerging);
      this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControlMain.Location = new System.Drawing.Point(0, 0);
      this.tabControlMain.Name = "tabControlMain";
      this.tabControlMain.SelectedIndex = 0;
      this.tabControlMain.Size = new System.Drawing.Size(672, 541);
      this.tabControlMain.TabIndex = 1;
      // 
      // tabPageSegments
      // 
      this.tabPageSegments.BackColor = System.Drawing.Color.Silver;
      this.tabPageSegments.Controls.Add(this.buttonAddSeg);
      this.tabPageSegments.Controls.Add(this.buttonAddSegments);
      this.tabPageSegments.Location = new System.Drawing.Point(4, 22);
      this.tabPageSegments.Name = "tabPageSegments";
      this.tabPageSegments.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageSegments.Size = new System.Drawing.Size(664, 515);
      this.tabPageSegments.TabIndex = 2;
      this.tabPageSegments.Text = "Segments";
      // 
      // buttonAddSeg
      // 
      this.buttonAddSeg.BackColor = System.Drawing.Color.DarkCyan;
      this.buttonAddSeg.BackgroundImage = global::TransformatorExample.Properties.Resources.folder_open_icon;
      this.buttonAddSeg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonAddSeg.ForeColor = System.Drawing.Color.Transparent;
      this.buttonAddSeg.ImageAlign = System.Drawing.ContentAlignment.TopRight;
      this.buttonAddSeg.Location = new System.Drawing.Point(379, 122);
      this.buttonAddSeg.Name = "buttonAddSeg";
      this.buttonAddSeg.Size = new System.Drawing.Size(265, 227);
      this.buttonAddSeg.TabIndex = 1;
      this.buttonAddSeg.UseVisualStyleBackColor = false;
      this.buttonAddSeg.Click += new System.EventHandler(this.buttonAddSeg_Click);
      // 
      // buttonAddSegments
      // 
      this.buttonAddSegments.BackColor = System.Drawing.Color.Transparent;
      this.buttonAddSegments.BackgroundImage = global::TransformatorExample.Properties.Resources.folder_open_icon;
      this.buttonAddSegments.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonAddSegments.ForeColor = System.Drawing.Color.Transparent;
      this.buttonAddSegments.ImageAlign = System.Drawing.ContentAlignment.TopRight;
      this.buttonAddSegments.Location = new System.Drawing.Point(20, 122);
      this.buttonAddSegments.Name = "buttonAddSegments";
      this.buttonAddSegments.Size = new System.Drawing.Size(265, 227);
      this.buttonAddSegments.TabIndex = 0;
      this.buttonAddSegments.UseVisualStyleBackColor = false;
      this.buttonAddSegments.Click += new System.EventHandler(this.buttonAddSegments_Click);
      // 
      // tabPageMatching
      // 
      this.tabPageMatching.Controls.Add(this.splitContainerMatching);
      this.tabPageMatching.Location = new System.Drawing.Point(4, 22);
      this.tabPageMatching.Name = "tabPageMatching";
      this.tabPageMatching.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageMatching.Size = new System.Drawing.Size(664, 515);
      this.tabPageMatching.TabIndex = 0;
      this.tabPageMatching.Text = "Matching";
      this.tabPageMatching.UseVisualStyleBackColor = true;
      // 
      // splitContainerMatching
      // 
      this.splitContainerMatching.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainerMatching.Location = new System.Drawing.Point(3, 3);
      this.splitContainerMatching.Name = "splitContainerMatching";
      this.splitContainerMatching.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainerMatching.Panel1
      // 
      this.splitContainerMatching.Panel1.Controls.Add(this.textDistanceX);
      this.splitContainerMatching.Panel1.Controls.Add(this.buttonUseMatches);
      this.splitContainerMatching.Panel1.Controls.Add(this.textFeaturesNum1);
      this.splitContainerMatching.Panel1.Controls.Add(this.label1);
      this.splitContainerMatching.Panel1.Controls.Add(this.textFeaturesNum2);
      this.splitContainerMatching.Panel1.Controls.Add(this.label4);
      // 
      // splitContainerMatching.Panel2
      // 
      this.splitContainerMatching.Panel2.Controls.Add(this.splitContainerDisplay);
      this.splitContainerMatching.Size = new System.Drawing.Size(658, 509);
      this.splitContainerMatching.SplitterDistance = 61;
      this.splitContainerMatching.TabIndex = 10;
      // 
      // textDistanceX
      // 
      this.textDistanceX.AutoSize = true;
      this.textDistanceX.Location = new System.Drawing.Point(299, 24);
      this.textDistanceX.Name = "textDistanceX";
      this.textDistanceX.Size = new System.Drawing.Size(13, 13);
      this.textDistanceX.TabIndex = 5;
      this.textDistanceX.Text = "0";
      // 
      // buttonUseMatches
      // 
      this.buttonUseMatches.Location = new System.Drawing.Point(565, 12);
      this.buttonUseMatches.Name = "buttonUseMatches";
      this.buttonUseMatches.Size = new System.Drawing.Size(75, 37);
      this.buttonUseMatches.TabIndex = 4;
      this.buttonUseMatches.Text = "User current matches";
      this.buttonUseMatches.UseVisualStyleBackColor = true;
      this.buttonUseMatches.Click += new System.EventHandler(this.buttonUseMatches_Click);
      // 
      // textFeaturesNum2
      // 
      this.textFeaturesNum2.Location = new System.Drawing.Point(141, 26);
      this.textFeaturesNum2.Name = "textFeaturesNum2";
      this.textFeaturesNum2.Size = new System.Drawing.Size(100, 20);
      this.textFeaturesNum2.TabIndex = 2;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(138, 10);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(61, 13);
      this.label4.TabIndex = 3;
      this.label4.Text = "features #2";
      // 
      // splitContainerDisplay
      // 
      this.splitContainerDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainerDisplay.Location = new System.Drawing.Point(0, 0);
      this.splitContainerDisplay.Name = "splitContainerDisplay";
      this.splitContainerDisplay.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainerDisplay.Panel1
      // 
      this.splitContainerDisplay.Panel1.Controls.Add(this.pictureMatches);
      // 
      // splitContainerDisplay.Panel2
      // 
      this.splitContainerDisplay.Panel2.Controls.Add(this.scrollLimit);
      this.splitContainerDisplay.Size = new System.Drawing.Size(658, 444);
      this.splitContainerDisplay.SplitterDistance = 413;
      this.splitContainerDisplay.TabIndex = 0;
      // 
      // tabPageMerging
      // 
      this.tabPageMerging.BackColor = System.Drawing.Color.CadetBlue;
      this.tabPageMerging.Controls.Add(this.scrollFeaturesLimitForMerging);
      this.tabPageMerging.Controls.Add(this.buttonSavePan);
      this.tabPageMerging.Controls.Add(this.pictureMerged);
      this.tabPageMerging.Controls.Add(this.panelHomoMatrix);
      this.tabPageMerging.Location = new System.Drawing.Point(4, 22);
      this.tabPageMerging.Name = "tabPageMerging";
      this.tabPageMerging.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageMerging.Size = new System.Drawing.Size(664, 515);
      this.tabPageMerging.TabIndex = 1;
      this.tabPageMerging.Text = "Merging";
      // 
      // scrollFeaturesLimitForMerging
      // 
      this.scrollFeaturesLimitForMerging.Location = new System.Drawing.Point(8, 489);
      this.scrollFeaturesLimitForMerging.Name = "scrollFeaturesLimitForMerging";
      this.scrollFeaturesLimitForMerging.Size = new System.Drawing.Size(650, 21);
      this.scrollFeaturesLimitForMerging.TabIndex = 13;
      this.scrollFeaturesLimitForMerging.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollFeaturesLimitForMerging_Scroll);
      // 
      // buttonSavePan
      // 
      this.buttonSavePan.BackgroundImage = global::TransformatorExample.Properties.Resources.Save_icon;
      this.buttonSavePan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonSavePan.Location = new System.Drawing.Point(490, 35);
      this.buttonSavePan.Name = "buttonSavePan";
      this.buttonSavePan.Size = new System.Drawing.Size(61, 59);
      this.buttonSavePan.TabIndex = 12;
      this.buttonSavePan.UseVisualStyleBackColor = true;
      this.buttonSavePan.Click += new System.EventHandler(this.buttonSavePan_Click);
      // 
      // addSegmentsDialog
      // 
      this.addSegmentsDialog.FileName = "openFileDialog1";
      this.addSegmentsDialog.Multiselect = true;
      // 
      // TransformatorForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(672, 541);
      this.Controls.Add(this.tabControlMain);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.textTimer);
      this.Name = "TransformatorForm";
      this.Text = "Image Transformator";
      this.panelHomoMatrix.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureMerged)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureMatches)).EndInit();
      this.tabControlMain.ResumeLayout(false);
      this.tabPageSegments.ResumeLayout(false);
      this.tabPageMatching.ResumeLayout(false);
      this.splitContainerMatching.Panel1.ResumeLayout(false);
      this.splitContainerMatching.Panel1.PerformLayout();
      this.splitContainerMatching.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerMatching)).EndInit();
      this.splitContainerMatching.ResumeLayout(false);
      this.splitContainerDisplay.Panel1.ResumeLayout(false);
      this.splitContainerDisplay.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerDisplay)).EndInit();
      this.splitContainerDisplay.ResumeLayout(false);
      this.tabPageMerging.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textFeaturesNum1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.OpenFileDialog loadImagesDialog;
    private System.Windows.Forms.PictureBox pictureMatches;
    private System.Windows.Forms.HScrollBar scrollLimit;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textTimer;
    private System.Windows.Forms.PictureBox pictureMerged;
    private System.Windows.Forms.Panel panelHomoMatrix;
    private System.Windows.Forms.Button buttonMerge;
    private System.Windows.Forms.Button buttonRestore;
    private System.Windows.Forms.SaveFileDialog savePanDialog;
    private System.Windows.Forms.TabControl tabControlMain;
    private System.Windows.Forms.TabPage tabPageMatching;
    private System.Windows.Forms.TextBox textFeaturesNum2;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TabPage tabPageMerging;
    private System.Windows.Forms.TabPage tabPageSegments;
    private System.Windows.Forms.SplitContainer splitContainerMatching;
    private System.Windows.Forms.SplitContainer splitContainerDisplay;
    private System.Windows.Forms.Button buttonAddSegments;
    private System.Windows.Forms.Button buttonSavePan;
    private System.Windows.Forms.Button buttonUseMatches;
    private System.Windows.Forms.HScrollBar scrollFeaturesLimitForMerging;
    private System.Windows.Forms.Button buttonAddSeg;
    private System.Windows.Forms.OpenFileDialog addSegmentsDialog;
    private System.Windows.Forms.Label textDistanceX;
  }
}

