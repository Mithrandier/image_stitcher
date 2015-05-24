using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor.Tools {
  class ContextMenu {
    public ContextMenuStrip Control { get; private set; }
    System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMove;
    System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCrop;
    System.Windows.Forms.ToolStripMenuItem toolStripMenuItemReset;

    public ContextMenu() {
      this.Control = new System.Windows.Forms.ContextMenuStrip();
      this.toolStripMenuItemMove = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemCrop = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemReset = new System.Windows.Forms.ToolStripMenuItem();
      this.Control.SuspendLayout();
      this.Control.Name = "contextMenuStrip1";
      this.Control.Size = new System.Drawing.Size(153, 92);      
      this.Control.ResumeLayout(false);
    }

    public void AddItem(String name, EventHandler handler) {
      var item = new System.Windows.Forms.ToolStripMenuItem();
      item.Size = new System.Drawing.Size(152, 22);
      item.Text = name;
      item.Name = "toolStripMenuItem" + name;
      item.Click += handler;
      this.Control.Items.Add(item);
    }
  }
}
