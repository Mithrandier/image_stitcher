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
      this.buttonLoad = new System.Windows.Forms.Button();
      this.textFeaturesNum1 = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.textFeaturesNum2 = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.loadImagesDialog = new System.Windows.Forms.OpenFileDialog();
      this.pictureMatches = new System.Windows.Forms.PictureBox();
      this.scrollLimit = new System.Windows.Forms.HScrollBar();
      this.label3 = new System.Windows.Forms.Label();
      this.textTimer = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureMatches)).BeginInit();
      this.SuspendLayout();
      // 
      // buttonLoad
      // 
      this.buttonLoad.Location = new System.Drawing.Point(12, 12);
      this.buttonLoad.Name = "buttonLoad";
      this.buttonLoad.Size = new System.Drawing.Size(75, 23);
      this.buttonLoad.TabIndex = 0;
      this.buttonLoad.Text = "Load..";
      this.buttonLoad.UseVisualStyleBackColor = true;
      this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
      // 
      // textFeaturesNum1
      // 
      this.textFeaturesNum1.Location = new System.Drawing.Point(93, 41);
      this.textFeaturesNum1.Name = "textFeaturesNum1";
      this.textFeaturesNum1.Size = new System.Drawing.Size(100, 20);
      this.textFeaturesNum1.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(199, 44);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(45, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "features";
      // 
      // textFeaturesNum2
      // 
      this.textFeaturesNum2.Location = new System.Drawing.Point(476, 41);
      this.textFeaturesNum2.Name = "textFeaturesNum2";
      this.textFeaturesNum2.Size = new System.Drawing.Size(100, 20);
      this.textFeaturesNum2.TabIndex = 2;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(582, 44);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(45, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "features";
      // 
      // loadImagesDialog
      // 
      this.loadImagesDialog.FileName = "openFileDialog1";
      this.loadImagesDialog.Filter = "Images |*.jpeg;*.png;*.jpg;*.gif";
      this.loadImagesDialog.Multiselect = true;
      // 
      // pictureMatches
      // 
      this.pictureMatches.Location = new System.Drawing.Point(12, 67);
      this.pictureMatches.Name = "pictureMatches";
      this.pictureMatches.Size = new System.Drawing.Size(743, 320);
      this.pictureMatches.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureMatches.TabIndex = 4;
      this.pictureMatches.TabStop = false;
      // 
      // scrollLimit
      // 
      this.scrollLimit.Enabled = false;
      this.scrollLimit.Location = new System.Drawing.Point(12, 390);
      this.scrollLimit.Name = "scrollLimit";
      this.scrollLimit.Size = new System.Drawing.Size(743, 23);
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
      // TransformatorForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(767, 419);
      this.Controls.Add(this.textFeaturesNum2);
      this.Controls.Add(this.textFeaturesNum1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.scrollLimit);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.pictureMatches);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.textTimer);
      this.Controls.Add(this.buttonLoad);
      this.Name = "TransformatorForm";
      this.Text = "Image Transformator";
      ((System.ComponentModel.ISupportInitialize)(this.pictureMatches)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button buttonLoad;
    private System.Windows.Forms.TextBox textFeaturesNum1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textFeaturesNum2;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.OpenFileDialog loadImagesDialog;
    private System.Windows.Forms.PictureBox pictureMatches;
    private System.Windows.Forms.HScrollBar scrollLimit;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textTimer;
  }
}

