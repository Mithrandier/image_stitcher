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
      this.buttonSave = new System.Windows.Forms.Button();
      this.buttonReset = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.pictureThe)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureThe
      // 
      this.pictureThe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.pictureThe.Image = global::ImageEditorTestApp.Properties.Resources._2;
      this.pictureThe.Location = new System.Drawing.Point(43, 46);
      this.pictureThe.Name = "pictureThe";
      this.pictureThe.Size = new System.Drawing.Size(786, 455);
      this.pictureThe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureThe.TabIndex = 0;
      this.pictureThe.TabStop = false;
      // 
      // buttonSave
      // 
      this.buttonSave.Location = new System.Drawing.Point(328, 12);
      this.buttonSave.Name = "buttonSave";
      this.buttonSave.Size = new System.Drawing.Size(75, 23);
      this.buttonSave.TabIndex = 1;
      this.buttonSave.Text = "Save!";
      this.buttonSave.UseVisualStyleBackColor = true;
      this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
      // 
      // buttonReset
      // 
      this.buttonReset.Location = new System.Drawing.Point(409, 12);
      this.buttonReset.Name = "buttonReset";
      this.buttonReset.Size = new System.Drawing.Size(75, 23);
      this.buttonReset.TabIndex = 2;
      this.buttonReset.Text = "Reset";
      this.buttonReset.UseVisualStyleBackColor = true;
      this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(841, 513);
      this.Controls.Add(this.buttonReset);
      this.Controls.Add(this.buttonSave);
      this.Controls.Add(this.pictureThe);
      this.Name = "MainForm";
      this.Text = "Image Editor Test";
      ((System.ComponentModel.ISupportInitialize)(this.pictureThe)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureThe;
    private System.Windows.Forms.Button buttonSave;
    private System.Windows.Forms.Button buttonReset;
  }
}

