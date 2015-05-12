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
      this.savePanDialog = new System.Windows.Forms.SaveFileDialog();
      this.pictureMerged = new System.Windows.Forms.PictureBox();
      this.tabControlMain = new System.Windows.Forms.TabControl();
      this.tabPageSegments = new System.Windows.Forms.TabPage();
      this.buttonGotoMatching = new System.Windows.Forms.Button();
      this.listFiles = new System.Windows.Forms.ListView();
      this.buttonAddSegments = new System.Windows.Forms.Button();
      this.tabPageMatching = new System.Windows.Forms.TabPage();
      this.buttonGotoFiles = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.pictureMatches = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.textTimer = new System.Windows.Forms.TextBox();
      this.textMatchDistance = new System.Windows.Forms.TextBox();
      this.listSegmentsMatchRight = new System.Windows.Forms.ListBox();
      this.listSegmentsMatchLeft = new System.Windows.Forms.ListBox();
      this.buttonGotoMerge = new System.Windows.Forms.Button();
      this.tabPageMerging = new System.Windows.Forms.TabPage();
      this.button2 = new System.Windows.Forms.Button();
      this.buttonSavePan = new System.Windows.Forms.Button();
      this.addSegmentsDialog = new System.Windows.Forms.OpenFileDialog();
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
      this.scrollLimit.Enabled = false;
      this.scrollLimit.Location = new System.Drawing.Point(173, 483);
      this.scrollLimit.Name = "scrollLimit";
      this.scrollLimit.Size = new System.Drawing.Size(676, 27);
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
      this.pictureMerged.BackColor = System.Drawing.SystemColors.Control;
      this.pictureMerged.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.pictureMerged.Location = new System.Drawing.Point(100, 3);
      this.pictureMerged.Name = "pictureMerged";
      this.pictureMerged.Size = new System.Drawing.Size(751, 504);
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
      this.tabControlMain.Location = new System.Drawing.Point(0, 0);
      this.tabControlMain.Name = "tabControlMain";
      this.tabControlMain.SelectedIndex = 0;
      this.tabControlMain.Size = new System.Drawing.Size(865, 541);
      this.tabControlMain.TabIndex = 1;
      // 
      // tabPageSegments
      // 
      this.tabPageSegments.BackColor = System.Drawing.Color.Silver;
      this.tabPageSegments.Controls.Add(this.buttonGotoMatching);
      this.tabPageSegments.Controls.Add(this.listFiles);
      this.tabPageSegments.Controls.Add(this.buttonAddSegments);
      this.tabPageSegments.Location = new System.Drawing.Point(4, 22);
      this.tabPageSegments.Name = "tabPageSegments";
      this.tabPageSegments.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageSegments.Size = new System.Drawing.Size(857, 515);
      this.tabPageSegments.TabIndex = 2;
      this.tabPageSegments.Text = "Segments";
      // 
      // buttonGotoMatching
      // 
      this.buttonGotoMatching.BackColor = System.Drawing.Color.Transparent;
      this.buttonGotoMatching.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonGotoMatching.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonGotoMatching.ForeColor = System.Drawing.Color.Black;
      this.buttonGotoMatching.ImageAlign = System.Drawing.ContentAlignment.TopRight;
      this.buttonGotoMatching.Location = new System.Drawing.Point(8, 102);
      this.buttonGotoMatching.Name = "buttonGotoMatching";
      this.buttonGotoMatching.Size = new System.Drawing.Size(89, 43);
      this.buttonGotoMatching.TabIndex = 2;
      this.buttonGotoMatching.Text = "Next";
      this.buttonGotoMatching.UseVisualStyleBackColor = false;
      this.buttonGotoMatching.Click += new System.EventHandler(this.buttonGotoMatching_Click);
      // 
      // listFiles
      // 
      this.listFiles.Location = new System.Drawing.Point(103, 6);
      this.listFiles.Name = "listFiles";
      this.listFiles.Size = new System.Drawing.Size(746, 501);
      this.listFiles.TabIndex = 1;
      this.listFiles.UseCompatibleStateImageBehavior = false;
      this.listFiles.View = System.Windows.Forms.View.List;
      // 
      // buttonAddSegments
      // 
      this.buttonAddSegments.BackColor = System.Drawing.Color.Transparent;
      this.buttonAddSegments.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonAddSegments.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonAddSegments.ForeColor = System.Drawing.Color.Black;
      this.buttonAddSegments.ImageAlign = System.Drawing.ContentAlignment.TopRight;
      this.buttonAddSegments.Location = new System.Drawing.Point(8, 6);
      this.buttonAddSegments.Name = "buttonAddSegments";
      this.buttonAddSegments.Size = new System.Drawing.Size(89, 90);
      this.buttonAddSegments.TabIndex = 0;
      this.buttonAddSegments.Text = "Add..";
      this.buttonAddSegments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.buttonAddSegments.UseVisualStyleBackColor = false;
      this.buttonAddSegments.Click += new System.EventHandler(this.buttonAddSegments_Click);
      // 
      // tabPageMatching
      // 
      this.tabPageMatching.BackColor = System.Drawing.SystemColors.AppWorkspace;
      this.tabPageMatching.Controls.Add(this.buttonGotoFiles);
      this.tabPageMatching.Controls.Add(this.label2);
      this.tabPageMatching.Controls.Add(this.pictureMatches);
      this.tabPageMatching.Controls.Add(this.scrollLimit);
      this.tabPageMatching.Controls.Add(this.label1);
      this.tabPageMatching.Controls.Add(this.textTimer);
      this.tabPageMatching.Controls.Add(this.textMatchDistance);
      this.tabPageMatching.Controls.Add(this.listSegmentsMatchRight);
      this.tabPageMatching.Controls.Add(this.listSegmentsMatchLeft);
      this.tabPageMatching.Controls.Add(this.buttonGotoMerge);
      this.tabPageMatching.Location = new System.Drawing.Point(4, 22);
      this.tabPageMatching.Name = "tabPageMatching";
      this.tabPageMatching.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageMatching.Size = new System.Drawing.Size(857, 515);
      this.tabPageMatching.TabIndex = 0;
      this.tabPageMatching.Text = "Matching";
      // 
      // buttonGotoFiles
      // 
      this.buttonGotoFiles.BackColor = System.Drawing.Color.Silver;
      this.buttonGotoFiles.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonGotoFiles.Location = new System.Drawing.Point(11, 6);
      this.buttonGotoFiles.Name = "buttonGotoFiles";
      this.buttonGotoFiles.Size = new System.Drawing.Size(76, 41);
      this.buttonGotoFiles.TabIndex = 16;
      this.buttonGotoFiles.Text = "Back";
      this.buttonGotoFiles.UseVisualStyleBackColor = false;
      this.buttonGotoFiles.Click += new System.EventHandler(this.buttonGotoFiles_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(33, 411);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(33, 13);
      this.label2.TabIndex = 15;
      this.label2.Text = "Time:";
      this.label2.Visible = false;
      // 
      // pictureMatches
      // 
      this.pictureMatches.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.pictureMatches.Location = new System.Drawing.Point(173, 6);
      this.pictureMatches.Name = "pictureMatches";
      this.pictureMatches.Size = new System.Drawing.Size(676, 474);
      this.pictureMatches.TabIndex = 4;
      this.pictureMatches.TabStop = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(14, 385);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(52, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "Distance:";
      // 
      // textTimer
      // 
      this.textTimer.Location = new System.Drawing.Point(72, 408);
      this.textTimer.Name = "textTimer";
      this.textTimer.Size = new System.Drawing.Size(56, 20);
      this.textTimer.TabIndex = 8;
      this.textTimer.Visible = false;
      // 
      // textMatchDistance
      // 
      this.textMatchDistance.Location = new System.Drawing.Point(72, 382);
      this.textMatchDistance.Name = "textMatchDistance";
      this.textMatchDistance.Size = new System.Drawing.Size(74, 20);
      this.textMatchDistance.TabIndex = 5;
      // 
      // listSegmentsMatchRight
      // 
      this.listSegmentsMatchRight.FormattingEnabled = true;
      this.listSegmentsMatchRight.Location = new System.Drawing.Point(8, 206);
      this.listSegmentsMatchRight.Name = "listSegmentsMatchRight";
      this.listSegmentsMatchRight.Size = new System.Drawing.Size(158, 160);
      this.listSegmentsMatchRight.TabIndex = 14;
      this.listSegmentsMatchRight.SelectedIndexChanged += new System.EventHandler(this.listSegmentsMatchRight_SelectedIndexChanged);
      // 
      // listSegmentsMatchLeft
      // 
      this.listSegmentsMatchLeft.FormattingEnabled = true;
      this.listSegmentsMatchLeft.Location = new System.Drawing.Point(8, 53);
      this.listSegmentsMatchLeft.Name = "listSegmentsMatchLeft";
      this.listSegmentsMatchLeft.Size = new System.Drawing.Size(158, 147);
      this.listSegmentsMatchLeft.TabIndex = 13;
      this.listSegmentsMatchLeft.SelectedIndexChanged += new System.EventHandler(this.listSegmentsMatchLeft_SelectedIndexChanged);
      // 
      // buttonGotoMerge
      // 
      this.buttonGotoMerge.BackColor = System.Drawing.Color.Silver;
      this.buttonGotoMerge.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonGotoMerge.Location = new System.Drawing.Point(88, 6);
      this.buttonGotoMerge.Name = "buttonGotoMerge";
      this.buttonGotoMerge.Size = new System.Drawing.Size(79, 41);
      this.buttonGotoMerge.TabIndex = 4;
      this.buttonGotoMerge.Text = "Next";
      this.buttonGotoMerge.UseVisualStyleBackColor = false;
      this.buttonGotoMerge.Click += new System.EventHandler(this.buttonUseMatches_Click);
      // 
      // tabPageMerging
      // 
      this.tabPageMerging.BackColor = System.Drawing.Color.Silver;
      this.tabPageMerging.Controls.Add(this.button2);
      this.tabPageMerging.Controls.Add(this.buttonSavePan);
      this.tabPageMerging.Controls.Add(this.pictureMerged);
      this.tabPageMerging.Location = new System.Drawing.Point(4, 22);
      this.tabPageMerging.Name = "tabPageMerging";
      this.tabPageMerging.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageMerging.Size = new System.Drawing.Size(857, 515);
      this.tabPageMerging.TabIndex = 1;
      this.tabPageMerging.Text = "Merging";
      // 
      // button2
      // 
      this.button2.BackColor = System.Drawing.Color.Silver;
      this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.button2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button2.Location = new System.Drawing.Point(8, 95);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(86, 44);
      this.button2.TabIndex = 13;
      this.button2.Text = "Back";
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // buttonSavePan
      // 
      this.buttonSavePan.BackColor = System.Drawing.Color.Silver;
      this.buttonSavePan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonSavePan.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonSavePan.Location = new System.Drawing.Point(6, 6);
      this.buttonSavePan.Name = "buttonSavePan";
      this.buttonSavePan.Size = new System.Drawing.Size(88, 83);
      this.buttonSavePan.TabIndex = 12;
      this.buttonSavePan.Text = "Save";
      this.buttonSavePan.UseVisualStyleBackColor = false;
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
      this.ClientSize = new System.Drawing.Size(865, 541);
      this.Controls.Add(this.tabControlMain);
      this.Controls.Add(this.label3);
      this.Name = "TransformatorForm";
      this.Text = "Image Transformator";
      this.Load += new System.EventHandler(this.TransformatorForm_Load);
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
    private System.Windows.Forms.SaveFileDialog savePanDialog;
    private System.Windows.Forms.TabControl tabControlMain;
    private System.Windows.Forms.TabPage tabPageMatching;
    private System.Windows.Forms.TabPage tabPageMerging;
    private System.Windows.Forms.TabPage tabPageSegments;
    private System.Windows.Forms.Button buttonAddSegments;
    private System.Windows.Forms.Button buttonSavePan;
    private System.Windows.Forms.Button buttonGotoMerge;
    private System.Windows.Forms.OpenFileDialog addSegmentsDialog;
    private System.Windows.Forms.ListBox listSegmentsMatchLeft;
    private System.Windows.Forms.ListBox listSegmentsMatchRight;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textMatchDistance;
    private System.Windows.Forms.TextBox textTimer;
    private System.Windows.Forms.ListView listFiles;
    private System.Windows.Forms.Button buttonGotoMatching;
    private System.Windows.Forms.PictureBox pictureMatches;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button buttonGotoFiles;
    private System.Windows.Forms.Button button2;
  }
}

