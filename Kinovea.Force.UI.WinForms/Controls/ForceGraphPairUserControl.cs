using Kinovea.Force.UI.WinForms.ViewModels;
using Kinovea.Force.UI.WinForms.Services;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.SKCharts;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.SkiaSharpView.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GSPLink.Abstractions.Models;
using System.Globalization;

namespace Kinovea.Force.UI.WinForms.Controls
{
    public partial class ForceGraphPairUserControl : UserControl
    {
        public ForceGraphPairUserControl()
        {
            InitializeComponent();
            ForceGraphRight.ProgressBarLeft = true;
        }

        public void SetSwingMetrics(SwingMetrics swingMetrics)
        {
            if (swingMetrics.ClubMetrics != null)
            {
                ClubMetrics club = swingMetrics.ClubMetrics;
                clubSpeedMetricControl.MetricValue = club.Speed.ToString("F1");
                
                attackAngleControl.MetricValue = club.AngleOfAttack.ToString("F1");
                if (club.AngleOfAttack > 0)
                    attackAngleControl.Unit = "Up";
                else if (club.AngleOfAttack == 0)
                    attackAngleControl.Unit = "Level";
                else
                    attackAngleControl.Unit = "Down";

                clubPathControl.MetricValue = club.Path.ToString("F1");
                if (club.Path < 0)
                    clubPathControl.Unit = "Out-In";
                else if (club.Path == 0)
                    clubPathControl.Unit = "Straight";
                else
                    clubPathControl.Unit = "In-Out";
            }
            if (swingMetrics.SwingTimings != null)
            {
                string tempoString = "--:--";
                SwingTimings timings = swingMetrics.SwingTimings;
                double backSwingTime = timings.DownSwingStartTime - timings.BackswingStartTime;
                double downSwingTime = timings.ImpactTime - timings.DownSwingStartTime;

                if (backSwingTime > 0 && downSwingTime > 0)
                {
                    double ratio = Math.Round(backSwingTime / downSwingTime, 1);
                    tempoString = $"{ratio.ToString(CultureInfo.InvariantCulture)}:1";
                }
                swingTempControl.MetricValue = tempoString;
            }
        }

        [Browsable(false)]
        public ForceGraphUserControl ForceGraphLeft => this.forceGraphLeft;

        [Browsable(false)]
        public ForceGraphUserControl ForceGraphRight => this.forceGraphRight;

        public void GoToTime(long milliSeconds)
        {
            forceGraphLeft.ViewModel.GoToTime(milliSeconds);
            forceGraphRight.ViewModel.GoToTime(milliSeconds);
        }

        private void KpiPanelContainerSizeChanged(object sender, EventArgs e)
        {
            kpiPanel.Left = kpiPanelContainer.Width / 2 - (kpiPanel.Width / 2);
        }
    }
}
