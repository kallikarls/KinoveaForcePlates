using Kinovea.Force.UI.WinForms.ViewModels;
using LiveChartsCore.SkiaSharpView;
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
    public partial class ForceGraphUserControl : UserControl
    {
        private ForceDataViewModel viewModel = new ForceDataViewModel();

        public ForceGraphUserControl()
        {
            InitializeComponent();
            forceChart.Series = viewModel.Series;
            forceChart.Sections = viewModel.Sections;
            forceChart.SyncContext = viewModel.Sync;

            forceChart.YAxes = new List<Axis> { new Axis { MaxLimit = 100, MinLimit = 0 } };

            SetConnectionStatus(false);
            SetRecording(false);

            viewModel.ActiveMeasurement += SetActiveMeasurement;
            
        }

        private void SetActiveMeasurement(double value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => { SetActiveMeasurement(value); }));
                return;
            }
            progressBar.SetValue((int)value);
        }

        [Browsable(false)]
        public ForceDataViewModel ViewModel => viewModel;

        public void SetConnectionStatus(bool connected)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => { SetConnectionStatus(connected); }));
                return;
            }
            // Connected: Ic_fluent_bluetooth_connected_20
            // Disconnected: Ic_fluent_bluetooth_disabled_20
            if (connected)
            {
                bleStatus.Text = fluentUIBank1.Bank.GetCode("Ic_fluent_bluetooth_connected_20");
                bleStatus.ForeColor = Color.Green;
            }
            else
            {
                bleStatus.Text = fluentUIBank1.Bank.GetCode("Ic_fluent_bluetooth_disabled_20");
                bleStatus.ForeColor = Color.Black;
            }
        }

        public void SetRecording(bool active)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => { SetRecording(active); }));
                return;
            }
            // Recording = Ic_fluent_record_20
            // Record Stopped = Ic_fluent_record_stop_20
            if (active)
            {
                recordStatus.Text = fluentUIBank1.Bank.GetCode("Ic_fluent_record_20");
                recordStatus.ForeColor = Color.Red;
            }
            else
            {
                recordStatus.Text = fluentUIBank1.Bank.GetCode("Ic_fluent_record_stop_20");
                recordStatus.ForeColor = Color.Black;
            }
        }

        public bool ProgressBarLeft
        {
            set
            {
                if (value)
                {
                    progressBar.Dock = DockStyle.Left;
                    bleStatus.Left = progressBar.Width + 14;
                    recordStatus.Left = Width - 50;
                }
                else
                {
                    progressBar.Dock = DockStyle.Right;
                    recordStatus.Anchor = AnchorStyles.None;
                    //recordStatus.Left = Width - (progressBar.Width + 50);
                    recordStatus.Location = new Point(Width - (progressBar.Width + 50), 19);
                    recordStatus.Anchor = AnchorStyles.Right | AnchorStyles.Top;
                }
            }
            get
            {
                return progressBar.Dock == DockStyle.Left;
            }
        }
    }
}
