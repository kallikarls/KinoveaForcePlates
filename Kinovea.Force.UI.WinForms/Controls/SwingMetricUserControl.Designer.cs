namespace Kinovea.Force.UI.WinForms.Controls
{
    partial class SwingMetricUserControl
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
            this.groupBox1 = new KPIGroupBox();
            this.kpiValueLabel = new System.Windows.Forms.Label();
            this.unitLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.unitLabel);
            this.groupBox1.Controls.Add(this.kpiValueLabel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(178, 134);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "KPI";
            // 
            // kpiValueLabel
            // 
            this.kpiValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kpiValueLabel.Location = new System.Drawing.Point(9, 22);
            this.kpiValueLabel.Name = "kpiValueLabel";
            this.kpiValueLabel.Size = new System.Drawing.Size(163, 88);
            this.kpiValueLabel.TabIndex = 0;
            this.kpiValueLabel.Text = "---";
            this.kpiValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // unitLabel
            // 
            this.unitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unitLabel.BackColor = System.Drawing.Color.Transparent;
            this.unitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitLabel.Location = new System.Drawing.Point(6, 110);
            this.unitLabel.Name = "unitLabel";
            this.unitLabel.Size = new System.Drawing.Size(166, 19);
            this.unitLabel.TabIndex = 1;
            this.unitLabel.Text = "unit";
            this.unitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.unitLabel.Click += new System.EventHandler(this.unitLabel_Click);
            // 
            // SwingMetricUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox1);
            this.Name = "SwingMetricUserControl";
            this.Size = new System.Drawing.Size(178, 134);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KPIGroupBox groupBox1;
        private System.Windows.Forms.Label unitLabel;
        private System.Windows.Forms.Label kpiValueLabel;
    }
}
