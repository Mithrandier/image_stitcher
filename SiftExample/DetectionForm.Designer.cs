namespace SiftExample {
  partial class DetectionForm {
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
      this.pictureCurrent = new System.Windows.Forms.PictureBox();
      this.buttonDetectFeatures = new System.Windows.Forms.Button();
      this.loadImageDialog = new System.Windows.Forms.OpenFileDialog();
      this.textPointsCount = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.textTime = new System.Windows.Forms.TextBox();
      this.buttonResetImage = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.pictureCurrent)).BeginInit();
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
      // pictureCurrent
      // 
      this.pictureCurrent.Location = new System.Drawing.Point(15, 42);
      this.pictureCurrent.Name = "pictureCurrent";
      this.pictureCurrent.Size = new System.Drawing.Size(454, 300);
      this.pictureCurrent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureCurrent.TabIndex = 1;
      this.pictureCurrent.TabStop = false;
      // 
      // buttonDetectFeatures
      // 
      this.buttonDetectFeatures.Location = new System.Drawing.Point(93, 12);
      this.buttonDetectFeatures.Name = "buttonDetectFeatures";
      this.buttonDetectFeatures.Size = new System.Drawing.Size(75, 23);
      this.buttonDetectFeatures.TabIndex = 2;
      this.buttonDetectFeatures.Text = "Detect features";
      this.buttonDetectFeatures.UseVisualStyleBackColor = true;
      this.buttonDetectFeatures.Click += new System.EventHandler(this.buttonDetectFeatures_Click);
      // 
      // loadImageDialog
      // 
      this.loadImageDialog.FileName = "openFileDialog1";
      this.loadImageDialog.Multiselect = true;
      // 
      // textPointsCount
      // 
      this.textPointsCount.Location = new System.Drawing.Point(15, 348);
      this.textPointsCount.Name = "textPointsCount";
      this.textPointsCount.ReadOnly = true;
      this.textPointsCount.Size = new System.Drawing.Size(72, 20);
      this.textPointsCount.TabIndex = 3;
      this.textPointsCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(93, 351);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(52, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "keypoints";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(254, 351);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(20, 13);
      this.label2.TabIndex = 6;
      this.label2.Text = "ms";
      // 
      // textTime
      // 
      this.textTime.Location = new System.Drawing.Point(176, 348);
      this.textTime.Name = "textTime";
      this.textTime.ReadOnly = true;
      this.textTime.Size = new System.Drawing.Size(72, 20);
      this.textTime.TabIndex = 5;
      this.textTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // buttonResetImage
      // 
      this.buttonResetImage.Location = new System.Drawing.Point(173, 12);
      this.buttonResetImage.Name = "buttonResetImage";
      this.buttonResetImage.Size = new System.Drawing.Size(75, 23);
      this.buttonResetImage.TabIndex = 7;
      this.buttonResetImage.Text = "Reset";
      this.buttonResetImage.UseVisualStyleBackColor = true;
      this.buttonResetImage.Click += new System.EventHandler(this.buttonResetImage_Click);
      // 
      // DetectionForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(481, 380);
      this.Controls.Add(this.buttonResetImage);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.textTime);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.textPointsCount);
      this.Controls.Add(this.buttonDetectFeatures);
      this.Controls.Add(this.pictureCurrent);
      this.Controls.Add(this.buttonLoad);
      this.Name = "DetectionForm";
      this.Text = "Features Detection";
      ((System.ComponentModel.ISupportInitialize)(this.pictureCurrent)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button buttonLoad;
    private System.Windows.Forms.PictureBox pictureCurrent;
    private System.Windows.Forms.Button buttonDetectFeatures;
    private System.Windows.Forms.OpenFileDialog loadImageDialog;
    private System.Windows.Forms.TextBox textPointsCount;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textTime;
    private System.Windows.Forms.Button buttonResetImage;
  }
}

