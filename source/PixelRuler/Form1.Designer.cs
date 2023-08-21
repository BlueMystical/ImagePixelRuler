﻿
namespace PixelRuler
{
	partial class Form1
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.cmdLoadImage = new System.Windows.Forms.ToolStripButton();
			this.lblImageSize = new System.Windows.Forms.ToolStripLabel();
			this.cmdForeColor = new System.Windows.Forms.ToolStripButton();
			this.lblLocation = new System.Windows.Forms.ToolStripLabel();
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(200, 100);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
			this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
			this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdLoadImage,
            this.lblImageSize,
            this.cmdForeColor,
            this.lblLocation});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(980, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// cmdLoadImage
			// 
			this.cmdLoadImage.Image = ((System.Drawing.Image)(resources.GetObject("cmdLoadImage.Image")));
			this.cmdLoadImage.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdLoadImage.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.cmdLoadImage.Name = "cmdLoadImage";
			this.cmdLoadImage.Size = new System.Drawing.Size(89, 24);
			this.cmdLoadImage.Text = "Load Image";
			this.cmdLoadImage.Click += new System.EventHandler(this.cmdLoadImage_Click);
			// 
			// lblImageSize
			// 
			this.lblImageSize.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.lblImageSize.Name = "lblImageSize";
			this.lblImageSize.Size = new System.Drawing.Size(73, 22);
			this.lblImageSize.Text = "Size: 0 x 0 px";
			// 
			// cmdForeColor
			// 
			this.cmdForeColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.cmdForeColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.cmdForeColor.Image = ((System.Drawing.Image)(resources.GetObject("cmdForeColor.Image")));
			this.cmdForeColor.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdForeColor.Name = "cmdForeColor";
			this.cmdForeColor.Size = new System.Drawing.Size(63, 22);
			this.cmdForeColor.Text = "ForeColor";
			this.cmdForeColor.Click += new System.EventHandler(this.cmdForeColor_Click);
			// 
			// lblLocation
			// 
			this.lblLocation.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.lblLocation.Name = "lblLocation";
			this.lblLocation.Size = new System.Drawing.Size(70, 22);
			this.lblLocation.Text = "Pos X: 0, Y:0";
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 25);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(980, 604);
			this.panel1.TabIndex = 2;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(980, 629);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "Form1";
			this.Text = "Image Pixel Ruler";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton cmdLoadImage;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStripLabel lblImageSize;
		private System.Windows.Forms.ToolStripButton cmdForeColor;
		private System.Windows.Forms.ToolStripLabel lblLocation;
	}
}

