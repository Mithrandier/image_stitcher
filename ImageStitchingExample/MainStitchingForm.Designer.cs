namespace ImageStitchingExample {
  partial class MainStitchingForm {
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
      System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("2");
      System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("1");
      this.listSegments = new System.Windows.Forms.ListView();
      this.buttonAdd = new System.Windows.Forms.Button();
      this.buttonStitch = new System.Windows.Forms.Button();
      this.pictureResult = new System.Windows.Forms.PictureBox();
      this.buttonSave = new System.Windows.Forms.Button();
      this.textResultMessage = new System.Windows.Forms.TextBox();
      this.addSegmentDialog = new System.Windows.Forms.OpenFileDialog();
      this.saveResultDialog = new System.Windows.Forms.SaveFileDialog();
      ((System.ComponentModel.ISupportInitialize)(this.pictureResult)).BeginInit();
      this.SuspendLayout();
      // 
      // listSegments
      // 
      this.listSegments.BackColor = System.Drawing.SystemColors.Highlight;
      this.listSegments.GridLines = true;
      this.listSegments.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
      this.listSegments.Location = new System.Drawing.Point(12, 63);
      this.listSegments.Name = "listSegments";
      this.listSegments.ShowItemToolTips = true;
      this.listSegments.Size = new System.Drawing.Size(304, 271);
      this.listSegments.TabIndex = 0;
      this.listSegments.UseCompatibleStateImageBehavior = false;
      // 
      // buttonAdd
      // 
      this.buttonAdd.Location = new System.Drawing.Point(125, 26);
      this.buttonAdd.Name = "buttonAdd";
      this.buttonAdd.Size = new System.Drawing.Size(75, 23);
      this.buttonAdd.TabIndex = 1;
      this.buttonAdd.Text = "Add image..";
      this.buttonAdd.UseVisualStyleBackColor = true;
      this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
      // 
      // buttonStitch
      // 
      this.buttonStitch.Location = new System.Drawing.Point(341, 167);
      this.buttonStitch.Name = "buttonStitch";
      this.buttonStitch.Size = new System.Drawing.Size(75, 23);
      this.buttonStitch.TabIndex = 2;
      this.buttonStitch.Text = "Stitch";
      this.buttonStitch.UseVisualStyleBackColor = true;
      this.buttonStitch.Click += new System.EventHandler(this.buttonStitch_Click);
      // 
      // pictureResult
      // 
      this.pictureResult.BackColor = System.Drawing.SystemColors.Highlight;
      this.pictureResult.Location = new System.Drawing.Point(442, 63);
      this.pictureResult.Name = "pictureResult";
      this.pictureResult.Size = new System.Drawing.Size(305, 271);
      this.pictureResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureResult.TabIndex = 3;
      this.pictureResult.TabStop = false;
      // 
      // buttonSave
      // 
      this.buttonSave.Location = new System.Drawing.Point(561, 26);
      this.buttonSave.Name = "buttonSave";
      this.buttonSave.Size = new System.Drawing.Size(75, 23);
      this.buttonSave.TabIndex = 4;
      this.buttonSave.Text = "Save result..";
      this.buttonSave.UseVisualStyleBackColor = true;
      this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
      // 
      // textResultMessage
      // 
      this.textResultMessage.Location = new System.Drawing.Point(12, 348);
      this.textResultMessage.Name = "textResultMessage";
      this.textResultMessage.ReadOnly = true;
      this.textResultMessage.Size = new System.Drawing.Size(735, 20);
      this.textResultMessage.TabIndex = 5;
      this.textResultMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // addSegmentDialog
      // 
      this.addSegmentDialog.FileName = "openFileDialog1";
      // 
      // MainStitchingForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Highlight;
      this.ClientSize = new System.Drawing.Size(768, 380);
      this.Controls.Add(this.textResultMessage);
      this.Controls.Add(this.buttonSave);
      this.Controls.Add(this.pictureResult);
      this.Controls.Add(this.buttonStitch);
      this.Controls.Add(this.buttonAdd);
      this.Controls.Add(this.listSegments);
      this.Name = "MainStitchingForm";
      this.Text = "Stitching";
      ((System.ComponentModel.ISupportInitialize)(this.pictureResult)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ListView listSegments;
    private System.Windows.Forms.Button buttonAdd;
    private System.Windows.Forms.Button buttonStitch;
    private System.Windows.Forms.PictureBox pictureResult;
    private System.Windows.Forms.Button buttonSave;
    private System.Windows.Forms.TextBox textResultMessage;
    private System.Windows.Forms.OpenFileDialog addSegmentDialog;
    private System.Windows.Forms.SaveFileDialog saveResultDialog;
  }
}

