namespace ImageStitcher
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.loadRawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.performToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.iterateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.resetPixelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.gaussBlurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.addSegmentDialog = new System.Windows.Forms.OpenFileDialog();
      this.currentPictureBox = new System.Windows.Forms.PictureBox();
      this.loadImageDialog = new System.Windows.Forms.OpenFileDialog();
      this.textMessage = new System.Windows.Forms.TextBox();
      this.textTimer = new System.Windows.Forms.TextBox();
      this.scale2xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.buildScaleSpaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.currentPictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // menuStrip
      // 
      this.menuStrip.BackColor = System.Drawing.Color.White;
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.performToolStripMenuItem,
            this.exitToolStripMenuItem});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(452, 24);
      this.menuStrip.TabIndex = 0;
      this.menuStrip.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadRawToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // loadRawToolStripMenuItem
      // 
      this.loadRawToolStripMenuItem.Name = "loadRawToolStripMenuItem";
      this.loadRawToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.loadRawToolStripMenuItem.Text = "Load..";
      this.loadRawToolStripMenuItem.Click += new System.EventHandler(this.loadRawToolStripMenuItem_Click);
      // 
      // performToolStripMenuItem
      // 
      this.performToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iterateToolStripMenuItem,
            this.resetPixelsToolStripMenuItem,
            this.gaussBlurToolStripMenuItem,
            this.scale2xToolStripMenuItem,
            this.buildScaleSpaceToolStripMenuItem});
      this.performToolStripMenuItem.Enabled = false;
      this.performToolStripMenuItem.Name = "performToolStripMenuItem";
      this.performToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
      this.performToolStripMenuItem.Text = "Perform";
      // 
      // iterateToolStripMenuItem
      // 
      this.iterateToolStripMenuItem.Name = "iterateToolStripMenuItem";
      this.iterateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.iterateToolStripMenuItem.Text = "Iterate";
      this.iterateToolStripMenuItem.Click += new System.EventHandler(this.iterateToolStripMenuItem_Click);
      // 
      // resetPixelsToolStripMenuItem
      // 
      this.resetPixelsToolStripMenuItem.Name = "resetPixelsToolStripMenuItem";
      this.resetPixelsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.resetPixelsToolStripMenuItem.Text = "Reset pixels";
      this.resetPixelsToolStripMenuItem.Click += new System.EventHandler(this.resetPixelsToolStripMenuItem_Click);
      // 
      // gaussBlurToolStripMenuItem
      // 
      this.gaussBlurToolStripMenuItem.Name = "gaussBlurToolStripMenuItem";
      this.gaussBlurToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.gaussBlurToolStripMenuItem.Text = "Gauss blur";
      this.gaussBlurToolStripMenuItem.Click += new System.EventHandler(this.gaussBlurToolStripMenuItem_Click);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.exitToolStripMenuItem.Text = "Exit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // addSegmentDialog
      // 
      this.addSegmentDialog.FileName = "openFileDialog1";
      // 
      // currentPictureBox
      // 
      this.currentPictureBox.BackColor = System.Drawing.Color.White;
      this.currentPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.currentPictureBox.Location = new System.Drawing.Point(0, 24);
      this.currentPictureBox.Name = "currentPictureBox";
      this.currentPictureBox.Size = new System.Drawing.Size(452, 385);
      this.currentPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.currentPictureBox.TabIndex = 1;
      this.currentPictureBox.TabStop = false;
      // 
      // loadImageDialog
      // 
      this.loadImageDialog.FileName = "openFileDialog1";
      // 
      // textMessage
      // 
      this.textMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.textMessage.Location = new System.Drawing.Point(0, 389);
      this.textMessage.Name = "textMessage";
      this.textMessage.ReadOnly = true;
      this.textMessage.Size = new System.Drawing.Size(452, 20);
      this.textMessage.TabIndex = 2;
      this.textMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // textTimer
      // 
      this.textTimer.Location = new System.Drawing.Point(340, 4);
      this.textTimer.Name = "textTimer";
      this.textTimer.Size = new System.Drawing.Size(100, 20);
      this.textTimer.TabIndex = 3;
      // 
      // scale2xToolStripMenuItem
      // 
      this.scale2xToolStripMenuItem.Name = "scale2xToolStripMenuItem";
      this.scale2xToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.scale2xToolStripMenuItem.Text = "Scale 2x";
      this.scale2xToolStripMenuItem.Click += new System.EventHandler(this.scale2xToolStripMenuItem_Click);
      // 
      // buildScaleSpaceToolStripMenuItem
      // 
      this.buildScaleSpaceToolStripMenuItem.Name = "buildScaleSpaceToolStripMenuItem";
      this.buildScaleSpaceToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
      this.buildScaleSpaceToolStripMenuItem.Text = "Build scale space";
      this.buildScaleSpaceToolStripMenuItem.Click += new System.EventHandler(this.buildScaleSpaceToolStripMenuItem_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(452, 409);
      this.Controls.Add(this.textTimer);
      this.Controls.Add(this.textMessage);
      this.Controls.Add(this.currentPictureBox);
      this.Controls.Add(this.menuStrip);
      this.MainMenuStrip = this.menuStrip;
      this.Name = "MainForm";
      this.Text = "PIS v1";
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.currentPictureBox)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog addSegmentDialog;
        private System.Windows.Forms.PictureBox currentPictureBox;
        private System.Windows.Forms.OpenFileDialog loadImageDialog;
        private System.Windows.Forms.TextBox textMessage;
        private System.Windows.Forms.TextBox textTimer;
        private System.Windows.Forms.ToolStripMenuItem performToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iterateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetPixelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaussBlurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadRawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scale2xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildScaleSpaceToolStripMenuItem;
    }
}

