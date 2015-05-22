namespace TransformatorExample {
  partial class MainForm {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.scrollLimit = new System.Windows.Forms.HScrollBar();
      this.label3 = new System.Windows.Forms.Label();
      this.pictureMerged = new System.Windows.Forms.PictureBox();
      this.tabControlMain = new System.Windows.Forms.TabControl();
      this.tabPageSegments = new System.Windows.Forms.TabPage();
      this.buttonRemoveSelectedFiles = new System.Windows.Forms.Button();
      this.buttonClearSegment = new System.Windows.Forms.Button();
      this.imagesContainer = new System.Windows.Forms.ListView();
      this.buttonGotoMatching = new System.Windows.Forms.Button();
      this.buttonAddSegments = new System.Windows.Forms.Button();
      this.tabPageMatching = new System.Windows.Forms.TabPage();
      this.label4 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.checkBoxActiveMatch = new System.Windows.Forms.CheckBox();
      this.buttonBackToFiles = new System.Windows.Forms.Button();
      this.pictureMatches = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.textMatchDistance = new System.Windows.Forms.TextBox();
      this.listSegmentsMatchRight = new System.Windows.Forms.ListBox();
      this.listSegmentsMatchLeft = new System.Windows.Forms.ListBox();
      this.buttonGotoMerge = new System.Windows.Forms.Button();
      this.tabPageMerging = new System.Windows.Forms.TabPage();
      this.buttonBackToMatching = new System.Windows.Forms.Button();
      this.buttonSavePan = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.pictureMerged)).BeginInit();
      this.tabControlMain.SuspendLayout();
      this.tabPageSegments.SuspendLayout();
      this.tabPageMatching.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureMatches)).BeginInit();
      this.tabPageMerging.SuspendLayout();
      this.SuspendLayout();
      // 
      // scrollLimit
      // 
      this.scrollLimit.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
      this.scrollLimit.Enabled = false;
      this.scrollLimit.Location = new System.Drawing.Point(170, 507);
      this.scrollLimit.Name = "scrollLimit";
      this.scrollLimit.Size = new System.Drawing.Size(611, 27);
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
      // pictureMerged
      // 
      this.pictureMerged.BackColor = System.Drawing.Color.Black;
      this.pictureMerged.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.pictureMerged.Location = new System.Drawing.Point(169, 6);
      this.pictureMerged.Name = "pictureMerged";
      this.pictureMerged.Size = new System.Drawing.Size(611, 528);
      this.pictureMerged.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureMerged.TabIndex = 10;
      this.pictureMerged.TabStop = false;
      // 
      // tabControlMain
      // 
      this.tabControlMain.Controls.Add(this.tabPageSegments);
      this.tabControlMain.Controls.Add(this.tabPageMatching);
      this.tabControlMain.Controls.Add(this.tabPageMerging);
      this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControlMain.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tabControlMain.HotTrack = true;
      this.tabControlMain.ItemSize = new System.Drawing.Size(60, 30);
      this.tabControlMain.Location = new System.Drawing.Point(0, 0);
      this.tabControlMain.Name = "tabControlMain";
      this.tabControlMain.Padding = new System.Drawing.Point(108, 3);
      this.tabControlMain.SelectedIndex = 0;
      this.tabControlMain.Size = new System.Drawing.Size(794, 575);
      this.tabControlMain.TabIndex = 1;
      // 
      // tabPageSegments
      // 
      this.tabPageSegments.BackColor = System.Drawing.Color.Silver;
      this.tabPageSegments.Controls.Add(this.buttonRemoveSelectedFiles);
      this.tabPageSegments.Controls.Add(this.buttonClearSegment);
      this.tabPageSegments.Controls.Add(this.imagesContainer);
      this.tabPageSegments.Controls.Add(this.buttonGotoMatching);
      this.tabPageSegments.Controls.Add(this.buttonAddSegments);
      this.tabPageSegments.Location = new System.Drawing.Point(4, 34);
      this.tabPageSegments.Name = "tabPageSegments";
      this.tabPageSegments.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageSegments.Size = new System.Drawing.Size(786, 537);
      this.tabPageSegments.TabIndex = 2;
      this.tabPageSegments.Text = "Segments";
      // 
      // buttonRemoveSelectedFiles
      // 
      this.buttonRemoveSelectedFiles.BackColor = System.Drawing.Color.Transparent;
      this.buttonRemoveSelectedFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonRemoveSelectedFiles.Enabled = false;
      this.buttonRemoveSelectedFiles.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonRemoveSelectedFiles.ForeColor = System.Drawing.Color.Black;
      this.buttonRemoveSelectedFiles.ImageAlign = System.Drawing.ContentAlignment.TopRight;
      this.buttonRemoveSelectedFiles.Location = new System.Drawing.Point(8, 198);
      this.buttonRemoveSelectedFiles.Name = "buttonRemoveSelectedFiles";
      this.buttonRemoveSelectedFiles.Size = new System.Drawing.Size(157, 140);
      this.buttonRemoveSelectedFiles.TabIndex = 6;
      this.buttonRemoveSelectedFiles.Text = "Remove selected";
      this.buttonRemoveSelectedFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.buttonRemoveSelectedFiles.UseVisualStyleBackColor = false;
      this.buttonRemoveSelectedFiles.Click += new System.EventHandler(this.buttonClearFiles_Click);
      // 
      // buttonClearSegment
      // 
      this.buttonClearSegment.BackColor = System.Drawing.Color.Transparent;
      this.buttonClearSegment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonClearSegment.Enabled = false;
      this.buttonClearSegment.Font = new System.Drawing.Font("Segoe UI", 14.25F);
      this.buttonClearSegment.ForeColor = System.Drawing.Color.Black;
      this.buttonClearSegment.ImageAlign = System.Drawing.ContentAlignment.TopRight;
      this.buttonClearSegment.Location = new System.Drawing.Point(8, 344);
      this.buttonClearSegment.Name = "buttonClearSegment";
      this.buttonClearSegment.Size = new System.Drawing.Size(157, 140);
      this.buttonClearSegment.TabIndex = 5;
      this.buttonClearSegment.Text = "Remove all";
      this.buttonClearSegment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.buttonClearSegment.UseVisualStyleBackColor = false;
      this.buttonClearSegment.Click += new System.EventHandler(this.buttonClearSegment_Click);
      // 
      // imagesContainer
      // 
      this.imagesContainer.Location = new System.Drawing.Point(171, 6);
      this.imagesContainer.Name = "imagesContainer";
      this.imagesContainer.ShowGroups = false;
      this.imagesContainer.ShowItemToolTips = true;
      this.imagesContainer.Size = new System.Drawing.Size(607, 525);
      this.imagesContainer.TabIndex = 4;
      this.imagesContainer.UseCompatibleStateImageBehavior = false;
      this.imagesContainer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.imagesContainer_KeyDown);
      // 
      // buttonGotoMatching
      // 
      this.buttonGotoMatching.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
      this.buttonGotoMatching.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonGotoMatching.Cursor = System.Windows.Forms.Cursors.Default;
      this.buttonGotoMatching.Enabled = false;
      this.buttonGotoMatching.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
      this.buttonGotoMatching.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonGotoMatching.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonGotoMatching.ForeColor = System.Drawing.Color.Black;
      this.buttonGotoMatching.ImageAlign = System.Drawing.ContentAlignment.TopRight;
      this.buttonGotoMatching.Location = new System.Drawing.Point(8, 6);
      this.buttonGotoMatching.Name = "buttonGotoMatching";
      this.buttonGotoMatching.Size = new System.Drawing.Size(157, 41);
      this.buttonGotoMatching.TabIndex = 2;
      this.buttonGotoMatching.Text = "Next";
      this.buttonGotoMatching.UseVisualStyleBackColor = false;
      this.buttonGotoMatching.Click += new System.EventHandler(this.buttonGotoMatching_Click);
      // 
      // buttonAddSegments
      // 
      this.buttonAddSegments.BackColor = System.Drawing.Color.Transparent;
      this.buttonAddSegments.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.buttonAddSegments.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonAddSegments.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.buttonAddSegments.ImageAlign = System.Drawing.ContentAlignment.TopRight;
      this.buttonAddSegments.Location = new System.Drawing.Point(8, 53);
      this.buttonAddSegments.Name = "buttonAddSegments";
      this.buttonAddSegments.Size = new System.Drawing.Size(157, 140);
      this.buttonAddSegments.TabIndex = 0;
      this.buttonAddSegments.Text = "Add images..";
      this.buttonAddSegments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.buttonAddSegments.UseVisualStyleBackColor = false;
      this.buttonAddSegments.Click += new System.EventHandler(this.buttonAddSegments_Click);
      // 
      // tabPageMatching
      // 
      this.tabPageMatching.BackColor = System.Drawing.Color.Silver;
      this.tabPageMatching.Controls.Add(this.label4);
      this.tabPageMatching.Controls.Add(this.label2);
      this.tabPageMatching.Controls.Add(this.checkBoxActiveMatch);
      this.tabPageMatching.Controls.Add(this.buttonBackToFiles);
      this.tabPageMatching.Controls.Add(this.pictureMatches);
      this.tabPageMatching.Controls.Add(this.scrollLimit);
      this.tabPageMatching.Controls.Add(this.label1);
      this.tabPageMatching.Controls.Add(this.textMatchDistance);
      this.tabPageMatching.Controls.Add(this.listSegmentsMatchRight);
      this.tabPageMatching.Controls.Add(this.listSegmentsMatchLeft);
      this.tabPageMatching.Controls.Add(this.buttonGotoMerge);
      this.tabPageMatching.Location = new System.Drawing.Point(4, 34);
      this.tabPageMatching.Name = "tabPageMatching";
      this.tabPageMatching.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageMatching.Size = new System.Drawing.Size(786, 537);
      this.tabPageMatching.TabIndex = 0;
      this.tabPageMatching.Text = "Matching";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(5, 249);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(69, 13);
      this.label4.TabIndex = 20;
      this.label4.Text = "Right image";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(5, 65);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(61, 13);
      this.label2.TabIndex = 19;
      this.label2.Text = "Left image";
      // 
      // checkBoxActiveMatch
      // 
      this.checkBoxActiveMatch.AutoSize = true;
      this.checkBoxActiveMatch.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.checkBoxActiveMatch.Location = new System.Drawing.Point(3, 481);
      this.checkBoxActiveMatch.Name = "checkBoxActiveMatch";
      this.checkBoxActiveMatch.Size = new System.Drawing.Size(106, 17);
      this.checkBoxActiveMatch.TabIndex = 18;
      this.checkBoxActiveMatch.Text = "Similar images?";
      this.checkBoxActiveMatch.UseVisualStyleBackColor = true;
      this.checkBoxActiveMatch.CheckedChanged += new System.EventHandler(this.checkBoxActiveMatch_CheckedChanged);
      // 
      // buttonBackToFiles
      // 
      this.buttonBackToFiles.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
      this.buttonBackToFiles.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
      this.buttonBackToFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonBackToFiles.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonBackToFiles.Location = new System.Drawing.Point(8, 6);
      this.buttonBackToFiles.Name = "buttonBackToFiles";
      this.buttonBackToFiles.Size = new System.Drawing.Size(76, 41);
      this.buttonBackToFiles.TabIndex = 16;
      this.buttonBackToFiles.Text = "Back";
      this.buttonBackToFiles.UseVisualStyleBackColor = false;
      this.buttonBackToFiles.Click += new System.EventHandler(this.buttonBackToFiles_Click);
      // 
      // pictureMatches
      // 
      this.pictureMatches.BackColor = System.Drawing.Color.White;
      this.pictureMatches.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.pictureMatches.Location = new System.Drawing.Point(170, 6);
      this.pictureMatches.Name = "pictureMatches";
      this.pictureMatches.Size = new System.Drawing.Size(610, 492);
      this.pictureMatches.TabIndex = 4;
      this.pictureMatches.TabStop = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(5, 510);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(58, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "Similarity:";
      // 
      // textMatchDistance
      // 
      this.textMatchDistance.Location = new System.Drawing.Point(90, 507);
      this.textMatchDistance.Name = "textMatchDistance";
      this.textMatchDistance.ReadOnly = true;
      this.textMatchDistance.Size = new System.Drawing.Size(74, 22);
      this.textMatchDistance.TabIndex = 5;
      // 
      // listSegmentsMatchRight
      // 
      this.listSegmentsMatchRight.FormattingEnabled = true;
      this.listSegmentsMatchRight.Location = new System.Drawing.Point(8, 265);
      this.listSegmentsMatchRight.Name = "listSegmentsMatchRight";
      this.listSegmentsMatchRight.Size = new System.Drawing.Size(156, 108);
      this.listSegmentsMatchRight.TabIndex = 14;
      // 
      // listSegmentsMatchLeft
      // 
      this.listSegmentsMatchLeft.FormattingEnabled = true;
      this.listSegmentsMatchLeft.Location = new System.Drawing.Point(8, 81);
      this.listSegmentsMatchLeft.Name = "listSegmentsMatchLeft";
      this.listSegmentsMatchLeft.Size = new System.Drawing.Size(156, 147);
      this.listSegmentsMatchLeft.TabIndex = 13;
      // 
      // buttonGotoMerge
      // 
      this.buttonGotoMerge.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
      this.buttonGotoMerge.Enabled = false;
      this.buttonGotoMerge.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
      this.buttonGotoMerge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonGotoMerge.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonGotoMerge.Location = new System.Drawing.Point(88, 6);
      this.buttonGotoMerge.Name = "buttonGotoMerge";
      this.buttonGotoMerge.Size = new System.Drawing.Size(76, 41);
      this.buttonGotoMerge.TabIndex = 4;
      this.buttonGotoMerge.Text = "Next";
      this.buttonGotoMerge.UseVisualStyleBackColor = false;
      this.buttonGotoMerge.Click += new System.EventHandler(this.buttonGotoMerge_Click);
      // 
      // tabPageMerging
      // 
      this.tabPageMerging.BackColor = System.Drawing.Color.Silver;
      this.tabPageMerging.Controls.Add(this.buttonBackToMatching);
      this.tabPageMerging.Controls.Add(this.buttonSavePan);
      this.tabPageMerging.Controls.Add(this.pictureMerged);
      this.tabPageMerging.Location = new System.Drawing.Point(4, 34);
      this.tabPageMerging.Name = "tabPageMerging";
      this.tabPageMerging.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageMerging.Size = new System.Drawing.Size(786, 537);
      this.tabPageMerging.TabIndex = 1;
      this.tabPageMerging.Text = "Stitching";
      // 
      // buttonBackToMatching
      // 
      this.buttonBackToMatching.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
      this.buttonBackToMatching.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonBackToMatching.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
      this.buttonBackToMatching.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonBackToMatching.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonBackToMatching.Location = new System.Drawing.Point(6, 6);
      this.buttonBackToMatching.Name = "buttonBackToMatching";
      this.buttonBackToMatching.Size = new System.Drawing.Size(157, 41);
      this.buttonBackToMatching.TabIndex = 13;
      this.buttonBackToMatching.Text = "Back";
      this.buttonBackToMatching.UseVisualStyleBackColor = false;
      this.buttonBackToMatching.Click += new System.EventHandler(this.buttonBackToMatching_Click);
      // 
      // buttonSavePan
      // 
      this.buttonSavePan.BackColor = System.Drawing.Color.Transparent;
      this.buttonSavePan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonSavePan.Enabled = false;
      this.buttonSavePan.Font = new System.Drawing.Font("Segoe UI", 14.25F);
      this.buttonSavePan.Location = new System.Drawing.Point(6, 53);
      this.buttonSavePan.Name = "buttonSavePan";
      this.buttonSavePan.Size = new System.Drawing.Size(157, 140);
      this.buttonSavePan.TabIndex = 12;
      this.buttonSavePan.Text = "Save as..";
      this.buttonSavePan.UseVisualStyleBackColor = false;
      this.buttonSavePan.Click += new System.EventHandler(this.buttonSavePan_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(794, 575);
      this.Controls.Add(this.tabControlMain);
      this.Controls.Add(this.label3);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.Text = "Image Stitcher";
      ((System.ComponentModel.ISupportInitialize)(this.pictureMerged)).EndInit();
      this.tabControlMain.ResumeLayout(false);
      this.tabPageSegments.ResumeLayout(false);
      this.tabPageMatching.ResumeLayout(false);
      this.tabPageMatching.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureMatches)).EndInit();
      this.tabPageMerging.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.HScrollBar scrollLimit;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.PictureBox pictureMerged;
    private System.Windows.Forms.TabControl tabControlMain;
    private System.Windows.Forms.TabPage tabPageMatching;
    private System.Windows.Forms.TabPage tabPageMerging;
    private System.Windows.Forms.TabPage tabPageSegments;
    private System.Windows.Forms.Button buttonAddSegments;
    private System.Windows.Forms.Button buttonSavePan;
    private System.Windows.Forms.Button buttonGotoMerge;
    private System.Windows.Forms.ListBox listSegmentsMatchLeft;
    private System.Windows.Forms.ListBox listSegmentsMatchRight;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textMatchDistance;
    private System.Windows.Forms.Button buttonGotoMatching;
    private System.Windows.Forms.PictureBox pictureMatches;
    private System.Windows.Forms.Button buttonBackToFiles;
    private System.Windows.Forms.Button buttonBackToMatching;
    private System.Windows.Forms.ListView imagesContainer;
    private System.Windows.Forms.Button buttonClearSegment;
    private System.Windows.Forms.Button buttonRemoveSelectedFiles;
    private System.Windows.Forms.CheckBox checkBoxActiveMatch;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label2;
  }
}

