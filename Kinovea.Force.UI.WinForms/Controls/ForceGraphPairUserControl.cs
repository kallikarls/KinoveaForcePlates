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

namespace Kinovea.Force.UI.WinForms.Controls
{
    public partial class ForceGraphPairUserControl : UserControl
    {
        public ForceGraphPairUserControl()
        {
            InitializeComponent();
            ForceGraphRight.ProgressBarLeft = true;
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
    }
}
