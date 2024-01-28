namespace Kinovea.Force.UI.WinForms.Controls
{
    partial class ForceGraphUserControl
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
            this.forceChart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            this.bleStatus = new Rop.Winforms.Icons.IconLabel();
            this.fluentUIBank1 = new Rop.Winforms.Icons.FluentUI.FluentUIBank();
            this.recordStatus = new Rop.Winforms.Icons.IconLabel();
            this.progressBar = new Kinovea.Force.UI.WinForms.Controls.VeriticalProgressBar();
            this.SuspendLayout();
            // 
            // forceChart
            // 
            this.forceChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.forceChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.forceChart.Location = new System.Drawing.Point(0, 0);
            this.forceChart.Name = "forceChart";
            this.forceChart.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.forceChart.Size = new System.Drawing.Size(513, 249);
            this.forceChart.TabIndex = 0;
            // 
            // bleStatus
            // 
            this.bleStatus.AutoSize = true;
            this.bleStatus.BankIcon = this.fluentUIBank1;
            this.bleStatus.DisabledColor = System.Drawing.Color.Empty;
            this.bleStatus.ForeColor = System.Drawing.Color.LawnGreen;
            this.bleStatus.IconColor = System.Drawing.Color.Empty;
            this.bleStatus.IconScale = 250;
            this.bleStatus.Location = new System.Drawing.Point(14, 10);
            this.bleStatus.Name = "bleStatus";
            this.bleStatus.OffsetIcon = 0;
            this.bleStatus.OffsetText = 0;
            this.bleStatus.PrefixCode = null;
            this.bleStatus.Size = new System.Drawing.Size(8, 14);
            this.bleStatus.SuffixCode = null;
            this.bleStatus.TabIndex = 2;
            this.bleStatus.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.bleStatus.UseIconColor = false;
            // 
            // recordStatus
            // 
            this.recordStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.recordStatus.AutoSize = true;
            this.recordStatus.BankIcon = this.fluentUIBank1;
            this.recordStatus.DisabledColor = System.Drawing.Color.Empty;
            this.recordStatus.IconColor = System.Drawing.Color.Empty;
            this.recordStatus.IconScale = 250;
            this.recordStatus.Location = new System.Drawing.Point(470, 10);
            this.recordStatus.Name = "recordStatus";
            this.recordStatus.OffsetIcon = 0;
            this.recordStatus.OffsetText = 0;
            this.recordStatus.PrefixCode = null;
            this.recordStatus.Size = new System.Drawing.Size(8, 14);
            this.recordStatus.SuffixCode = null;
            this.recordStatus.TabIndex = 3;
            this.recordStatus.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.recordStatus.UseIconColor = false;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.progressBar.Location = new System.Drawing.Point(513, 0);
            this.progressBar.Margin = new System.Windows.Forms.Padding(5);
            this.progressBar.MarqueeAnimationSpeed = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(40, 249);
            this.progressBar.TabIndex = 4;
            // 
            // ForceGraphUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bleStatus);
            this.Controls.Add(this.recordStatus);
            this.Controls.Add(this.forceChart);
            this.Controls.Add(this.progressBar);
            this.Name = "ForceGraphUserControl";
            this.Size = new System.Drawing.Size(553, 249);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart forceChart;

        #endregion
        private Rop.Winforms.Icons.IconLabel bleStatus;
        private Rop.Winforms.Icons.FluentUI.FluentUIBank fluentUIBank1;
        private Rop.Winforms.Icons.IconLabel recordStatus;
        private VeriticalProgressBar progressBar;
    }
}
