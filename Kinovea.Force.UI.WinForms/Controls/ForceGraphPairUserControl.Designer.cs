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
            this.kpiPanelContainer = new System.Windows.Forms.Panel();
            this.kpiPanel = new System.Windows.Forms.Panel();
            this.forceGraphLeft = new Kinovea.Force.UI.WinForms.Controls.ForceGraphUserControl();
            this.forceGraphRight = new Kinovea.Force.UI.WinForms.Controls.ForceGraphUserControl();
            this.clubSpeedMetricControl = new Kinovea.Force.UI.WinForms.Controls.SwingMetricUserControl();
            this.swingTempControl = new Kinovea.Force.UI.WinForms.Controls.SwingMetricUserControl();
            this.attackAngleControl = new Kinovea.Force.UI.WinForms.Controls.SwingMetricUserControl();
            this.clubPathControl = new Kinovea.Force.UI.WinForms.Controls.SwingMetricUserControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.kpiPanelContainer.SuspendLayout();
            this.kpiPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
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
            this.splitContainer1.Size = new System.Drawing.Size(1200, 434);
            this.splitContainer1.SplitterDistance = 597;
            this.splitContainer1.TabIndex = 0;
            // 
            // kpiPanelContainer
            // 
            this.kpiPanelContainer.Controls.Add(this.kpiPanel);
            this.kpiPanelContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpiPanelContainer.Location = new System.Drawing.Point(0, 434);
            this.kpiPanelContainer.Name = "kpiPanelContainer";
            this.kpiPanelContainer.Padding = new System.Windows.Forms.Padding(3);
            this.kpiPanelContainer.Size = new System.Drawing.Size(1200, 85);
            this.kpiPanelContainer.TabIndex = 1;
            this.kpiPanelContainer.SizeChanged += new System.EventHandler(this.KpiPanelContainerSizeChanged);
            // 
            // kpiPanel
            // 
            this.kpiPanel.Controls.Add(this.clubSpeedMetricControl);
            this.kpiPanel.Controls.Add(this.swingTempControl);
            this.kpiPanel.Controls.Add(this.attackAngleControl);
            this.kpiPanel.Controls.Add(this.clubPathControl);
            this.kpiPanel.Location = new System.Drawing.Point(271, 3);
            this.kpiPanel.Name = "kpiPanel";
            this.kpiPanel.Size = new System.Drawing.Size(616, 79);
            this.kpiPanel.TabIndex = 4;
            // 
            // forceGraphLeft
            // 
            this.forceGraphLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.forceGraphLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forceGraphLeft.Location = new System.Drawing.Point(0, 0);
            this.forceGraphLeft.Margin = new System.Windows.Forms.Padding(6);
            this.forceGraphLeft.Name = "forceGraphLeft";
            this.forceGraphLeft.ProgressBarLeft = false;
            this.forceGraphLeft.Size = new System.Drawing.Size(597, 434);
            this.forceGraphLeft.TabIndex = 0;
            // 
            // forceGraphRight
            // 
            this.forceGraphRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.forceGraphRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forceGraphRight.Location = new System.Drawing.Point(0, 0);
            this.forceGraphRight.Margin = new System.Windows.Forms.Padding(6);
            this.forceGraphRight.Name = "forceGraphRight";
            this.forceGraphRight.ProgressBarLeft = false;
            this.forceGraphRight.Size = new System.Drawing.Size(599, 434);
            this.forceGraphRight.TabIndex = 0;
            // 
            // clubSpeedMetricControl
            // 
            this.clubSpeedMetricControl.KPIName = "Club speed";
            this.clubSpeedMetricControl.Location = new System.Drawing.Point(9, -1);
            this.clubSpeedMetricControl.Margin = new System.Windows.Forms.Padding(2);
            this.clubSpeedMetricControl.MetricValue = "125";
            this.clubSpeedMetricControl.Name = "clubSpeedMetricControl";
            this.clubSpeedMetricControl.Size = new System.Drawing.Size(138, 78);
            this.clubSpeedMetricControl.TabIndex = 0;
            this.clubSpeedMetricControl.Unit = "mph";
            // 
            // swingTempControl
            // 
            this.swingTempControl.KPIName = "Swing tempo";
            this.swingTempControl.Location = new System.Drawing.Point(465, -1);
            this.swingTempControl.Margin = new System.Windows.Forms.Padding(2);
            this.swingTempControl.MetricValue = "5:1";
            this.swingTempControl.Name = "swingTempControl";
            this.swingTempControl.Size = new System.Drawing.Size(138, 78);
            this.swingTempControl.TabIndex = 3;
            this.swingTempControl.Unit = "";
            // 
            // attackAngleControl
            // 
            this.attackAngleControl.KPIName = "Attack angle";
            this.attackAngleControl.Location = new System.Drawing.Point(161, -1);
            this.attackAngleControl.Margin = new System.Windows.Forms.Padding(2);
            this.attackAngleControl.MetricValue = "2°";
            this.attackAngleControl.Name = "attackAngleControl";
            this.attackAngleControl.Size = new System.Drawing.Size(138, 78);
            this.attackAngleControl.TabIndex = 1;
            this.attackAngleControl.Unit = "Up";
            // 
            // clubPathControl
            // 
            this.clubPathControl.KPIName = "Club path";
            this.clubPathControl.Location = new System.Drawing.Point(313, -1);
            this.clubPathControl.Margin = new System.Windows.Forms.Padding(2);
            this.clubPathControl.MetricValue = "1,2°";
            this.clubPathControl.Name = "clubPathControl";
            this.clubPathControl.Size = new System.Drawing.Size(138, 78);
            this.clubPathControl.TabIndex = 2;
            this.clubPathControl.Unit = "In-Out";
            // 
            // ForceGraphPairUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.kpiPanelContainer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ForceGraphPairUserControl";
            this.Size = new System.Drawing.Size(1200, 519);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.kpiPanelContainer.ResumeLayout(false);
            this.kpiPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ForceGraphUserControl forceGraphLeft;
        private ForceGraphUserControl forceGraphRight;
        private Rop.Winforms.Icons.FluentUI.FluentUIBank fluentUIBank1;
        private System.Windows.Forms.Panel kpiPanelContainer;
        private SwingMetricUserControl clubSpeedMetricControl;
        private SwingMetricUserControl attackAngleControl;
        private SwingMetricUserControl swingTempControl;
        private SwingMetricUserControl clubPathControl;
        private System.Windows.Forms.Panel kpiPanel;
    }
}
