using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panoramas.Morphing {
  public class MatrixPresenter {
    Panel panel;
    private System.Windows.Forms.TextBox textMatrix22;
    private System.Windows.Forms.TextBox textMatrix21;
    private System.Windows.Forms.TextBox textMatrix20;
    private System.Windows.Forms.TextBox textMatrix12;
    private System.Windows.Forms.TextBox textMatrix11;
    private System.Windows.Forms.TextBox textMatrix10;
    private System.Windows.Forms.TextBox textMatrix02;
    private System.Windows.Forms.TextBox textMatrix01;
    private System.Windows.Forms.TextBox textMatrix00;

    public MatrixPresenter(Panel matrix_panel) {
      this.panel = matrix_panel;
      this.textMatrix22 = new System.Windows.Forms.TextBox();
      this.textMatrix21 = new System.Windows.Forms.TextBox();
      this.textMatrix20 = new System.Windows.Forms.TextBox();
      this.textMatrix12 = new System.Windows.Forms.TextBox();
      this.textMatrix11 = new System.Windows.Forms.TextBox();
      this.textMatrix10 = new System.Windows.Forms.TextBox();
      this.textMatrix02 = new System.Windows.Forms.TextBox();
      this.textMatrix01 = new System.Windows.Forms.TextBox();
      this.textMatrix00 = new System.Windows.Forms.TextBox();
      // 
      // textMatrix22
      // 
      this.textMatrix22.Location = new System.Drawing.Point(111, 55);
      this.textMatrix22.Name = "textMatrix22";
      this.textMatrix22.Size = new System.Drawing.Size(38, 20);
      this.textMatrix22.TabIndex = 22;
      // 
      // textMatrix21
      // 
      this.textMatrix21.Location = new System.Drawing.Point(67, 55);
      this.textMatrix21.Name = "textMatrix21";
      this.textMatrix21.Size = new System.Drawing.Size(38, 20);
      this.textMatrix21.TabIndex = 21;
      // 
      // textMatrix20
      // 
      this.textMatrix20.Location = new System.Drawing.Point(23, 55);
      this.textMatrix20.Name = "textMatrix20";
      this.textMatrix20.Size = new System.Drawing.Size(38, 20);
      this.textMatrix20.TabIndex = 20;
      // 
      // textMatrix12
      // 
      this.textMatrix12.Location = new System.Drawing.Point(111, 29);
      this.textMatrix12.Name = "textMatrix12";
      this.textMatrix12.Size = new System.Drawing.Size(38, 20);
      this.textMatrix12.TabIndex = 19;
      // 
      // textMatrix11
      // 
      this.textMatrix11.Location = new System.Drawing.Point(67, 29);
      this.textMatrix11.Name = "textMatrix11";
      this.textMatrix11.Size = new System.Drawing.Size(38, 20);
      this.textMatrix11.TabIndex = 18;
      // 
      // textMatrix10
      // 
      this.textMatrix10.Location = new System.Drawing.Point(23, 29);
      this.textMatrix10.Name = "textMatrix10";
      this.textMatrix10.Size = new System.Drawing.Size(38, 20);
      this.textMatrix10.TabIndex = 17;
      // 
      // textMatrix02
      // 
      this.textMatrix02.Location = new System.Drawing.Point(111, 3);
      this.textMatrix02.Name = "textMatrix02";
      this.textMatrix02.Size = new System.Drawing.Size(38, 20);
      this.textMatrix02.TabIndex = 16;
      // 
      // textMatrix01
      // 
      this.textMatrix01.Location = new System.Drawing.Point(67, 3);
      this.textMatrix01.Name = "textMatrix01";
      this.textMatrix01.Size = new System.Drawing.Size(38, 20);
      this.textMatrix01.TabIndex = 15;
      // 
      // textMatrix00
      // 
      this.textMatrix00.Location = new System.Drawing.Point(23, 3);
      this.textMatrix00.Name = "textMatrix00";
      this.textMatrix00.Size = new System.Drawing.Size(38, 20);
      this.textMatrix00.TabIndex = 14;
      this.panel.Controls.Add(this.textMatrix22);
      this.panel.Controls.Add(this.textMatrix21);
      this.panel.Controls.Add(this.textMatrix20);
      this.panel.Controls.Add(this.textMatrix12);
      this.panel.Controls.Add(this.textMatrix11);
      this.panel.Controls.Add(this.textMatrix10);
      this.panel.Controls.Add(this.textMatrix02);
      this.panel.Controls.Add(this.textMatrix01);
      this.panel.Controls.Add(this.textMatrix00);
    }

    public void Display(Emgu.CV.HomographyMatrix matrix) {
      textMatrix00.Text = matrix[0, 0].ToString();
      textMatrix10.Text = matrix[1, 0].ToString();
      textMatrix20.Text = matrix[2, 0].ToString();

      textMatrix01.Text = matrix[0, 1].ToString();
      textMatrix11.Text = matrix[1, 1].ToString();
      textMatrix21.Text = matrix[2, 1].ToString();

      textMatrix02.Text = matrix[0, 2].ToString();
      textMatrix12.Text = matrix[1, 2].ToString();
      textMatrix22.Text = matrix[2, 2].ToString();
    }

    public void DisplayCurrent(Emgu.CV.HomographyMatrix original_matrix) {
      Display(this.FixCurrentMatrix(original_matrix));
    }

    public Emgu.CV.HomographyMatrix FixCurrentMatrix(Emgu.CV.HomographyMatrix original_matrix) {
      var matrix = original_matrix.Clone();
      matrix[0, 0] = Double.Parse(textMatrix00.Text);
      matrix[1, 0] = Double.Parse(textMatrix10.Text);
      matrix[2, 0] = Double.Parse(textMatrix20.Text);

      matrix[0, 1] = Double.Parse(textMatrix01.Text);
      matrix[1, 1] = Double.Parse(textMatrix11.Text);
      matrix[2, 1] = Double.Parse(textMatrix21.Text);

      matrix[0, 2] = Double.Parse(textMatrix02.Text);
      matrix[1, 2] = Double.Parse(textMatrix12.Text);
      matrix[2, 2] = Double.Parse(textMatrix22.Text);
      return matrix;
    }
  }
}
