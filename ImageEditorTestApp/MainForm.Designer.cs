namespace ImageEditorTestApp {
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
      this.pictureThe = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureThe)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureThe
      // 
      this.pictureThe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.pictureThe.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureThe.Location = new System.Drawing.Point(0, 0);
      this.pictureThe.Name = "pictureThe";
      this.pictureThe.Size = new System.Drawing.Size(841, 513);
      this.pictureThe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureThe.TabIndex = 0;
      this.pictureThe.TabStop = false;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(841, 513);
      this.Controls.Add(this.pictureThe);
      this.Name = "MainForm";
      this.Text = "Image Editor Test";
      ((System.ComponentModel.ISupportInitialize)(this.pictureThe)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureThe;
  }
}

