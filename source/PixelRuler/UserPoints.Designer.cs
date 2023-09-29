
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
			this.panelPointEditor = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.txtPosX = new System.Windows.Forms.NumericUpDown();
			this.txtPosY = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.EditorOK = new System.Windows.Forms.Button();
			this.toolStrip1.SuspendLayout();
			this.panelPointEditor.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtPosX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPosY)).BeginInit();
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
			this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
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
			// panelPointEditor
			// 
			this.panelPointEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelPointEditor.Controls.Add(this.EditorOK);
			this.panelPointEditor.Controls.Add(this.label2);
			this.panelPointEditor.Controls.Add(this.txtPosY);
			this.panelPointEditor.Controls.Add(this.txtPosX);
			this.panelPointEditor.Controls.Add(this.label1);
			this.panelPointEditor.Location = new System.Drawing.Point(25, 96);
			this.panelPointEditor.Name = "panelPointEditor";
			this.panelPointEditor.Size = new System.Drawing.Size(160, 100);
			this.panelPointEditor.TabIndex = 2;
			this.panelPointEditor.Visible = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(17, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "X:";
			// 
			// txtPosX
			// 
			this.txtPosX.Location = new System.Drawing.Point(28, 11);
			this.txtPosX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.txtPosX.Name = "txtPosX";
			this.txtPosX.Size = new System.Drawing.Size(120, 20);
			this.txtPosX.TabIndex = 1;
			this.txtPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtPosX.ThousandsSeparator = true;
			// 
			// txtPosY
			// 
			this.txtPosY.Location = new System.Drawing.Point(28, 38);
			this.txtPosY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.txtPosY.Name = "txtPosY";
			this.txtPosY.Size = new System.Drawing.Size(120, 20);
			this.txtPosY.TabIndex = 2;
			this.txtPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtPosY.ThousandsSeparator = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(17, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Y:";
			// 
			// EditorOK
			// 
			this.EditorOK.Location = new System.Drawing.Point(111, 64);
			this.EditorOK.Name = "EditorOK";
			this.EditorOK.Size = new System.Drawing.Size(37, 23);
			this.EditorOK.TabIndex = 4;
			this.EditorOK.Text = "OK";
			this.EditorOK.UseVisualStyleBackColor = true;
			this.EditorOK.Click += new System.EventHandler(this.EditorOK_Click);
			// 
			// UserPoints
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(219, 323);
			this.Controls.Add(this.panelPointEditor);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.toolStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "UserPoints";
			this.Text = "UserPoints";
			this.Load += new System.EventHandler(this.UserPoints_Load);
			this.Shown += new System.EventHandler(this.UserPoints_Shown);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panelPointEditor.ResumeLayout(false);
			this.panelPointEditor.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtPosX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPosY)).EndInit();
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
		private System.Windows.Forms.Panel panelPointEditor;
		private System.Windows.Forms.Button EditorOK;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown txtPosY;
		private System.Windows.Forms.NumericUpDown txtPosX;
		private System.Windows.Forms.Label label1;
	}
}