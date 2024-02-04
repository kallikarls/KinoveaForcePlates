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
    public partial class SwingMetricUserControl : UserControl
    {
        public SwingMetricUserControl()
        {
            InitializeComponent();
        }

        public string MetricValue
        {
            get { return kpiValueLabel.Text; }
            set { kpiValueLabel.Text = value; }
        }

        [Browsable(true)]
        public string Unit
        {
            get { return unitLabel.Text; }
            set { unitLabel.Text = value; }
        }

        [Browsable(true)]
        public string KPIName
        {
            get { return groupBox1.Text; }
            set { groupBox1.Text = value; }
        }

        private void unitLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
