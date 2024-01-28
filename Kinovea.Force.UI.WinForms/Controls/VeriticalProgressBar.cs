using System.Windows.Forms;

namespace Kinovea.Force.UI.WinForms.Controls
{
    public partial class VeriticalProgressBar : ProgressBar
    {
        public VeriticalProgressBar()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x04;
                return cp;
            }
        }

        public void SetValue(int value)
        {
            // Don't redraw if nothing is changing.
            if (value == Value)
                return;

            if (value > Maximum)
                value = Maximum;

            if (value < Minimum)
                value = Minimum;

            // To get around this animation, we need to move the progress bar backwards.
            if (value == Maximum)
            {
                // Special case (can't set value > Maximum).
                Value = value;           // Set the value
                Value = value - 1;       // Move it backwards
            }
            else
            {
                Value = value + 1;       // Move past
            }
            Value = value;               // Move to correct value
        }
    }
}
