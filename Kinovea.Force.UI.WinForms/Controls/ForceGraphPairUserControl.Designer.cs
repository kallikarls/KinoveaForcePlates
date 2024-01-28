namespace Kinovea.Force.UI.WinForms.Controls
{
    partial class ForceGraphPairUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fluentUIBank1 = new Rop.Winforms.Icons.FluentUI.FluentUIBank();
            this.forceGraphLeft = new Kinovea.Force.UI.WinForms.Controls.ForceGraphUserControl();
            this.forceGraphRight = new Kinovea.Force.UI.WinForms.Controls.ForceGraphUserControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.forceGraphLeft);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.forceGraphRight);
            this.splitContainer1.Size = new System.Drawing.Size(1026, 250);
            this.splitContainer1.SplitterDistance = 496;
            this.splitContainer1.TabIndex = 0;
            // 
            // forceGraphLeft
            // 
            this.forceGraphLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.forceGraphLeft.Location = new System.Drawing.Point(0, 0);
            this.forceGraphLeft.Name = "forceGraphLeft";
            this.forceGraphLeft.Size = new System.Drawing.Size(496, 250);
            this.forceGraphLeft.TabIndex = 0;
            // 
            // forceGraphRight
            // 
            this.forceGraphRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.forceGraphRight.Location = new System.Drawing.Point(0, 0);
            this.forceGraphRight.Name = "forceGraphRight";
            this.forceGraphRight.Size = new System.Drawing.Size(526, 250);
            this.forceGraphRight.TabIndex = 0;
            // 
            // ForceGraphPairUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ForceGraphPairUserControl";
            this.Size = new System.Drawing.Size(1026, 250);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ForceGraphUserControl forceGraphLeft;
        private ForceGraphUserControl forceGraphRight;
        private Rop.Winforms.Icons.FluentUI.FluentUIBank fluentUIBank1;
    }
}
