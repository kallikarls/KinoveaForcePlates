#region License
/*
Copyright � Joan Charmant 2011.
joan.charmant@gmail.com 
 
This file is part of Kinovea.

Kinovea is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License version 2 
as published by the Free Software Foundation.

Kinovea is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Kinovea. If not, see http://www.gnu.org/licenses/.
*/
#endregion
namespace Kinovea.Root
{
	partial class PreferencePanelDrawings
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabSubPages = new System.Windows.Forms.TabControl();
			this.tabGeneral = new System.Windows.Forms.TabPage();
			this.grpColors = new System.Windows.Forms.GroupBox();
			this.lblPlane3D = new System.Windows.Forms.Label();
			this.lblGrid = new System.Windows.Forms.Label();
			this.btn3DPlaneColor = new System.Windows.Forms.Button();
			this.btnGridColor = new System.Windows.Forms.Button();
			this.chkDrawOnPlay = new System.Windows.Forms.CheckBox();
			this.tabPersistence = new System.Windows.Forms.TabPage();
			this.chkAlwaysVisible = new System.Windows.Forms.CheckBox();
			this.lblFading = new System.Windows.Forms.Label();
			this.trkFading = new System.Windows.Forms.TrackBar();
			this.chkEnablePersistence = new System.Windows.Forms.CheckBox();
			this.tabSubPages.SuspendLayout();
			this.tabGeneral.SuspendLayout();
			this.grpColors.SuspendLayout();
			this.tabPersistence.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trkFading)).BeginInit();
			this.SuspendLayout();
			// 
			// tabSubPages
			// 
			this.tabSubPages.Controls.Add(this.tabGeneral);
			this.tabSubPages.Controls.Add(this.tabPersistence);
			this.tabSubPages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabSubPages.Location = new System.Drawing.Point(0, 0);
			this.tabSubPages.Name = "tabSubPages";
			this.tabSubPages.SelectedIndex = 0;
			this.tabSubPages.Size = new System.Drawing.Size(432, 236);
			this.tabSubPages.TabIndex = 0;
			// 
			// tabGeneral
			// 
			this.tabGeneral.Controls.Add(this.grpColors);
			this.tabGeneral.Controls.Add(this.chkDrawOnPlay);
			this.tabGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabGeneral.Name = "tabGeneral";
			this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabGeneral.Size = new System.Drawing.Size(424, 210);
			this.tabGeneral.TabIndex = 0;
			this.tabGeneral.Text = "General";
			this.tabGeneral.UseVisualStyleBackColor = true;
			// 
			// grpColors
			// 
			this.grpColors.Controls.Add(this.lblPlane3D);
			this.grpColors.Controls.Add(this.lblGrid);
			this.grpColors.Controls.Add(this.btn3DPlaneColor);
			this.grpColors.Controls.Add(this.btnGridColor);
			this.grpColors.Location = new System.Drawing.Point(6, 62);
			this.grpColors.Name = "grpColors";
			this.grpColors.Size = new System.Drawing.Size(405, 74);
			this.grpColors.TabIndex = 53;
			this.grpColors.TabStop = false;
			this.grpColors.Text = "Colors";
			// 
			// lblPlane3D
			// 
			this.lblPlane3D.AutoSize = true;
			this.lblPlane3D.Location = new System.Drawing.Point(11, 51);
			this.lblPlane3D.Name = "lblPlane3D";
			this.lblPlane3D.Size = new System.Drawing.Size(57, 13);
			this.lblPlane3D.TabIndex = 13;
			this.lblPlane3D.Text = "3D Plane :";
			// 
			// lblGrid
			// 
			this.lblGrid.AutoSize = true;
			this.lblGrid.Location = new System.Drawing.Point(11, 23);
			this.lblGrid.Name = "lblGrid";
			this.lblGrid.Size = new System.Drawing.Size(32, 13);
			this.lblGrid.TabIndex = 11;
			this.lblGrid.Text = "Grid :";
			// 
			// btn3DPlaneColor
			// 
			this.btn3DPlaneColor.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btn3DPlaneColor.BackColor = System.Drawing.Color.Black;
			this.btn3DPlaneColor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btn3DPlaneColor.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
			this.btn3DPlaneColor.FlatAppearance.BorderSize = 0;
			this.btn3DPlaneColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn3DPlaneColor.Location = new System.Drawing.Point(323, 44);
			this.btn3DPlaneColor.Name = "btn3DPlaneColor";
			this.btn3DPlaneColor.Size = new System.Drawing.Size(60, 20);
			this.btn3DPlaneColor.TabIndex = 25;
			this.btn3DPlaneColor.UseVisualStyleBackColor = false;
			this.btn3DPlaneColor.Click += new System.EventHandler(this.btn3DPlaneColor_Click);
			// 
			// btnGridColor
			// 
			this.btnGridColor.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnGridColor.BackColor = System.Drawing.Color.Black;
			this.btnGridColor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnGridColor.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
			this.btnGridColor.FlatAppearance.BorderSize = 0;
			this.btnGridColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGridColor.Location = new System.Drawing.Point(323, 16);
			this.btnGridColor.Name = "btnGridColor";
			this.btnGridColor.Size = new System.Drawing.Size(60, 20);
			this.btnGridColor.TabIndex = 20;
			this.btnGridColor.UseVisualStyleBackColor = false;
			this.btnGridColor.Click += new System.EventHandler(this.btnGridColor_Click);
			// 
			// chkDrawOnPlay
			// 
			this.chkDrawOnPlay.AutoSize = true;
			this.chkDrawOnPlay.Location = new System.Drawing.Point(17, 27);
			this.chkDrawOnPlay.Name = "chkDrawOnPlay";
			this.chkDrawOnPlay.Size = new System.Drawing.Size(202, 17);
			this.chkDrawOnPlay.TabIndex = 52;
			this.chkDrawOnPlay.Text = "Show drawings when video is playing";
			this.chkDrawOnPlay.UseVisualStyleBackColor = true;
			this.chkDrawOnPlay.CheckedChanged += new System.EventHandler(this.chkDrawOnPlay_CheckedChanged);
			// 
			// tabPersistence
			// 
			this.tabPersistence.Controls.Add(this.chkAlwaysVisible);
			this.tabPersistence.Controls.Add(this.lblFading);
			this.tabPersistence.Controls.Add(this.trkFading);
			this.tabPersistence.Controls.Add(this.chkEnablePersistence);
			this.tabPersistence.Location = new System.Drawing.Point(4, 22);
			this.tabPersistence.Name = "tabPersistence";
			this.tabPersistence.Padding = new System.Windows.Forms.Padding(3);
			this.tabPersistence.Size = new System.Drawing.Size(424, 210);
			this.tabPersistence.TabIndex = 1;
			this.tabPersistence.Text = "Persistence";
			this.tabPersistence.UseVisualStyleBackColor = true;
			// 
			// chkAlwaysVisible
			// 
			this.chkAlwaysVisible.AutoSize = true;
			this.chkAlwaysVisible.Location = new System.Drawing.Point(19, 137);
			this.chkAlwaysVisible.Name = "chkAlwaysVisible";
			this.chkAlwaysVisible.Size = new System.Drawing.Size(91, 17);
			this.chkAlwaysVisible.TabIndex = 55;
			this.chkAlwaysVisible.Text = "Always visible";
			this.chkAlwaysVisible.UseVisualStyleBackColor = true;
			this.chkAlwaysVisible.CheckedChanged += new System.EventHandler(this.chkAlwaysVisible_CheckedChanged);
			// 
			// lblFading
			// 
			this.lblFading.Location = new System.Drawing.Point(15, 39);
			this.lblFading.Name = "lblFading";
			this.lblFading.Size = new System.Drawing.Size(362, 32);
			this.lblFading.TabIndex = 52;
			this.lblFading.Text = "By default, drawings will stay visible for 12 images around the Key Image. kdjfns" +
			"kdjbnsdkjbksdjvbdvkbj";
			this.lblFading.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// trkFading
			// 
			this.trkFading.BackColor = System.Drawing.Color.White;
			this.trkFading.Location = new System.Drawing.Point(19, 77);
			this.trkFading.Maximum = 60;
			this.trkFading.Minimum = 1;
			this.trkFading.Name = "trkFading";
			this.trkFading.Size = new System.Drawing.Size(359, 45);
			this.trkFading.TabIndex = 54;
			this.trkFading.Value = 5;
			this.trkFading.ValueChanged += new System.EventHandler(this.trkFading_ValueChanged);
			// 
			// chkEnablePersistence
			// 
			this.chkEnablePersistence.AutoSize = true;
			this.chkEnablePersistence.Location = new System.Drawing.Point(15, 15);
			this.chkEnablePersistence.Name = "chkEnablePersistence";
			this.chkEnablePersistence.Size = new System.Drawing.Size(116, 17);
			this.chkEnablePersistence.TabIndex = 53;
			this.chkEnablePersistence.Text = "Enable persistence";
			this.chkEnablePersistence.UseVisualStyleBackColor = true;
			this.chkEnablePersistence.CheckedChanged += new System.EventHandler(this.chkFading_CheckedChanged);
			// 
			// PreferencePanelDrawings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabSubPages);
			this.Name = "PreferencePanelDrawings";
			this.Size = new System.Drawing.Size(432, 236);
			this.tabSubPages.ResumeLayout(false);
			this.tabGeneral.ResumeLayout(false);
			this.tabGeneral.PerformLayout();
			this.grpColors.ResumeLayout(false);
			this.grpColors.PerformLayout();
			this.tabPersistence.ResumeLayout(false);
			this.tabPersistence.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trkFading)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TabControl tabSubPages;
		private System.Windows.Forms.TabPage tabGeneral;
		private System.Windows.Forms.TabPage tabPersistence;
		private System.Windows.Forms.Button btnGridColor;
		private System.Windows.Forms.Button btn3DPlaneColor;
		private System.Windows.Forms.Label lblGrid;
		private System.Windows.Forms.Label lblPlane3D;
		private System.Windows.Forms.GroupBox grpColors;
		private System.Windows.Forms.CheckBox chkEnablePersistence;
		private System.Windows.Forms.TrackBar trkFading;
		private System.Windows.Forms.Label lblFading;
		private System.Windows.Forms.CheckBox chkAlwaysVisible;
		private System.Windows.Forms.CheckBox chkDrawOnPlay;
	}
}
