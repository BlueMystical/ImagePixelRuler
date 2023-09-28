
namespace PixelRuler
{
	partial class UserPoints
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.cmdremoveSelected = new System.Windows.Forms.ToolStripButton();
			this.cmdClearAll = new System.Windows.Forms.ToolStripButton();
			this.cmdExport = new System.Windows.Forms.ToolStripButton();
			this.cmdImportPoints = new System.Windows.Forms.ToolStripButton();
			this.lblDescription = new System.Windows.Forms.ToolStripLabel();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(0, 25);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(219, 298);
			this.listBox1.TabIndex = 0;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdremoveSelected,
            this.cmdClearAll,
            this.cmdExport,
            this.cmdImportPoints,
            this.lblDescription});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(219, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// cmdremoveSelected
			// 
			this.cmdremoveSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdremoveSelected.Image = global::PixelRuler.Properties.Resources.clear_24;
			this.cmdremoveSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdremoveSelected.Name = "cmdremoveSelected";
			this.cmdremoveSelected.Size = new System.Drawing.Size(23, 22);
			this.cmdremoveSelected.Text = "Remove Selected";
			this.cmdremoveSelected.Click += new System.EventHandler(this.cmdremoveSelected_Click);
			this.cmdremoveSelected.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cmdremoveSelected_MouseMove);
			// 
			// cmdClearAll
			// 
			this.cmdClearAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdClearAll.Image = global::PixelRuler.Properties.Resources.bin_24;
			this.cmdClearAll.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdClearAll.Name = "cmdClearAll";
			this.cmdClearAll.Size = new System.Drawing.Size(23, 22);
			this.cmdClearAll.Text = "Clear All";
			this.cmdClearAll.Click += new System.EventHandler(this.cmdClearAll_Click);
			this.cmdClearAll.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cmdClearAll_MouseMove);
			// 
			// cmdExport
			// 
			this.cmdExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdExport.Image = global::PixelRuler.Properties.Resources.export_24;
			this.cmdExport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdExport.Name = "cmdExport";
			this.cmdExport.Size = new System.Drawing.Size(23, 22);
			this.cmdExport.Text = "Export to JSON";
			this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
			this.cmdExport.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cmdExport_MouseMove);
			// 
			// cmdImportPoints
			// 
			this.cmdImportPoints.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdImportPoints.Image = global::PixelRuler.Properties.Resources.import_24;
			this.cmdImportPoints.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdImportPoints.Name = "cmdImportPoints";
			this.cmdImportPoints.Size = new System.Drawing.Size(23, 22);
			this.cmdImportPoints.Text = "Import Points..";
			this.cmdImportPoints.Click += new System.EventHandler(this.cmdImportPoints_Click);
			this.cmdImportPoints.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cmdImportPoints_MouseMove);
			// 
			// lblDescription
			// 
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(10, 22);
			this.lblDescription.Text = ".";
			// 
			// UserPoints
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(219, 323);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.toolStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "UserPoints";
			this.Text = "UserPoints";
			this.Load += new System.EventHandler(this.UserPoints_Load);
			this.Shown += new System.EventHandler(this.UserPoints_Shown);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton cmdremoveSelected;
		private System.Windows.Forms.ToolStripButton cmdClearAll;
		private System.Windows.Forms.ToolStripButton cmdExport;
		private System.Windows.Forms.ToolStripLabel lblDescription;
		private System.Windows.Forms.ToolStripButton cmdImportPoints;
	}
}