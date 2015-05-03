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
      this.buttonAddSegments = new System.Windows.Forms.Button();
      this.tabPageMatching = new System.Windows.Forms.TabPage();
      this.listSegmentsMatchRight = new System.Windows.Forms.ListBox();
      this.listSegmentsMatchLeft = new System.Windows.Forms.ListBox();
      this.splitContainerMatching = new System.Windows.Forms.SplitContainer();
      this.buttonUseMatches = new System.Windows.Forms.Button();
      this.splitContainerDisplay = new System.Windows.Forms.SplitContainer();
      this.tabPageMerging = new System.Windows.Forms.TabPage();
      this.scrollFeaturesLimitForMerging = new System.Windows.Forms.HScrollBar();
      this.buttonSavePan = new System.Windows.Forms.Button();
      this.addSegmentsDialog = new System.Windows.Forms.OpenFileDialog();
      this.textMatchDistance = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.checkBoxOverlap = new System.Windows.Forms.CheckBox();
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
      // scrollLimit
      // 
      this.scrollLimit.Dock = System.Windows.Forms.DockStyle.Fill;
      this.scrollLimit.Enabled = false;
      this.scrollLimit.Location = new System.Drawing.Point(0, 0);
      this.scrollLimit.Name = "scrollLimit";
      this.scrollLimit.Size = new System.Drawing.Size(556, 27);
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
      this.pictureMerged.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.pictureMerged.Location = new System.Drawing.Point(8, 125);
      this.pictureMerged.Name = "pictureMerged";
      this.pictureMerged.Size = new System.Drawing.Size(650, 361);
      this.pictureMerged.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureMerged.TabIndex = 10;
      this.pictureMerged.TabStop = false;
      // 
      // pictureMatches
      // 
      this.pictureMatches.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.pictureMatches.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureMatches.Location = new System.Drawing.Point(0, 0);
      this.pictureMatches.Name = "pictureMatches";
      this.pictureMatches.Size = new System.Drawing.Size(556, 413);
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
      this.tabControlMain.Size = new System.Drawing.Size(865, 541);
      this.tabControlMain.TabIndex = 1;
      // 
      // tabPageSegments
      // 
      this.tabPageSegments.BackColor = System.Drawing.Color.Silver;
      this.tabPageSegments.Controls.Add(this.buttonAddSegments);
      this.tabPageSegments.Location = new System.Drawing.Point(4, 22);
      this.tabPageSegments.Name = "tabPageSegments";
      this.tabPageSegments.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageSegments.Size = new System.Drawing.Size(857, 515);
      this.tabPageSegments.TabIndex = 2;
      this.tabPageSegments.Text = "Segments";
      // 
      // buttonAddSegments
      // 
      this.buttonAddSegments.BackColor = System.Drawing.Color.Transparent;
      this.buttonAddSegments.BackgroundImage = global::TransformatorExample.Properties.Resources.folder_open_icon;
      this.buttonAddSegments.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonAddSegments.ForeColor = System.Drawing.Color.Transparent;
      this.buttonAddSegments.ImageAlign = System.Drawing.ContentAlignment.TopRight;
      this.buttonAddSegments.Location = new System.Drawing.Point(187, 65);
      this.buttonAddSegments.Name = "buttonAddSegments";
      this.buttonAddSegments.Size = new System.Drawing.Size(265, 227);
      this.buttonAddSegments.TabIndex = 0;
      this.buttonAddSegments.UseVisualStyleBackColor = false;
      this.buttonAddSegments.Click += new System.EventHandler(this.buttonAddSegments_Click);
      // 
      // tabPageMatching
      // 
      this.tabPageMatching.Controls.Add(this.listSegmentsMatchRight);
      this.tabPageMatching.Controls.Add(this.listSegmentsMatchLeft);
      this.tabPageMatching.Controls.Add(this.splitContainerMatching);
      this.tabPageMatching.Location = new System.Drawing.Point(4, 22);
      this.tabPageMatching.Name = "tabPageMatching";
      this.tabPageMatching.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageMatching.Size = new System.Drawing.Size(857, 515);
      this.tabPageMatching.TabIndex = 0;
      this.tabPageMatching.Text = "Matching";
      this.tabPageMatching.UseVisualStyleBackColor = true;
      // 
      // listSegmentsMatchRight
      // 
      this.listSegmentsMatchRight.FormattingEnabled = true;
      this.listSegmentsMatchRight.Location = new System.Drawing.Point(712, 5);
      this.listSegmentsMatchRight.Name = "listSegmentsMatchRight";
      this.listSegmentsMatchRight.Size = new System.Drawing.Size(138, 329);
      this.listSegmentsMatchRight.TabIndex = 14;
      this.listSegmentsMatchRight.SelectedIndexChanged += new System.EventHandler(this.listSegmentsMatchRight_SelectedIndexChanged);
      // 
      // listSegmentsMatchLeft
      // 
      this.listSegmentsMatchLeft.FormattingEnabled = true;
      this.listSegmentsMatchLeft.Location = new System.Drawing.Point(6, 5);
      this.listSegmentsMatchLeft.Name = "listSegmentsMatchLeft";
      this.listSegmentsMatchLeft.Size = new System.Drawing.Size(138, 329);
      this.listSegmentsMatchLeft.TabIndex = 13;
      this.listSegmentsMatchLeft.SelectedIndexChanged += new System.EventHandler(this.listSegmentsMatchLeft_SelectedIndexChanged);
      // 
      // splitContainerMatching
      // 
      this.splitContainerMatching.Location = new System.Drawing.Point(150, 0);
      this.splitContainerMatching.Name = "splitContainerMatching";
      this.splitContainerMatching.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainerMatching.Panel1
      // 
      this.splitContainerMatching.Panel1.Controls.Add(this.checkBoxOverlap);
      this.splitContainerMatching.Panel1.Controls.Add(this.label1);
      this.splitContainerMatching.Panel1.Controls.Add(this.textMatchDistance);
      this.splitContainerMatching.Panel1.Controls.Add(this.buttonUseMatches);
      // 
      // splitContainerMatching.Panel2
      // 
      this.splitContainerMatching.Panel2.Controls.Add(this.splitContainerDisplay);
      this.splitContainerMatching.Size = new System.Drawing.Size(556, 509);
      this.splitContainerMatching.SplitterDistance = 61;
      this.splitContainerMatching.TabIndex = 10;
      // 
      // buttonUseMatches
      // 
      this.buttonUseMatches.Location = new System.Drawing.Point(440, 9);
      this.buttonUseMatches.Name = "buttonUseMatches";
      this.buttonUseMatches.Size = new System.Drawing.Size(75, 37);
      this.buttonUseMatches.TabIndex = 4;
      this.buttonUseMatches.Text = "User current matches";
      this.buttonUseMatches.UseVisualStyleBackColor = true;
      this.buttonUseMatches.Click += new System.EventHandler(this.buttonUseMatches_Click);
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
      this.splitContainerDisplay.Size = new System.Drawing.Size(556, 444);
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
      this.tabPageMerging.Size = new System.Drawing.Size(857, 515);
      this.tabPageMerging.TabIndex = 1;
      this.tabPageMerging.Text = "Merging";
      // 
      // scrollFeaturesLimitForMerging
      // 
      this.scrollFeaturesLimitForMerging.Location = new System.Drawing.Point(8, 489);
      this.scrollFeaturesLimitForMerging.Name = "scrollFeaturesLimitForMerging";
      this.scrollFeaturesLimitForMerging.Size = new System.Drawing.Size(650, 21);
      this.scrollFeaturesLimitForMerging.TabIndex = 13;
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
      // textMatchDistance
      // 
      this.textMatchDistance.Location = new System.Drawing.Point(73, 15);
      this.textMatchDistance.Name = "textMatchDistance";
      this.textMatchDistance.Size = new System.Drawing.Size(100, 20);
      this.textMatchDistance.TabIndex = 5;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(15, 18);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(52, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "Distance:";
      // 
      // checkBoxOverlap
      // 
      this.checkBoxOverlap.AutoSize = true;
      this.checkBoxOverlap.Location = new System.Drawing.Point(73, 41);
      this.checkBoxOverlap.Name = "checkBoxOverlap";
      this.checkBoxOverlap.Size = new System.Drawing.Size(69, 17);
      this.checkBoxOverlap.TabIndex = 7;
      this.checkBoxOverlap.Text = "Overlap?";
      this.checkBoxOverlap.UseVisualStyleBackColor = true;
      // 
      // TransformatorForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(865, 541);
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
    private System.Windows.Forms.TabPage tabPageMerging;
    private System.Windows.Forms.TabPage tabPageSegments;
    private System.Windows.Forms.SplitContainer splitContainerMatching;
    private System.Windows.Forms.SplitContainer splitContainerDisplay;
    private System.Windows.Forms.Button buttonAddSegments;
    private System.Windows.Forms.Button buttonSavePan;
    private System.Windows.Forms.Button buttonUseMatches;
    private System.Windows.Forms.HScrollBar scrollFeaturesLimitForMerging;
    private System.Windows.Forms.OpenFileDialog addSegmentsDialog;
    private System.Windows.Forms.ListBox listSegmentsMatchLeft;
    private System.Windows.Forms.ListBox listSegmentsMatchRight;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textMatchDistance;
    private System.Windows.Forms.CheckBox checkBoxOverlap;
  }
}

